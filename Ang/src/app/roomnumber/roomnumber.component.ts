import { Component, OnInit } from '@angular/core';
import { AppComponent } from '../app.component';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-roomnumber',
  templateUrl: './roomnumber.component.html',
  styleUrls: ['./roomnumber.component.css']
})
export class RoomnumberComponent implements OnInit {

  displayedColumns:string[] = ['id', 'roomNumber',
  'isReserved','roomSum','roomTypeId','hotelId','actions'];

  dataSource: any=[];
  ModalTitle:string;
  trs1: any;
  Adding: boolean;
  ActivatedEditAdd:boolean;


  constructor(private service:SharedService, private appComp:AppComponent) { }

  ngOnInit(): void {

    this.appComp.IsActivated=false;

    this.LoadInformation();
  }

  async LoadInformation(){

    this.dataSource=await this.service.GetAllRooms();

  }

  addRoom(){

    this.ModalTitle="Adding room";
    this.Adding=true;
    this.ActivatedEditAdd=true;
    this.trs1=null;
  }

  CloseClick(){

    this.ActivatedEditAdd=false;
  }


  ChangeRoom(val:any){

    this.ModalTitle="Edit room";
    this.trs1=val;
    this.Adding=false;
    this.ActivatedEditAdd=true;
  }

  RemoveRoom(val:number){

    if(confirm("Do you want to delete room?")){
      this.service.deleteRoom(val).subscribe(data=>{
        alert(data.toString());
      })
    }

  }

}
