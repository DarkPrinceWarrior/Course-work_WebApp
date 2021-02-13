import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AppComponent } from 'src/app/app.component';
import { SharedService } from 'src/app/shared.service';


@Component({
  selector: 'app-edit-hotels',
  templateUrl: './edit-hotels.component.html',
  styleUrls: ['./edit-hotels.component.css']
})

export class EditHotelsComponent implements OnInit {

  constructor(private service:SharedService,private router:Router, private appComp:AppComponent) { }

  @Input() trs1:any;

  Id:string;
  TourId:string;
  Price:string;
  FreePlaces:string;
  Description:string;
  Hotel: string;
  PhotoPath: string;

  IsChoiceOfImage: boolean=false;
  public response:{dbPath:''}

  ngOnInit(): void {

    this.appComp.IsActivated=false;

    this.loadHotelList()
  }

  radiocheck="";


  loadHotelList(){

      this.Id=this.trs1.id;
      this.TourId=this.trs1.tourId;
      this.Price=this.trs1.nightPrice;
      this.FreePlaces=this.trs1.freePlaces;
      this.Description=this.trs1.descrip;
      this.Hotel=this.trs1.hotel_Name;
      this.PhotoPath=this.trs1.pictures;


  }



  UpdateHotel(){


    if(this.IsChoiceOfImage){
    var val = {

      id:this.Id,
      tourId:this.TourId,
      hotel_Name:this.Hotel,
      descrip:this.Description,
      nightPrice:this.Price,
      freePlaces:this.FreePlaces,
      pictures:this.response.dbPath

    };

    if(confirm("Do you want to update new hotel?")){
      this.service.PutHotels(val).subscribe(data=>{
        alert(data.toString());
      })
    }

  }
  else{
    var val1 = {

      id:this.Id,
      tourId:this.TourId,
      hotel_Name:this.Hotel,
      descrip:this.Description,
      nightPrice:this.Price,
      freePlaces:this.FreePlaces,
      pictures:this.PhotoPath

    };
    if(confirm("Do you want to update new hotel?")){
      this.service.PutHotels(val1).subscribe(data=>{
        alert(data.toString());
      })
    }
  }
  }

  public uploadFinished=(event: { dbPath: ""; })=>{

    this.response=event;
    this.IsChoiceOfImage=true;

 }




}
