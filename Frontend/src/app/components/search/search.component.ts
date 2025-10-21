import { Component, OnInit, OnDestroy } from '@angular/core';
import { BookingService } from '../../services/booking.service';
import { RealTimeService, BookingNotification } from '../../services/real-time.service';
import { SearchRequest, AvailableBus } from '../../models/booking.models';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit, OnDestroy {
  searchRequest: SearchRequest = {
    source: '',
    destination: '',
    journeyDate: ''
  };

  availableBuses: AvailableBus[] = [];
  isLoading = false;
  errorMessage = '';
  selectedBus: AvailableBus | null = null;
  showFilterModal = false;
  realtimeMessage = '';
  
  filters = {
    busType: [] as string[],
    priceRange: { min: 0, max: 5000 },
    departureTime: 'all'
  };
  
  filteredBuses: AvailableBus[] = [];
  private destroy$ = new Subject<void>();

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

  constructor(
    private bookingService: BookingService,
    private realTimeService: RealTimeService
  ) { }

  ngOnInit(): void {
    const tomorrow = new Date();
    tomorrow.setDate(tomorrow.getDate() + 1);
    this.searchRequest.journeyDate = tomorrow.toISOString().split('T')[0];

    this.realTimeService.connect().catch(err => {
      console.error('Failed to connect to real-time service:', err);
    });

    this.realTimeService.bookingConfirmed$
      .pipe(takeUntil(this.destroy$))
      .subscribe((notification: BookingNotification) => {
        this.handleBookingConfirmed(notification);
      });

    this.realTimeService.bookingCancelled$
      .pipe(takeUntil(this.destroy$))
      .subscribe((notification: BookingNotification) => {
        this.handleBookingCancelled(notification);
      });
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
    this.realTimeService.disconnect().catch(err => {
      console.error('Error disconnecting:', err);
    });
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
        
        buses.forEach(bus => {
          this.realTimeService.subscribeToSchedule(bus.scheduleId).catch(err => {
            console.error(`Failed to subscribe to schedule ${bus.scheduleId}:`, err);
          });
        });

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

  private handleBookingConfirmed(notification: BookingNotification): void {
    const busIndex = this.availableBuses.findIndex(b => b.scheduleId === notification.scheduleId);
    if (busIndex !== -1) {
      this.availableBuses[busIndex].availableSeats = notification.availableSeats;
      this.realtimeMessage = `✓ ${notification.passengerName} just booked ${notification.bookedSeats.length} seat(s)! ${notification.availableSeats} seats left`;
      setTimeout(() => { this.realtimeMessage = ''; }, 5000);
      this.availableBuses = [...this.availableBuses];
    }
  }

  private handleBookingCancelled(notification: BookingNotification): void {
    const busIndex = this.availableBuses.findIndex(b => b.scheduleId === notification.scheduleId);
    if (busIndex !== -1) {
      this.availableBuses[busIndex].availableSeats = notification.availableSeats;
      this.realtimeMessage = `↩ ${notification.passengerName}'s booking cancelled. ${notification.availableSeats} seats available`;
      setTimeout(() => { this.realtimeMessage = ''; }, 5000);
      this.availableBuses = [...this.availableBuses];
    }
  }

  selectBus(bus: AvailableBus): void {
    this.selectedBus = bus;
  }

  formatTime(dateTimeString: string): string {
    const date = new Date(dateTimeString);
    return date.toLocaleTimeString('en-US', { hour: '2-digit', minute: '2-digit' });
  }

  formatDuration(duration: string): string {
    const parts = duration.split(':');
    const hours = parseInt(parts[0]);
    const minutes = parseInt(parts[1]);
    return `${hours}h ${minutes}m`;
  }

  onBookingComplete(): void {
    this.selectedBus = null;
    this.searchBuses();
  }

  cancelSelection(): void {
    this.selectedBus = null;
  }

  swapCities(): void {
    const temp = this.searchRequest.source;
    this.searchRequest.source = this.searchRequest.destination;
    this.searchRequest.destination = temp;
  }

  modifySearch(): void {
    this.availableBuses = [];
    this.selectedBus = null;
  }

  getUniqueOperators(): number {
    const operators = new Set(this.availableBuses.map(bus => bus.busName));
    return operators.size;
  }

  getTotalSeats(): number {
    return this.availableBuses.reduce((total, bus) => total + bus.availableSeats, 0);
  }

  sortBy(criteria: string): void {
    if (criteria === 'departure') {
      this.availableBuses.sort((a, b) => 
        new Date(a.departureTime).getTime() - new Date(b.departureTime).getTime()
      );
    } else if (criteria === 'seats') {
      this.availableBuses.sort((a, b) => b.availableSeats - a.availableSeats);
    } else if (criteria === 'fare') {
      this.availableBuses.sort((a, b) => a.price - b.price);
    }
  }

  toggleFilterModal(): void {
    this.showFilterModal = !this.showFilterModal;
  }

  toggleBusType(type: string): void {
    const index = this.filters.busType.indexOf(type);
    if (index > -1) {
      this.filters.busType.splice(index, 1);
    } else {
      this.filters.busType.push(type);
    }
    this.applyFilters();
  }

  applyFilters(): void {
    this.filteredBuses = this.availableBuses.filter(bus => {
      if (this.filters.busType.length > 0) {
        if (!this.filters.busType.includes(bus.busType)) {
          return false;
        }
      }
      
      if (bus.price < this.filters.priceRange.min || bus.price > this.filters.priceRange.max) {
        return false;
      }
      
      if (this.filters.departureTime !== 'all') {
        const departureHour = new Date(bus.departureTime).getHours();
        if (this.filters.departureTime === 'morning' && !(departureHour >= 5 && departureHour < 12)) {
          return false;
        }
        if (this.filters.departureTime === 'afternoon' && !(departureHour >= 12 && departureHour < 17)) {
          return false;
        }
        if (this.filters.departureTime === 'evening' && !(departureHour >= 17 && departureHour < 21)) {
          return false;
        }
        if (this.filters.departureTime === 'night' && !(departureHour >= 21 || departureHour < 5)) {
          return false;
        }
      }
      
      return true;
    });
  }

  resetFilters(): void {
    this.filters = {
      busType: [],
      priceRange: { min: 0, max: 5000 },
      departureTime: 'all'
    };
    this.applyFilters();
  }

  getDisplayBuses(): AvailableBus[] {
    return this.filters.busType.length > 0 || this.filters.departureTime !== 'all' || 
           this.filters.priceRange.min > 0 || this.filters.priceRange.max < 5000 
      ? this.filteredBuses 
      : this.availableBuses;
  }
}
