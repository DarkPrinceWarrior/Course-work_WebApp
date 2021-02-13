import { Component } from '@angular/core';
import { SharedService } from './shared.service';
import * as alertify from 'alertifyjs';
import {AddEditToursComponent} from './tours/add-edit-tours/add-edit-tours.component';
import {Router} from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Ang';

  UserRole=localStorage.getItem("Roles");


  public Islog: boolean=false;
  public loggedInUser:string;
  public IsActivated: boolean=true;



  constructor(private service:SharedService, private router:Router) {

    if(this.UserRole){
      this.UserRole=localStorage.getItem("Roles").replace(/"/g, "");
      console.log(this.UserRole);
    }
    else{
      this.UserRole=null;
    }

  }




  Islogged(){
    this.loggedInUser=localStorage.getItem('Users');
    if(this.loggedInUser){
      this.loggedInUser = this.loggedInUser.replace(/"/g, ""); //delete all quotation marks
    }
    return this.loggedInUser;
  }





  onLogout(){
    this.IsActivated=true;
    alertify.success("Log out successful!")
    this.router.navigate(['']); // redirect to home page
    return localStorage.removeItem('Users'),localStorage.removeItem('Roles');



  }

onClickLink(val:boolean){

  this.IsActivated=val;
}


}
