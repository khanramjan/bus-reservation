import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {
  SearchRequest,
  AvailableBus,
  BookingRequest,
  BookingResponse,
  CancellationRequest
} from '../models/booking.models';

@Injectable({
  providedIn: 'root'
})
export class BookingService {
  private apiUrl = 'http://localhost:5000/api';

  constructor(private http: HttpClient) { }

  searchBuses(searchRequest: SearchRequest): Observable<AvailableBus[]> {
    return this.http.post<AvailableBus[]>(`${this.apiUrl}/buses/search`, searchRequest);
  }

  createBooking(bookingRequest: BookingRequest): Observable<BookingResponse> {
    return this.http.post<BookingResponse>(`${this.apiUrl}/bookings`, bookingRequest);
  }

  getBookingDetails(bookingReference: string): Observable<BookingResponse> {
    return this.http.get<BookingResponse>(`${this.apiUrl}/bookings/${bookingReference}`);
  }

  getBookingsByEmail(email: string): Observable<BookingResponse[]> {
    return this.http.get<BookingResponse[]>(`${this.apiUrl}/bookings/by-email/${email}`);
  }

  cancelBooking(cancellationRequest: CancellationRequest): Observable<any> {
    return this.http.post(`${this.apiUrl}/bookings/cancel`, cancellationRequest);
  }
}
