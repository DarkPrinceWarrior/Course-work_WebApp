import { Component, OnInit, ViewChild } from '@angular/core';
import { TabsetComponent } from 'ngx-bootstrap/tabs';
import { SharedService } from '../shared.service';
import { FormBuilder, FormControl, FormGroup,FormArray, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs/internal/Observable';
import { exit } from 'process';
import { analyzeAndValidateNgModules } from '@angular/compiler';
import {DomSanitizer} from '@angular/platform-browser';
import { AppComponent } from '../app.component';






@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.css']
})
export class BookingComponent implements OnInit {

  @ViewChild('formTabs') formTabs: TabsetComponent;



  UserList: any =[];
  UserDataObj: any;
  loggedInUser: string;
  CityBoardObject:any;
  public HotelId1;
  IsChosenFlight: boolean;






  constructor(private service:SharedService,
    private fb:FormBuilder,private route:ActivatedRoute,
     private doms:DomSanitizer, private appComp:AppComponent) {

    let id1=this.route.snapshot.paramMap.get('id');
    this.HotelId1=id1;// для сопосавления номеров с их отелем



   }



   public TourCity: string;

  public HotelRoomList: any[];
  public HotelRoomList2: any[];

  public HotelRoomNumberList: any[];
  public HotelRoomNumberList2: any[];

  public CityBoardList:any[];
  public CityBoardId:number;
  public CityBoardObj:any;

  TourId:number;

  public CityLandObj:any;

  public FlightLIst:any[];
  public FlightLIst2:any[];
  AirCompaniesList:any[];
  public ModalTitle:string="Flight list";

  public HotelObject: any;

  Tourobject:any;
  TourList:any[];


  Data:any;
  Data1:any;

  ngOnInit(): void {

    this.appComp.IsActivated=false;

    this.LoadHotelRooms();
  }

