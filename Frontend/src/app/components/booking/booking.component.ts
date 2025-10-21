import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { BookingService } from '../../services/booking.service';
import { AvailableBus, BookingRequest, BookingResponse } from '../../models/booking.models';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.css']
})
export class BookingComponent implements OnInit {
  @Input() selectedBus!: AvailableBus;
  @Output() bookingComplete = new EventEmitter<void>();
  @Output() bookingCancelled = new EventEmitter<void>();

  passengerName = '';
  passengerEmail = '';
  passengerPhone = '';
  selectedSeats: string[] = [];
  availableSeatsArray: string[] = [];
  bookedSeats: string[] = [];

  isLoading = false;
  errorMessage = '';
  bookingConfirmation: BookingResponse | null = null;

  constructor(private bookingService: BookingService) { }

  ngOnInit(): void {
    this.generateSeats();
  }

  generateSeats(): void {
    const totalSeats = this.selectedBus.availableSeats + 10; // Simulate some booked seats
    for (let i = 1; i <= totalSeats; i++) {
      const seatNumber = `S${i.toString().padStart(2, '0')}`;
      if (i <= this.selectedBus.availableSeats) {
        this.availableSeatsArray.push(seatNumber);
      } else {
        this.bookedSeats.push(seatNumber);
      }
    }
  }

  toggleSeat(seat: string): void {
    if (this.bookedSeats.includes(seat)) {
      return;
    }

    const index = this.selectedSeats.indexOf(seat);
    if (index > -1) {
      this.selectedSeats.splice(index, 1);
    } else {
      if (this.selectedSeats.length < 6) { // Max 6 seats per booking
        this.selectedSeats.push(seat);
      } else {
        alert('Maximum 6 seats can be booked at once');
      }
    }
  }

  isSeatSelected(seat: string): boolean {
    return this.selectedSeats.includes(seat);
  }

  isSeatBooked(seat: string): boolean {
    return this.bookedSeats.includes(seat);
  }

  calculateTotal(): number {
    return this.selectedSeats.length * this.selectedBus.price;
  }

  confirmBooking(): void {
    if (!this.passengerName || !this.passengerEmail || !this.passengerPhone) {
      this.errorMessage = 'Please fill all passenger details';
      return;
    }

    if (this.selectedSeats.length === 0) {
      this.errorMessage = 'Please select at least one seat';
      return;
    }

    const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailPattern.test(this.passengerEmail)) {
      this.errorMessage = 'Please enter a valid email address';
      return;
    }

    const phonePattern = /^[0-9]{10}$/;
    if (!phonePattern.test(this.passengerPhone)) {
      this.errorMessage = 'Please enter a valid 10-digit phone number';
      return;
    }

    const bookingRequest: BookingRequest = {
      scheduleId: this.selectedBus.scheduleId,
      passengerName: this.passengerName,
      passengerEmail: this.passengerEmail,
      passengerPhone: this.passengerPhone,
      numberOfSeats: this.selectedSeats.length,
      seatNumbers: this.selectedSeats
    };

    this.isLoading = true;
    this.errorMessage = '';

    this.bookingService.createBooking(bookingRequest).subscribe({
      next: (response) => {
        this.isLoading = false;
        this.bookingConfirmation = response;
      },
      error: (error) => {
        this.isLoading = false;
        this.errorMessage = error.error?.message || 'Error creating booking. Please try again.';
        console.error('Booking error:', error);
      }
    });
  }

  cancelBooking(): void {
    this.bookingCancelled.emit();
  }

  bookAnother(): void {
    this.bookingComplete.emit();
  }

  formatTime(dateTimeString: string): string {
    const date = new Date(dateTimeString);
    return date.toLocaleTimeString('en-US', { hour: '2-digit', minute: '2-digit' });
  }

  formatDate(dateTimeString: string): string {
    const date = new Date(dateTimeString);
    return date.toLocaleDateString('en-US', { year: 'numeric', month: 'long', day: 'numeric' });
  }
}
