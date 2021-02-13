import { Component, OnInit } from '@angular/core';
import { AppComponent } from 'src/app/app.component';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-adminusers',
  templateUrl: './adminusers.component.html',
  styleUrls: ['./adminusers.component.css']
})
export class AdminusersComponent implements OnInit {

  displayedColumns:string[] = ['id','login','email','password','status','roleId','actions'];

  dataSource: any=[];
  Roleslist: any=[];
  IsAdmin:boolean;

  constructor(private service:SharedService, private appComp:AppComponent) { }

  ngOnInit(): void {

    this.appComp.IsActivated=false;

    this.LoadBookList();
  }


  async LoadBookList(){

    this.Roleslist=await this.service.GetRoles();

    this.dataSource=await this.service.getUsers();

}

Confirm(val:any){ // и для обновления и для  подтверждения

  if(confirm("Do you want to confirm the user in the system?")){

    val.status=true;
    this.service.updateUser(val).subscribe(data=>{
      alert(data.toString());
    })

  }


}


onChangeRoleId(roleId:number, val:any){

  val.roleId=roleId;
}


Delete(val:number){

  if(confirm("Do you want to delete the user?")){

    this.service.DeleteUsers(val).subscribe(data=>{
      alert(data.toString());
    })

  }
}


addUser(){

  this.IsAdmin=true;

}



}
