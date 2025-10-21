import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { Subject, Observable } from 'rxjs';

export interface BookingNotification {
  scheduleId: number;
  bookingReference: string;
  availableSeats: number;
  bookedSeats: string[];
  passengerName: string;
  bookingTime: Date;
}

@Injectable({
  providedIn: 'root'
})
export class RealTimeService {
  private connection: signalR.HubConnection | null = null;
  private bookingConfirmedSubject = new Subject<BookingNotification>();
  private bookingCancelledSubject = new Subject<BookingNotification>();
  private connectionStatusSubject = new Subject<boolean>();

  public bookingConfirmed$ = this.bookingConfirmedSubject.asObservable();
  public bookingCancelled$ = this.bookingCancelledSubject.asObservable();
  public connectionStatus$ = this.connectionStatusSubject.asObservable();

  constructor() {
    this.initializeConnection();
  }

  private initializeConnection(): void {
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl('http://localhost:5000/booking-hub', {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets
      })
      .withAutomaticReconnect([0, 0, 0, 1000, 3000, 5000])
      .build();

    // Setup event listeners
    this.connection.on('BookingConfirmed', (notification: BookingNotification) => {
      console.log('Booking confirmed notification received:', notification);
      this.bookingConfirmedSubject.next(notification);
    });

    this.connection.on('BookingCancelled', (notification: BookingNotification) => {
      console.log('Booking cancelled notification received:', notification);
      this.bookingCancelledSubject.next(notification);
    });

    this.connection.onreconnected(() => {
      console.log('SignalR connection re-established');
      this.connectionStatusSubject.next(true);
    });

    this.connection.onreconnecting(() => {
      console.log('SignalR attempting to reconnect...');
      this.connectionStatusSubject.next(false);
    });

    this.connection.onclose(() => {
      console.log('SignalR connection closed');
      this.connectionStatusSubject.next(false);
    });
  }

  public connect(): Promise<void> {
    if (this.connection?.state === signalR.HubConnectionState.Connected) {
      return Promise.resolve();
    }

    return this.connection!.start()
      .then(() => {
        console.log('SignalR connected');
        this.connectionStatusSubject.next(true);
      })
      .catch((err: any) => {
        console.error('SignalR connection error:', err);
        this.connectionStatusSubject.next(false);
        return Promise.reject(err);
      });
  }

  public disconnect(): Promise<void> {
    if (!this.connection) {
      return Promise.resolve();
    }

    return this.connection.stop()
      .then(() => {
        console.log('SignalR disconnected');
        this.connectionStatusSubject.next(false);
      })
      .catch((err: any) => {
        console.error('SignalR disconnection error:', err);
        return Promise.reject(err);
      });
  }

  public subscribeToSchedule(scheduleId: number): Promise<void> {
    if (!this.connection) {
      return Promise.reject('Connection not initialized');
    }

    return this.connection.invoke('SubscribeToSchedule', scheduleId)
      .then(() => {
        console.log(`Subscribed to schedule ${scheduleId}`);
      })
      .catch((err: any) => {
        console.error(`Error subscribing to schedule ${scheduleId}:`, err);
        return Promise.reject(err);
      });
  }

  public unsubscribeFromSchedule(scheduleId: number): Promise<void> {
    if (!this.connection) {
      return Promise.reject('Connection not initialized');
    }

    return this.connection.invoke('UnsubscribeFromSchedule', scheduleId)
      .then(() => {
        console.log(`Unsubscribed from schedule ${scheduleId}`);
      })
      .catch((err: any) => {
        console.error(`Error unsubscribing from schedule ${scheduleId}:`, err);
        return Promise.reject(err);
      });
  }

  public isConnected(): boolean {
    return this.connection?.state === signalR.HubConnectionState.Connected;
  }
}
