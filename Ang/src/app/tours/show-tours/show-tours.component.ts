import { Component, OnInit } from '@angular/core';
import { AppComponent } from 'src/app/app.component';
import {SharedService} from 'src/app/shared.service';
import {Router } from '@angular/router';

@Component({
  selector: 'app-show-tours',
  templateUrl: './show-tours.component.html',
  styleUrls: ['./show-tours.component.css']
})
export class ShowToursComponent implements OnInit {

  UserRole:string=localStorage.getItem("Roles");

  constructor(private service:SharedService,private router:Router, private appComp:AppComponent) {


   }


   UserList: any =[];
   user1: any;

public ToursList: any =[];
ModalTitle:string;
ActivateAddEditToursComp:boolean=false;
trs1:any;

tourCountryFilter: string="";
tourNameFilter: string="";
tourListWithoutFilter: any=[];



pic(item:any):string{

return item.pictures;
}


  ngOnInit(): void {

   this.appComp.IsActivated=false;

    if(this.UserRole){
      this.UserRole=localStorage.getItem("Roles").replace(/"/g, "");
      console.log(this.UserRole);
    }
    else{
      this.UserRole=null;
    }


    this.refreshTourList();

    // this.appcomp.Islog=true;
  }


  public onSelect(item: any){

    this.router.navigate(['/hotels',item.id]);
  }


  editClick(item: any){
    this.trs1=item;
    this.ModalTitle="Edit tour";
    this.ActivateAddEditToursComp=true;
  }

  deleteClick(item: any){

     if(confirm("Are you sure?")){

      this.service.deleteTour(item.id).subscribe(data=>{
       alert(data.toString());
       this.refreshTourList();
      })
     }


  }



  closeClick()
    {
      this.ActivateAddEditToursComp=false;
      this.refreshTourList();
    }


   FilterFn(){

    var tourCountryFilter=this.tourCountryFilter;
    var tourNameFilter=this.tourNameFilter;

    this.ToursList = this.tourListWithoutFilter.filter(function (el){
      return el.country.toString().toLowerCase().includes(
        tourCountryFilter.toString().trim().toLowerCase()
      )&&
      el.tour_Name.toString().toLowerCase().includes(
        tourNameFilter.toString().trim().toLowerCase()
      )
  });

  }

  sortResult(prop,asc){
    this.ToursList = this.tourListWithoutFilter.sort(function(a,b){
      if(asc){
          return (a[prop]>b[prop])?1 : ((a[prop]<b[prop]) ?-1 :0);
      }else{
        return (b[prop]>a[prop])?1 : ((b[prop]<a[prop]) ?-1 :0);
      }
    })
  }


    refreshTourList(){
      this.service.getTours().subscribe(data=>{
        this.ToursList=data;
        this.tourListWithoutFilter=data;});
    }













}
