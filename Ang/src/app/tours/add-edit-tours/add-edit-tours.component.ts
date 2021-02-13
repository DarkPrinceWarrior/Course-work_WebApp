import { Component, Input, OnInit,Output, EventEmitter } from '@angular/core';
import {SharedService} from 'src/app/shared.service';
import { HttpEventType, HttpClient } from '@angular/common/http';
import * as alertify from 'alertifyjs';
import {ActivatedRoute} from '@angular/router';
import {Router} from '@angular/router';
import { Location } from '@angular/common';
import { AppComponent } from 'src/app/app.component';

@Component({
  selector: 'app-add-edit-tours',
  templateUrl: './add-edit-tours.component.html',
  styleUrls: ['./add-edit-tours.component.css']
})
export class AddEditToursComponent implements OnInit {

  constructor(private service:SharedService,
     private router:ActivatedRoute, private rout:Router,
     private location: Location, private appComp:AppComponent) {


   }

  // данные записываются
  TourId:string;
  Country:string;
  City:string;
  TourName:string;
  Description:string;
  PhotoPath: string;
  public check: number;




  public response:{dbPath:''}

  IsChoiceOfImage: boolean=false;

  cancel() {
    this.location.back(); // <-- go back to previous location on cancel
  }


  ngOnInit(): void {
    this.appComp.IsActivated=false;
  }


  onBack(){

     this.rout.navigate(['/tours']);
  }



  addTour(){
    var val = {
      country:this.Country,
      city:this.City,
      tour_Name:this.TourName,
      descrip:this.Description,
      pictures:this.response.dbPath
    };
    if(confirm("Do you want to add new tour?")){
    this.service.PostTour(val).subscribe(data=>{
      alert(data.toString());
    })
  }
  }





  public uploadFinished=(event: { dbPath: ""; })=>{

    this.response=event;

 }



}
