import { Component, Input, OnInit } from '@angular/core';
import { AppComponent } from 'src/app/app.component';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit {


  BirthString: string;


  constructor(private service:SharedService, private appComp:AppComponent) { }

  @Input() trs1:any;
  @Input() check:number;
  @Input() User_Id:number;


  //UserData
  FIO:string;
  Gender:string;
  Birth:Date;
  Series:string;
  PNumber:string;
  UserId:number;

  //UserLogin
  Login:string;
  Password:string;
  Email:string;
  Status:boolean;
  RoleId:number;




  ngOnInit(): void {

    this.appComp.IsActivated=false;

    this.loaduser();


  }


  loaduser(){

    console.log("check: "+this.check);

    if(this.trs1!=null){

      if(this.check==2){
        console.log("trs1 not null");

        this.FIO=this.trs1.fio;
        this.Gender=this.trs1.sex;
        this.Birth=new Date(this.trs1.birth);
        this.Series=this.trs1.series;
        this.PNumber=this.trs1.pNumber;
        this.UserId=this.trs1.userId;


      }
      else{
        console.log("trs1 not null")

        this.Login=this.trs1.login;
        this.Email=this.trs1.email;
        this.Password=this.trs1.password;
        this.Status=this.trs1.status;
        this.RoleId=this.trs1.roleId;


      }


    }
    else{
      console.log("trs1 null");
      console.log("userId :"+this.User_Id);



    }
  }




  updateUser1(){

    if(this.check==1){

      var val1={

        id:this.trs1.id,
        login:this.Login,
        email:this.Email,
        password:this.Password,
        status:this.Status,
        roleId:this.RoleId



      }

      if(confirm("Do you want to update?")){
        this.service.updateUser(val1).subscribe(res=>{
        alert(res.toString());
        // return localStorage.removeItem('Users');
        localStorage.setItem('Users',JSON.stringify(val1.login));
        })}


    }
    else{

      this.BirthString=(this.Birth.getMonth()+1).toString()+"/";
      this.BirthString+=this.Birth.getDate().toString()+"/";
      this.BirthString+=this.Birth.getFullYear().toString();

      var val2={

        id:this.trs1.id,
        fio:this.FIO,
        sex:this.Gender,
        birth: this.BirthString,
        series:this.Series,
        pNumber:this.PNumber,
        userId:this.UserId

      }

      if(confirm("Do you want to update?")){
        this.service.PutUserData(val2).subscribe(res=>{
        alert(res.toString());
        })}



    }


  }

   addUserData(){

    this.BirthString=(this.Birth.getMonth()+1).toString()+"/";
    this.BirthString+=this.Birth.getDate().toString()+"/";
    this.BirthString+=this.Birth.getFullYear().toString();

    var val2={

      fio:this.FIO,
      sex:this.Gender,
      birth: this.BirthString,
      series:this.Series,
      pNumber:this.PNumber,
      userId:this.User_Id

    }

    if(confirm("Do you want to add this information?")){
      this.service.PostUserData(val2).subscribe(res=>{
      alert(res.toString());
      })}


   }



}
