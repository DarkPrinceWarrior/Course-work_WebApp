import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from 'src/app/shared.service';
import { Location } from '@angular/common';
import { AppComponent } from 'src/app/app.component';

@Component({
  selector: 'app-add-hotels',
  templateUrl: './add-hotels.component.html',
  styleUrls: ['./add-hotels.component.css']
})
export class AddHotelsComponent implements OnInit {


  response: { dbPath: ""; };
  ToursList: any[];


  constructor(private service:SharedService,
    private router:ActivatedRoute, private rout:Router,private location: Location
    , private appComp:AppComponent
    )
    {}


  radiocheck="";

  public TourId:number;
  Description:string;
  Hotel: string;
  PhotoPath: string;



  cancel() {
    this.location.back(); // <-- go back to previous location on cancel
  }


  ngOnInit(): void {

    this.appComp.IsActivated=false;

    this.service.getTours().subscribe(data=>{
      this.ToursList=data;
      });
  }

  onChangeTour(TourId:number){

    if(TourId)
     this.TourId=TourId;
     else
     console.log("TourId is null");



  }


  addHotel(){



    var val = {

      tourId:this.TourId,
      hotel_Name:this.Hotel,
      descrip:this.Description

    };

    if(confirm("Do you want to add new hotel?")){
    this.service.PostHotels(val).subscribe(data=>{
      alert(data.toString());
    })
  }
  }



  }



