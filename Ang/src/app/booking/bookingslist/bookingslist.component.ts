import { Component, OnInit } from '@angular/core';
import { AppComponent } from 'src/app/app.component';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-bookingslist',
  templateUrl: './bookingslist.component.html',
  styleUrls: ['./bookingslist.component.css']
})
export class BookingslistComponent implements OnInit {


  displayedColumns:string[] = ['id', 'airLineId',
  'number_of_people','number_of_days','sum','roomNumberId','isBooked','touristId','status','actions'];

  dataSource: any=[];


  constructor(private service:SharedService, private appComp:AppComponent) { }

  ngOnInit(): void {

    this.appComp.IsActivated=false;

    this.LoadBookList();
  }

  async LoadBookList(){


      this.dataSource=await this.service.GetAllBookings();

  }




  ConfirmBook(val:any){

    if(confirm("Do you want to confirm the booking?")){

      val.isBooked=true;
      this.service.PutBooking(val).subscribe(data=>{
        alert(data.toString());
      })

    }

  }



  ReturnBook(val:number){

    if(confirm("Do you want to delete the booking?")){

      this.service.DeleteBooking(val).subscribe(data=>{
        alert(data.toString());
      })

    }


  }
}
