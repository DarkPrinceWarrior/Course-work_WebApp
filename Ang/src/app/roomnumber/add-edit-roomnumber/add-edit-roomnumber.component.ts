import { Component, Input, OnInit } from '@angular/core';
import { AppComponent } from 'src/app/app.component';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-roomnumber',
  templateUrl: './add-edit-roomnumber.component.html',
  styleUrls: ['./add-edit-roomnumber.component.css']
})
export class AddEditRoomnumberComponent implements OnInit {

  @Input() Adding:boolean;
  @Input() trs1:any;

  HotelList: any[];
  RoomClassList: any[];

  constructor(private service:SharedService, private appComp:AppComponent) { }



  Id:number;
  RoomNumber:string;
  RoomSum:string;

  //checkbox
  IsReserved:boolean=false;

  //dropdown
  RoomTypeId:number;
  hotelId:number;




  ngOnInit(): void {

    this.appComp.IsActivated=false;

    if(this.trs1!=null){

      console.log("not null");

      this.Id=this.trs1.id;
      this.RoomNumber=this.trs1.roomNumber;
      this.RoomSum=this.trs1.roomSum;
      this.IsReserved=this.trs1.isReserved;
      this.RoomTypeId=this.trs1.roomTypeId;
      this.hotelId=this.trs1.hotelId;

    }
    else{
      console.log("null");
    }



    this.LoadData();


  }

  async LoadData(){

    // this.HotelList=await this.service.GetAirComp();

   this.service.getHotels(1,false).subscribe(data=>{ //по другому муторно((
      this.HotelList=data;
       });

    this.service.GethotelRoom().subscribe(data=>{
      this.RoomClassList=data;
       });


  }

  onChangeHotel(val:number){

    this.hotelId=val;

  }

  onChangeRoomClass(val:number){

    this.RoomTypeId=val;

  }



  updateRoom(){

    var val={

      id:this.Id,
      roomNumber:this.RoomNumber,
      roomSum:this.RoomSum,
      isReserved:this.IsReserved,
      roomTypeId:this.RoomTypeId,
      hotelId:this.hotelId


    }

    console.log(val.roomNumber+" "+val.roomSum+" "+val.isReserved
    +" "+val.roomTypeId+" "+val.hotelId);

    if(confirm("Do you want to change it?")){
      this.service.PutRoomNumber(val).subscribe(data=>{
        alert(data.toString());
      })
    }

  }


  addRoom(){

    var val={


      roomNumber:this.RoomNumber,
      roomSum:this.RoomSum,
      isReserved:this.IsReserved,
      roomTypeId:this.RoomTypeId,
      hotelId:this.hotelId


    }
    console.log(val.roomNumber+" "+val.roomSum+" "+val.isReserved
    +" "+val.roomTypeId+" "+val.hotelId);

    if(confirm("Do you want to add?")){
      this.service.PostRoom(val).subscribe(data=>{
        alert(data.toString());
      })
    }
  }



}
