import { Component, OnInit, ViewChild } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import {MatTableDataSource} from  '@angular/material/table'
import { TabsetComponent } from 'ngx-bootstrap/tabs';
import { MatIconModule } from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import { Router } from '@angular/router';
import { AppComponent } from 'src/app/app.component';



@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})




export class ProfileComponent implements OnInit {

  @ViewChild('formTabs') formTabs: TabsetComponent;


  displayedColumns:string[] = ['id', 'airLineId',
  'number_of_people','number_of_days','sum','roomNumberId','isBooked','touristId','action'];

  dataSource: any=[];
  User: any;



  Login:string;
  Password:string;
  Email:string;

  FIO:string;
  Sex:string;
  Birth:string;
  Series:string;
  PNumber:string;
  UserDataObj: any;



  ModalTitle: string;
  ActivateAddEditUserInf: boolean;
  trs1: any;

  check: number;
  User_Id:number;


  constructor(private service:SharedService,private router:Router, private appComp:AppComponent) { }

  ngOnInit(): void {

    this.appComp.IsActivated=false;

    this.LoadHotelRooms();

  }

  async LoadHotelRooms(){

    this.User=await this.service.GetUsersByLogin(localStorage.getItem('Users').replace(/"/g, ""));

    this.Login=this.User.login;
    this.Password=this.User.password;
    this.Email=this.User.email;

    this.UserDataObj=await this.service.GetuserData(this.User.id);

    if(this.UserDataObj){

      this.FIO=this.UserDataObj.fio;
      this.Sex=this.UserDataObj.sex;
      this.Birth=this.UserDataObj.birth;
      this.Series=this.UserDataObj.series;
      this.PNumber=this.UserDataObj.pNumber;

    }

      console.log(this.User.id)
      this.dataSource=await this.service.GetBooking(this.User.id);

      if(this.dataSource){
        console.log("dataSource not null");
      }
      else{
        console.log("dataSource null");
      }




  }

  ReturnBook(val:any){


    if(confirm("Are you sure?")){
      console.log("Status "+val.status+" "+"boookingId "+val.bookingId)
      val.status=0; // on return
      this.service.PutBooking(val).subscribe(data=>{
       alert(data.toString());
      })
     }

  }

  editClick1(val:number){

    if(val==1){
      this.check=1;
      this.ModalTitle="Edit log in information"
      this.trs1=this.User;
    }
    else{
      this.check=2;
      this.ModalTitle="Edit personal information"
      if(this.UserDataObj)
      this.trs1=this.UserDataObj;
      else{
        this.trs1=null;
        this.User_Id=this.User.id;
      }



    }

    this.ActivateAddEditUserInf=true;

  }

  closeClick()
  {
    this.ActivateAddEditUserInf=false;

  }

  DeleteUser(){

    if(confirm("Are you sure?")){

      this.service.DeleteUsers(this.User.id).subscribe(data=>{
        alert(data.toString());
        this.router.navigate(['/tours']);
        return localStorage.removeItem('Users'),localStorage.removeItem('Roles');;

      })

    }

  }




}
