import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { SearchComponent } from './components/search/search.component';
import { BookingComponent } from './components/booking/booking.component';
import { BookingService } from './services/booking.service';

@NgModule({
  declarations: [
    AppComponent,
    SearchComponent,
    BookingComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [BookingService],
  bootstrap: [AppComponent]
})
export class AppModule { }
