import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {AppRoutingModule} from './app-routing.module';
import { AppComponent } from './app.component';
import { ToursComponent } from './tours/tours.component';
import { ShowToursComponent } from './tours/show-tours/show-tours.component';
import { AddEditToursComponent } from './tours/add-edit-tours/add-edit-tours.component';
import {SharedService} from './shared.service';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
import { PhotoUploadComponent } from './photo-upload/photo-upload.component';
import { LoginComponent } from './user/login/login.component';
import * as alertify from 'alertifyjs';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import {EditAddToursComponent} from './tours/edit-add-tours/edit-add-tours.component';
import { FooterComponent } from './footer/footer.component';
import { HotelsComponent } from './hotels/hotels.component';
import { ShowHotelsComponent } from './hotels/show-hotels/show-hotels.component';
import { AddHotelsComponent } from './hotels/add-hotels/add-hotels.component';
import { EditHotelsComponent } from './hotels/edit-hotels/edit-hotels.component';
import { MatCardModule} from '@angular/material/card';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { FlexLayoutModule } from '@angular/flex-layout';
import { BookingComponent } from './booking/booking.component';
import {TabsModule} from 'ngx-bootstrap/tabs';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatNativeDateModule} from '@angular/material/core';
import {MatSelectModule} from '@angular/material/select';
import {MatTableModule} from '@angular/material/table';
import { ProfileComponent } from './user/login/profile/profile.component';
import { MatInputModule} from "@angular/material/input";
import { MatPaginatorModule} from "@angular/material/paginator";
import {MatProgressSpinnerModule} from "@angular/material/progress-spinner";
import {MatSortModule} from "@angular/material/sort";
import {MatIconModule} from '@angular/material/icon';
import { EditUserComponent } from './user/login/profile/edit-user/edit-user.component';
import { BookingslistComponent } from './booking/bookingslist/bookingslist.component';
import { AdminusersComponent } from './user/adminusers/adminusers.component';
import { AdminLoginComponent } from './user/admin-login/admin-login.component';
import { AirlineComponent } from './airline/airline.component';
import { RoomnumberComponent } from './roomnumber/roomnumber.component';
import { AddEditAirlineComponent } from './airline/add-edit-airline/add-edit-airline.component';
import { AddEditRoomnumberComponent } from './roomnumber/add-edit-roomnumber/add-edit-roomnumber.component'


// import { DropDownsModule } from '@progress/kendo-angular-dropdowns';


@NgModule({
  declarations: [
    AppComponent,
    ToursComponent,
    ShowToursComponent,
    AddEditToursComponent,
    PhotoUploadComponent,
    LoginComponent,
    EditAddToursComponent,
    FooterComponent,
    HotelsComponent,
    ShowHotelsComponent,
    AddHotelsComponent,
    EditHotelsComponent,
    BookingComponent,
    ProfileComponent,
    EditUserComponent,
    BookingslistComponent,
    AdminusersComponent,
    AdminLoginComponent,
    AirlineComponent,
    RoomnumberComponent,
    AddEditAirlineComponent,
    AddEditRoomnumberComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    MatSortModule,
    FormsModule,
    MatProgressSpinnerModule,
    MatPaginatorModule,
    ReactiveFormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatCardModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    FlexLayoutModule,
    TabsModule,
    MatSelectModule,
    MatNativeDateModule,
    MatDatepickerModule,
    MatTableModule,
    MatInputModule,
    BsDropdownModule.forRoot()
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
