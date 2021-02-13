import { Component, Input, OnInit } from '@angular/core';
import { AppComponent } from 'src/app/app.component';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-airline',
  templateUrl: './add-edit-airline.component.html',
  styleUrls: ['./add-edit-airline.component.css']
})
export class AddEditAirlineComponent implements OnInit {

 @Input() Adding:boolean;
 @Input() trs1:any;

  CompanyList: any[];
  BoardingList: any[];
  LandingList: any[];

  constructor(private service:SharedService,private appComp:AppComponent) { }

  Id:number;
  AirLineName:string;
  Sum:string;

  //dropdown
  AirCompId:number;
  CityBoardingId:number;
  CityLandingId:number;




  ngOnInit(): void {

    this.appComp.IsActivated=false;

    if(this.trs1!=null){

      console.log("not null");

      this.Id=this.trs1.id;
      this.AirLineName=this.trs1.airLineName;
      this.Sum=this.trs1.theSum;
      this.AirCompId=this.trs1.airCompId;
      this.CityBoardingId=this.trs1.cityBoardingId;
      this.CityLandingId=this.trs1.cityLandingId;

    }
    else{
      console.log("null");
    }



    this.LoadData();
  }

  async LoadData(){




    this.CompanyList=await this.service.GetAirComp();
    this.LandingList=await this.service.GetCityLand();

   this.service.Getcity_From().subscribe(data=>{
     this.BoardingList=data;
      });


  }


  onChangeCompany(val:number){

    this.AirCompId=val;

  }

  onChangeBoardingCity(val:number){

    this.CityBoardingId=val;

  }

  onChangeLandCity(val:number){


  this.CityLandingId=val;

  }


  updateFlight(){

    var val={

      id:this.Id,
      airLineName:this.AirLineName,
      theSum:this.Sum,
      airCompId:this.AirCompId,
      cityBoardingId:this.CityBoardingId,
      cityLandingId:this.CityLandingId


    }

    console.log(val.airLineName+" "+val.theSum+" "+val.airCompId
    +" "+val.cityBoardingId+" "+val.cityLandingId);

    if(confirm("Do you want to change it?")){
      this.service.PutAirLines(val).subscribe(data=>{
        alert(data.toString());
      })
    }

  }


  addFlight(){

    var val={

      airLineName:this.AirLineName,
      theSum:this.Sum,
      airCompId:this.AirCompId,
      cityBoardingId:this.CityBoardingId,
      cityLandingId:this.CityLandingId


    }
     console.log(val.airLineName+" "+val.theSum+" "+val.airCompId
     +" "+val.cityBoardingId+" "+val.cityLandingId);

    if(confirm("Do you want to add?")){
      this.service.PostAirLines(val).subscribe(data=>{
        alert(data.toString());
      })
    }
  }




}
