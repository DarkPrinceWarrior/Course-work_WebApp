import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AppComponent } from 'src/app/app.component';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-edit-add-tours',
  templateUrl: './edit-add-tours.component.html',
  styleUrls: ['./edit-add-tours.component.css']
})
export class EditAddToursComponent implements OnInit {

  constructor(private service:SharedService, private router:ActivatedRoute, private appComp:AppComponent) { }

  @Input() trs1:any;
  // данные записываются
  TourId:string;
  Country:string;
  City:string;
  TourName:string;
  Description:string;
  PhotoPath: string;
  public check: number;


  TourList: any =[];
  public response:{dbPath:''}

  IsChoiceOfImage: boolean=false;

  ngOnInit(): void {

    this.appComp.IsActivated=false;

    this.loadTourList();
    // let id =parseInt(this.router.params('id'));
    //  this.check=id;


  }
  loadTourList(){

    if(this.trs1!=null){
      this.TourId=this.trs1.id;
      this.Country=this.trs1.country;
      this.City=this.trs1.city;
      this.TourName=this.trs1.tour_Name;
      this.Description=this.trs1.descrip;
      this.PhotoPath=this.trs1.pictures;

    }
    else{
      this.Country="";
      this.City="";
      this.TourName="";
      this.Description="";
      this.PhotoPath="";

    }

  }




  updateTour(){

     if(this.IsChoiceOfImage){

      var val = {
        id:this.TourId,
        country:this.Country,
        city:this.City,
        tour_Name:this.TourName,
        descrip:this.Description,
        pictures:this.response.dbPath
      };

      if(confirm("Do you want to update this tour?")){
        this.service.updateTour1(val).subscribe(res=>{
        alert(res.toString());
        })
      }

     }
     else{

      var val1 = {
        id:this.TourId,
        country:this.Country,
        city:this.City,
        tour_Name:this.TourName,
        descrip:this.Description,
        pictures:this.PhotoPath
      };

      if(confirm("Do you want to update this tour?")){
        this.service.updateTour1(val1).subscribe(res=>{
        alert(res.toString());
        })
      }

     }

    }




  public uploadFinished=(event: { dbPath: ""; })=>{

    this.response=event;
    this.IsChoiceOfImage=true;
 }




}
