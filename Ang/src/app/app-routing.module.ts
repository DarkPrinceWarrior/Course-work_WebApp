import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import {ToursComponent} from './tours/tours.component';
import { LoginComponent } from './user/login/login.component';
import { AddEditToursComponent } from './tours/add-edit-tours/add-edit-tours.component';
import {EditAddToursComponent} from './tours/edit-add-tours/edit-add-tours.component';
import { HotelsComponent } from './hotels/hotels.component';
import { AddHotelsComponent } from './hotels/add-hotels/add-hotels.component';
import {EditHotelsComponent} from './hotels/edit-hotels/edit-hotels.component';
import { BookingComponent } from './booking/booking.component';
import {ProfileComponent} from './user/login/profile/profile.component';
import { BookingslistComponent } from './booking/bookingslist/bookingslist.component';
import { AdminusersComponent } from './user/adminusers/adminusers.component';
import { AirlineComponent } from './airline/airline.component';
import { RoomnumberComponent } from './roomnumber/roomnumber.component';
import { AuthGuard } from './auth.guard';


// указываем путь до туда, куда нужно



const routes: Routes = [

  {  path: '',   redirectTo: '', pathMatch: 'full' },

{path:'tours',component:ToursComponent,canActivate:[AuthGuard],
data: {
  role: ['Client','Admin','Tour-m'] //+unlogged user

}
},
{path:'login',component:LoginComponent},

{path:'Add_Edit',component:AddEditToursComponent,canActivate:[AuthGuard],
data: {
  role: ['Admin','Tour-m']

}
},
{path: 'edit',component:EditAddToursComponent,canActivate:[AuthGuard],
data: {
  role: ['Admin','Tour-m']

}
},
{path: 'hotels/:id',component:HotelsComponent,canActivate:[AuthGuard],
data: {
  role: ['Client','Admin','Tour-m'] //+unlogged user

}

},
{path: 'Add_hotel',component:AddHotelsComponent,canActivate:[AuthGuard],
data: {
  role: ['Admin','Tour-m']

}
},
{path: 'edit_Hotels',component:EditHotelsComponent,canActivate:[AuthGuard],
data: {
  role: ['Admin','Tour-m']

}

},
{path: 'Booking/:id',component:BookingComponent,canActivate:[AuthGuard],
data: {
  role: ['Client','Admin']

}

},
{path: 'SeeProfile',component:ProfileComponent},

{path: 'Book_List',component:BookingslistComponent,canActivate:[AuthGuard],
data: {
  role: 'Book-m'

}
},
{path: 'User_List',component:AdminusersComponent,canActivate:[AuthGuard],
data: {
  role: 'Admin'

}

},

{path: 'Airline',component:AirlineComponent,canActivate:[AuthGuard],
data: {
  role: ['Tour-m','Admin']

}},

{path: 'Roomnumber',component:RoomnumberComponent,canActivate:[AuthGuard],
data: {
  role: ['Tour-m','Admin']

}



}

];



@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule {





}

export const routingComponents
 =[  AddEditToursComponent,EditAddToursComponent,HotelsComponent,AddHotelsComponent,EditHotelsComponent,
  BookingComponent,ProfileComponent,BookingslistComponent,AdminusersComponent,AirlineComponent,RoomnumberComponent

]