  async LoadHotelRooms(){



       //проверяем пользователя на его существование ранее в БД


         if(this.Data=await this.service.GetUsersByLogin(localStorage.getItem('Users').replace(/"/g, ""))){

          console.log("Data not null");


          this.UserObj=this.Data;
          console.log("userObj");

           //изымаем по id user его данные из userData
          this.UserDataObj=await this.service.GetuserData(this.UserObj.id);

            if(this.UserDataObj!=null){

              console.log("UserDataObj not null");
              this.UserDataId=this.UserDataObj.id;
              this.FIO=this.UserDataObj.fio;

                 if(this.UserDataObj.sex=='Male'){
                  this.SexMale=this.UserDataObj.sex;

                  this.Sex= this.SexMale;
                  console.log("SexMale "+this.SexMale);
                  console.log("Sex "+this.Sex);
                 }
                 else{
                  this.SexFemale=this.UserDataObj.sex;

                  this.Sex= this.SexFemale;
                  console.log("SexFemale "+this.SexFemale);
                  console.log("Sex "+this.Sex);
                 }

                 let newDate = new Date(this.UserDataObj.birth); // обратная конвертация
              this.Birth=newDate;
              this.Series=this.UserDataObj.series;
              this.PNumber=this.UserDataObj.pNumber;
              //  this.UserId уже определен

              }
              else{
                console.log("UserDataObj null");
              }



         }
         else{

          this.Data=null;
          console.log("Data null");

         }


      // if(this.Data){


      // }
      // else{

      //   console.log("Data null");

      // }





///////////////////////////////////////////////
    this.service.GethotelRoom().subscribe(data=>{
      this.HotelRoomList=data;
      });


      this.service.GetroomNumber(this.HotelId1).subscribe(data=>{
        this.HotelRoomNumberList=data;
        });

        this.service.Getcity_From().subscribe(data=>{
          this.CityBoardList=data;
          });


           // find hotel by HotelId
           this.HotelObject=await this.service.GetHotel(this.HotelId1);

             // find tour by TourId
           this.Tourobject=await this.service.getTour(this.HotelObject.tourId);


              this.service.GetcityLanding().subscribe(data=>{
                this.CityLandObj=data;
                });

                this.service.GetAirLines().subscribe(data=>{
                  this.FlightLIst=data;
                  });

                  this.service.GetairCompany().subscribe(data=>{
                    this.AirCompaniesList=data;
                    });

  }


  editClick(item: any){
    // this.trs1=item;
    // this.ModalTitle="Edit tour";
    // this.ActivateAddEditToursComp=true;
  }

  closeClick()
  {
    // this.ActivateAddEditToursComp=false;

  }



   //AirLine
    IsFlight:string;
    DepartureCity:string;
    LanndingCity:string;
    AirLineid:number=null;







    // HotelRoom
    public roomType:number;
    public roomType1:number;
    TheSumforRoom:number;
    TheDefaultSumRoom:number;
    Id:number;


    roomNumber:number;
    isReserved: Boolean;
    roomSum: string;
    hotelId:string;




   //UserData
  FIO: string;
  Sex:string;
  SexMale:string;
  SexFemale:string;


  Birth:Date;
  BirthString:string; //во что должно быть преобрзовано

  Series:string;
  PNumber:string;
  UserObj:any;
  UserDataId:any;

  HotelId: string;
  AirLineId: string;
  PeopleNumber:string;
  DaysNumber:string;
  TheSum:number;
  ClientId:string; //кто бронирует
  IsBooked: boolean=false;

  check1:boolean;
  check2:boolean;
  check3:boolean;
  check4:boolean;
  CheckforAirLineResult:boolean;
  CheckforRoomResult:boolean;
  IsRoomConfirmed:boolean;

  CheckSelectFlight:boolean;

  RoomObject:any=null;







  onChangeRoomType(RoomTypeId: number){

    this.check3=false;
    this.check4=false;
    this.CheckforRoomResult=false;

    if (RoomTypeId) {

      this.roomType=RoomTypeId;
      this.HotelRoomNumberList2=this.HotelRoomNumberList.filter(p=>p.roomTypeId==RoomTypeId && p.isReserved==false);
      this.check3=true;

    } else {
      this.HotelRoomNumberList2 = null;
      this.check3=false;

    }

  }

  onChangeDaysNumber(DaysNum:number){
    this.CheckforRoomResult=false;
    this.check1=false;
    this.check2=false;
    this.check3=false;
    this.check4=false;

    if(DaysNum){
      this.check1=true;

    }

  }
  onChangePeopleNumber(PeopleNum:number){
    this.CheckforRoomResult=false;

    this.check2=false;
    this.HotelRoomList2 = null;
    this.check3=false;
    this.check4=false;
   //поставить лист нулл

    if(PeopleNum){

      this.HotelRoomList2=this.HotelRoomList;
      this.check2=true;

    }
    else{
      this.HotelRoomList2 = null;
      this.check2=false;
    }

  }



  onChangeRoomNumber(RoomNumberId: number){

    if (RoomNumberId) {
      this.CheckforRoomResult=false;
      this.Id=RoomNumberId; // id номера

      this.TheDefaultSumRoom=this.HotelRoomNumberList2.find(p=>p.id==RoomNumberId).roomSum;

      if(parseInt(this.PeopleNumber)>2){ //uprise on 30%


        console.log("Default sum "+this.TheDefaultSumRoom);
        this.TheSumforRoom= this.TheDefaultSumRoom*1.3*parseInt(this.DaysNumber);
        console.log(this.TheSumforRoom);

      }
      else
      this.TheSumforRoom=this.TheDefaultSumRoom*parseInt(this.DaysNumber);


      this.roomNumber=this.HotelRoomNumberList2.find(p=>p.id==RoomNumberId).roomNumber;
      this.check4=true;

      this.CheckforRoomResult=true;

    }
    else{
      this.CheckforRoomResult=false;
      this.check4=false;


    }


  }


  onChangeIsFlight(){

      this.IsChosenFlight=false;
      this.CheckSelectFlight=false;
      this.CheckforAirLineResult=false;
      this.AirLineid=null;
      console.log(this.AirLineid);

  }






  onChangeDepartureCity(Departure_City:string){



    if(Departure_City){


      this.IsChosenFlight=false;
      this.CheckforAirLineResult=false;

      this.DepartureCity=Departure_City;

    this.CheckSelectFlight=false;


         let id=this.CityBoardList.find(p=>p.city===Departure_City).id;
         this.CityBoardId=id;

      //sort by departure city
      this.FlightLIst2=this.FlightLIst.filter(p=>p.cityBoardingId==this.CityBoardId);

        // this.Tourobject=this.TourList.find(p=>p.id==this.HotelObject.tourId);

               let city=this.Tourobject.city;
               this.LanndingCity=this.Tourobject.city;

              //  if(this.Tourobject==null)
              //  console.log("null");
              //  else{
              //   console.log("not null");

              //  }

               //the city where we go

               console.log(city);

             if(this.CityLandObj==null)
               console.log("null");
               else{
                console.log("not null");

               }
             let CityId=this.CityLandObj.find(p=>p.city==city).id;

             console.log("id города, куда летим "+CityId);

       this.FlightLIst2=this.FlightLIst2.filter(p=>p.cityLandingId==CityId);


        this.CheckSelectFlight=true;
    }
    else{
      this.IsChosenFlight=false;
      this.CheckforAirLineResult=false;
      this.CheckSelectFlight=false;
    }


  }



  getFlightInf(){

    if(this.FlightLIst2!=null && this.CheckforAirLineResult){


      let FlightObject=this.FlightLIst.find(p=>p.id==this.AirLineid);

      return  this.doms.bypassSecurityTrustHtml("Flight - "+FlightObject.airLineName
      +"<br>"+"Aircompany - "+this.AirLineName(FlightObject.airCompId)+"<br>"+"Departure city - "+this.DepartureCity
      +"<br>"+"City of arrival - "+this.LanndingCity);
    }
    else{

      return "There is no data!"

    }



  }

  getFinalSum(){

    if(this.CheckforRoomResult && this.CheckforAirLineResult){
     return this.TheSumforRoom+this.getMoneyForFlight();
    }
    if(this.CheckforRoomResult && !this.CheckforAirLineResult){
      return this.TheSumforRoom;
    }
    if(!this.CheckforRoomResult && this.CheckforAirLineResult){
      return this.getMoneyForFlight();
    }
    if(!this.CheckforRoomResult && !this.CheckforAirLineResult)
       return "Still not counted!"
  }



  getRoomInf(){

    if(this.CheckforRoomResult){

     return this.doms.bypassSecurityTrustHtml("Room Type -"+this.HotelRoomList.find(p=>p.id==this.roomType).roomType
     +"<br>"+"Room Number -"+this.roomNumber
     +"<br>"+"Number of people -"+this.PeopleNumber+"<br>"+"Number of days -"+this.DaysNumber);
    }
    else{

     return "There is no data!"

    }

   }


  getTourInf(){

    //retrieve tour inforamtion for result list

    if(this.Tourobject!=null){
      return this.doms.bypassSecurityTrustHtml("Country - "+
     this.Tourobject.country+"<br>"+"City - "+
      this.Tourobject.city+"<br>"+"Tour - "+
      this.Tourobject.tour_Name);
    }
    else
    return "There is no data!";

  }

  getHotelInf(){

    //retrieve hotel inforamtion for result list

    if(this.HotelObject!=null){
      return this.doms.bypassSecurityTrustHtml("Hotel - "+this.HotelObject.hotel_Name
      +"<br>"+"Description - "+this.HotelObject.descrip);
    }
    else
    return "There is no data!";

  }



  AirLineName(AirCompid:number){

    return this.AirCompaniesList.find(p=>p.id==AirCompid).airCompName;

  }



  getMoneyForFlight(){

    if(this.FlightLIst2)
    return this.FlightLIst2.find(p=>p.id==this.AirLineid).theSum;
    else
    return null;
  }

  onChangeFlightList(AirLineId:number){

    if(AirLineId){
      this.IsChosenFlight=false;
      this.AirLineid=AirLineId;
      console.log("this is AirLineId "+this.AirLineid)
      this.IsChosenFlight=true;
      this.CheckforAirLineResult=true;
      console.log(this.AirLineid);




    }
   else{

    this.CheckforAirLineResult=false;
       this.IsChosenFlight=false;
       console.log("AirlineId is null")
   }


  }



  onChangeGender(val:any, num:number){

      if(val){

      if(num==1){

        this.SexFemale=null;
        this.SexMale="Male";

        console.log(val+" "+"this.SexFemale"+"= "+this.SexFemale);

      }
      else{

        this.SexMale=null;
        this.SexFemale="Female";
         console.log(val+" "+"this.SexMale"+"= "+this.SexMale);
      }


      }

  }

  ConfirmOrChange(){

  //если мы хотим перейти на форму после заполнения личных данных


    this.BirthString=(this.Birth.getMonth()+1).toString()+"/";
    this.BirthString+=this.Birth.getDate().toString()+"/";
    this.BirthString+=this.Birth.getFullYear().toString();

   //  console.log(this.UserObj.id); //checking for UserId in User table

   if(this.SexMale!=null){
    this.Sex=this.SexMale;
    console.log(this.Sex);
   }
   else{
     this.Sex=this.SexFemale;
     console.log(this.Sex);
   }





     if(this.UserDataObj!=null){
       //если пользователь уже что-то бронировал, то его данные (возможно, в случае изменения) тоже заносятся в БД
       console.log("UserDataObj not null ");

       var val = {

         id:this.UserDataObj.id,
         fio:this.FIO,
         sex:this.Sex,
         birth: this.BirthString,
         series:this.Series,
         pNumber:this.PNumber,
         userId: this.UserObj.id

       };

       console.log(val.id+" "+val.fio+" "+val.sex+" "+
       val.birth+" "+val.series+" "+val.pNumber+" "+val.userId);

       if(confirm("Do you want to confirm your changes "+val.fio+ "?")){
         this.service.PutUserData(val).subscribe(data=>{
           alert(data.toString());
         })


     }

     }
     else{

          //если пользователь впервый раз бронирует, то его данные заносятся в БД
       console.log("UserDataObj null ");

       var val1 = {


         fio:this.FIO,
         sex:this.Sex,
         birth: this.BirthString,
         series:this.Series,
         pNumber:this.PNumber,
         userId: this.UserObj.id

       };

       console.log(val1.fio+" "+val1.sex+" "+
       val1.birth+" "+val1.series+" "+val1.pNumber+" "+val1.userId);

       if(confirm("Do you want to confirm your data?")){
         this.service.PostUserData(val1).subscribe(data=>{
           alert(data.toString());
         })


     }

    }

  }



  selectTab(tabId:number, move:number){


    this.formTabs.tabs[tabId].active=true;

    if(tabId==2){

         // если мы переходим на форму выбора авиарейса
         console.log(this.Id);
         // по roomId находим комнату и ставим в поле IsReserved = true

     // checking the data
      console.log(this.Id+" "+this.roomType
      +" "+this.roomNumber+" "+this.TheSumforRoom+" "+this.HotelId1);

         this.formTabs.tabs[tabId].active=true;

    }
  }




  ConfirmRoom(){

      if(this.RoomObject!=null){
console.log(this.RoomObject.id+" "+
    this.RoomObject.roomTypeId+" "+this.RoomObject.roomNumber+" "+this.RoomObject.roomSum);
      }


    if(confirm("Do you want to confirm the room?")){


      this.RoomObject = {

        id:this.Id,
        roomTypeId:this.roomType,
        roomNumber:this.roomNumber,
        isReserved:true,
        roomSum:this.TheDefaultSumRoom,
        hotelId:this.HotelId1 // прогружается в начале. поэтому то объект по умолчанию не нулл


      };

      console.log(this.RoomObject.id+" "+
    this.RoomObject.roomTypeId+" "+this.RoomObject.roomNumber+" "+this.RoomObject.roomSum);

    if(this.RoomObject && this.RoomObject.id!=null){
       console.log(this.RoomObject.id);
      console.log("RoomObject is not null");
      this.service.PutRoomNumber(this.RoomObject).subscribe(data=>{
        alert(data.toString());
      })
      this.IsRoomConfirmed=true;
    }
    else{
      console.log("Nothing is to be confirmed");
    }
  }
  }

  CanclelRoom(){

    if(confirm("Do you want to cacncel the confirmation?")){
    if(this.RoomObject && this.RoomObject.id!=null){
      this.CheckforRoomResult=false;
      this.RoomObject.isReserved=false;

      this.service.PutRoomNumber(this.RoomObject).subscribe(data=>{
        alert(data.toString());
      })
      this.IsRoomConfirmed=false;
      this.RoomObject=null;
      this.Id=null;
    }
    else{
      this.Id=null;
      // this.RoomObject=null;
      this.CheckforRoomResult=false;
      console.log("Nothing is to be canceled");
    }
  }
  }




  BookTour(){

   var BookObject={

    airLineId: this.AirLineid,
    number_of_people: this.PeopleNumber,
    number_of_days:this.DaysNumber,
    sum:this.getFinalSum(),
    roomNumberId:  this.RoomObject.id,
    touristId:this.UserObj.id,
    isBooked: false,
    status:1 // on confirm



   }


      console.log("Booking inf -- "+
      BookObject.airLineId+" "+BookObject.number_of_people+" "+BookObject.number_of_people+" "+
      BookObject.sum+" "+"id Номера  "+BookObject.roomNumberId+" "+BookObject.touristId
      +" "+BookObject.isBooked+" "+BookObject.status);


       if(BookObject && this.IsRoomConfirmed){
         if(confirm("Do you want to book the tour?")){
          // BookObject.roomNumberId=this.Id;
          console.log("id Номера  "+BookObject.roomNumberId);
      this.service.PostBooking(BookObject).subscribe(data=>{
      alert(data.toString());
    })

  }
         }
         else{
             console.log("BookObject null - OR - Room is not confirmed")
         }
  }




}
