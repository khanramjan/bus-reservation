export interface SearchRequest {
  source: string;
  destination: string;
  journeyDate: string;
}

export interface AvailableBus {
  scheduleId: number;
  busName: string;
  busNumber: string;
  busType: string;
  source: string;
  destination: string;
  departureTime: string;
  arrivalTime: string;
  journeyDate: string;
  price: number;
  availableSeats: number;
  duration: string;
  amenities: string;
}

export interface BookingRequest {
  scheduleId: number;
  passengerName: string;
  passengerEmail: string;
  passengerPhone: string;
  numberOfSeats: number;
  seatNumbers: string[];
}

export interface BookingResponse {
  bookingId: number;
  bookingReference: string;
  passengerName: string;
  passengerEmail: string;
  busName: string;
  busNumber: string;
  source: string;
  destination: string;
  departureTime: string;
  arrivalTime: string;
  numberOfSeats: number;
  seatNumbers: string;
  totalAmount: number;
  bookingDate: string;
  bookingStatus: string;
}

export interface CancellationRequest {
  bookingReference: string;
  passengerEmail: string;
}
