import { Component, OnInit } from '@angular/core';
import { BookingService } from '../../services/booking.service';
import { SearchRequest, AvailableBus } from '../../models/booking.models';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  searchRequest: SearchRequest = {
    source: '',
    destination: '',
    journeyDate: ''
  };

  availableBuses: AvailableBus[] = [];
  isLoading = false;
  errorMessage = '';
  selectedBus: AvailableBus | null = null;

  cities = [
    'Bagerhat', 'Bandarban', 'Barguna', 'Barisal', 'Bhola', 'Bogra', 'Brahmanbaria',
    'Chandpur', 'Chapainawabganj', 'Chittagong', 'Chuadanga', 'Comilla', 'Cox\'s Bazar',
    'Dinajpur', 'Dhaka', 'Faridpur', 'Feni', 'Gaibandha', 'Gazipur', 'Gopalganj',
    'Habiganj', 'Jamalpur', 'Jessore', 'Jhalokati', 'Jhenaidah', 'Joypurhat', 'Khagrachhari',
    'Khulna', 'Kishoreganj', 'Kurigram', 'Kushtia', 'Lakshmipur', 'Lalmonirhat', 'Madaripur',
    'Magura', 'Manikganj', 'Maulvibazar', 'Meherpur', 'Munshiganj', 'Mymensingh', 'Naogaon',
    'Narail', 'Narayanganj', 'Narsingdi', 'Natore', 'Netrokona', 'Nilphamari', 'Noakhali',
    'Pabna', 'Panchagarh', 'Patuakhali', 'Pirojpur', 'Rajbari', 'Rajshahi', 'Rangamati',
    'Rangpur', 'Satkhira', 'Shariatpur', 'Sherpur', 'Sirajganj', 'Sunamganj', 'Sylhet',
    'Tangail', 'Thakurgaon'
  ];

  constructor(private bookingService: BookingService) { }

  ngOnInit(): void {
    // Set minimum date to today
    const today = new Date().toISOString().split('T')[0];
    this.searchRequest.journeyDate = today;
  }

  searchBuses(): void {
    if (!this.searchRequest.source || !this.searchRequest.destination || !this.searchRequest.journeyDate) {
      this.errorMessage = 'Please fill all search fields';
      return;
    }

    if (this.searchRequest.source === this.searchRequest.destination) {
      this.errorMessage = 'Source and destination cannot be the same';
      return;
    }

    this.isLoading = true;
    this.errorMessage = '';
    this.availableBuses = [];

    this.bookingService.searchBuses(this.searchRequest).subscribe({
      next: (buses) => {
        this.availableBuses = buses;
        this.isLoading = false;
        if (buses.length === 0) {
          this.errorMessage = 'No buses available for the selected route and date';
        }
      },
      error: (error) => {
        this.isLoading = false;
        this.errorMessage = 'Error searching buses. Please try again.';
        console.error('Search error:', error);
      }
    });
  }

  selectBus(bus: AvailableBus): void {
    this.selectedBus = bus;
  }

  formatTime(dateTimeString: string): string {
    const date = new Date(dateTimeString);
    return date.toLocaleTimeString('en-US', { hour: '2-digit', minute: '2-digit' });
  }

  formatDuration(duration: string): string {
    // Duration comes as "HH:mm:ss"
    const parts = duration.split(':');
    const hours = parseInt(parts[0]);
    const minutes = parseInt(parts[1]);
    return `${hours}h ${minutes}m`;
  }

  onBookingComplete(): void {
    this.selectedBus = null;
    this.searchBuses(); // Refresh the list
  }

  cancelSelection(): void {
    this.selectedBus = null;
  }
}
