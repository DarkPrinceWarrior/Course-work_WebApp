import { Component, OnInit } from '@angular/core';
import { from } from 'rxjs';
import { AppComponent } from 'src/app/app.component';
import {SharedService} from 'src/app/shared.service';
import {ActivatedRoute} from '@angular/router';
import {Router } from '@angular/router';
import * as alertify from 'alertifyjs';

@Component({
  selector: 'app-show-hotels',
  templateUrl: './show-hotels.component.html',
  styleUrls: ['./show-hotels.component.css']
})
export class ShowHotelsComponent implements OnInit {
  IsUser: string;
  UserObject: any;

  UserRole=localStorage.getItem("Roles");

  constructor(private service:SharedService, private route:ActivatedRoute
    ,private router:Router, private appComp:AppComponent) {


    let id1=this.route.snapshot.paramMap.get('id');
    this.TourId=id1;

   }

   public ToursList: any[];
   public TourId;
    public  trs2: any;
    ModalTitle: string;

   pic(item:any):string{

    return item.pictures;
    }

    IsUserIn(){

      let user=localStorage.getItem('Users');
      if(!user){
        alertify.error("Please, log in to proceed the booking!");
        return false;

      }
      else{

        if(this.UserObject.status)
        {
          return true;
        }
        else
        {
          alertify.error("Please, wait for confirmation to proceed the booking!");
          return false;
        }

      }


    }


   async LoadUser(){

    this.appComp.IsActivated=false;

    if(this.UserRole){
      this.UserRole=localStorage.getItem("Roles").replace(/"/g, "");
      console.log(this.UserRole);
    }
    else{
      this.UserRole=null;
    }

    let user=localStorage.getItem('Users');

    this.UserObject= await this.service.GetUsersByLogin(user.replace(/"/g, ""));
   }



  ngOnInit(): void {

    this.refreshHotelsList();
    this.LoadUser();


  }

  refreshHotelsList(){

    this.service.getHotels(this.TourId,true).subscribe(data=>{
      this.ToursList=data;
      });


  }

  closeClick()
  {

    this.refreshHotelsList();
  }

  editClick(item: any){
    this.trs2=item;
    this.ModalTitle="Edit hotel";

  }


  deleteClick(item: any){

     if(confirm("Are you sure?")){

      this.service.deleteHotel(item.id).subscribe(data=>{
       alert(data.toString());
       this.refreshHotelsList();
      })
     }


  }

  onSelect(item: any){
    if(this.IsUserIn())
    this.router.navigate(['/Booking',item.id]);


  }





}
