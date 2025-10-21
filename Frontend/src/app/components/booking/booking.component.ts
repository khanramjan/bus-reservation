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
  passengerGender = ''; // Male, Female, Other
  selectedSeats: string[] = [];
  boardingPoint = '';
  droppingPoint = '';
  agreedToTerms = false;

  isLoading = false;
  errorMessage = '';
  bookingConfirmation: BookingResponse | null = null;
  bookedSeats: string[] = []; // Track all booked seats

  constructor(private bookingService: BookingService) { }

  ngOnInit(): void {
    // Initialize booked seats - parse from bus data if available
    this.initializeBookedSeats();
  }

  private initializeBookedSeats(): void {
    // This would typically come from the backend
    // For now, we'll start with empty and update when bookings happen
    this.bookedSeats = [];
  }

  generateSeats(): string[] {
    const seats: (string | null)[] = [];
    // Generate a 4x13 seat layout
    for (let row = 1; row <= 13; row++) {
      for (let col = 1; col <= 4; col++) {
        const seatNum = (row - 1) * 4 + col;
        seats.push(`${seatNum}`);
      }
    }
    return seats as string[];
  }

  toggleSeat(seat: string): void {
    if (this.isSeatBooked(seat)) {
      // Cannot book already booked seats
      return;
    }

    const index = this.selectedSeats.indexOf(seat);
    if (index > -1) {
      // Deselect seat
      this.selectedSeats.splice(index, 1);
    } else {
      // Select seat
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
    if (!this.boardingPoint || !this.droppingPoint || !this.passengerPhone || !this.passengerGender) {
      this.errorMessage = 'Please fill all required fields';
      return;
    }

    if (this.selectedSeats.length === 0) {
      this.errorMessage = 'Please select at least one seat';
      return;
    }

    if (!this.agreedToTerms) {
      this.errorMessage = 'Please agree to terms and conditions';
      return;
    }

    const phonePattern = /^[0-9]{10,11}$/;
    if (!phonePattern.test(this.passengerPhone)) {
      this.errorMessage = 'Please enter a valid phone number';
      return;
    }

    const bookingRequest: BookingRequest = {
      scheduleId: this.selectedBus.scheduleId,
      passengerName: this.passengerName,
      passengerEmail: this.passengerEmail,
      passengerPhone: this.passengerPhone,
      passengerGender: this.passengerGender,
      numberOfSeats: this.selectedSeats.length,
      seatNumbers: this.selectedSeats
    };

    this.isLoading = true;
    this.errorMessage = '';

    this.bookingService.createBooking(bookingRequest).subscribe({
      next: (response) => {
        this.isLoading = false;
        this.bookingConfirmation = response;
        
        // Add booked seats to the list
        this.bookedSeats = [...this.bookedSeats, ...this.selectedSeats];
        
        // Clear selection
        this.selectedSeats = [];
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
    this.selectedSeats = [];
    this.bookingConfirmation = null;
    this.boardingPoint = '';
    this.droppingPoint = '';
    this.passengerName = '';
    this.passengerEmail = '';
    this.passengerPhone = '';
    this.passengerGender = '';
    this.agreedToTerms = false;
    this.errorMessage = '';
  }

  formatTime(dateTimeString: string | undefined): string {
    if (!dateTimeString) return '';
    const date = new Date(dateTimeString);
    return date.toLocaleTimeString('en-US', { hour: '2-digit', minute: '2-digit' });
  }

  formatDate(dateTimeString: string | undefined): string {
    if (!dateTimeString) return '';
    const date = new Date(dateTimeString);
    return date.toLocaleDateString('en-US', { year: 'numeric', month: 'long', day: 'numeric' });
  }

  private phonePattern = /^[0-9]{10,11}$/;
}
