import { Component, OnInit, ViewChild } from '@angular/core';
import { TabsetComponent } from 'ngx-bootstrap/tabs';
import { AppComponent } from '../app.component';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-airline',
  templateUrl: './airline.component.html',
  styleUrls: ['./airline.component.css']
})
export class AirlineComponent implements OnInit {



  displayedColumns:string[] = ['id', 'airLineName',
  'theSum','airCompId','cityBoardingId','cityLandingId','actions'];

  dataSource: any=[];
  ModalTitle:string;
  trs1: any;
  Adding: boolean;
  ActivatedEditAdd:boolean;

  constructor(private service:SharedService,private appComp:AppComponent) { }

  ngOnInit(): void {

    this.appComp.IsActivated=false;

    this.LoadInformation();
  }


  async LoadInformation(){

    this.dataSource=await this.service.GetAllAirLines();

  }


  addFlight(){

   this.ModalTitle="Adding flight";
   this.Adding=true;
   this.ActivatedEditAdd=true;
   this.trs1=null;



  }

  CloseClick(){

    this.ActivatedEditAdd=false;
  }


  ChangeFlight(val:any){

    this.ModalTitle="Edit flight";
    this.trs1=val;
    this.Adding=false;
    this.ActivatedEditAdd=true;


  }


  RemoveFlight(val:number){

    if(confirm("Do you want to delete flight?")){
      this.service.DeleteFlight(val).subscribe(data=>{
        alert(data.toString());
      })
    }


  }





}
