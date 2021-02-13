import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { SharedService } from 'src/app/shared.service';
import {AppComponent} from 'src/app/app.component';
import * as alertify from 'alertifyjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  Role: any[];
  RoleName: string;


  constructor(private service:SharedService,private fb:FormBuilder,private appcomp: AppComponent ) { }

  registrationForm: FormGroup;
  user: any={};


  @Input() check:any;


  Id:number;
  Login:string;
  emailAddress:string;
  Password:string;
  CFPassword:string;

  UserList: any =[];
  user1: any;

  ngOnInit(): void {

    // здесь убирать home page не нужно, так как это модуль, а он как раз на home page

      this.check=0;


    this.createRegistrationForm();
    this.registrationForm.reset();


  }


  createRegistrationForm(){

    this.registrationForm=this.fb.group(
      {
         userLogin: [null,Validators.required],
         userEmail: [null,[Validators.required, Validators.email]],
         userPassword: [null,[Validators.required, Validators.minLength(8)]],
         CFPassword: [null, [Validators.required]]
      },
      {validators: this.passwordMatchingValidatior});


  }




  passwordMatchingValidatior(fg: FormGroup): Validators {
    return fg.get('userPassword').value === fg.get('CFPassword').value ? null :
    {notmatched: true};
  }


  get userLogin1() {
    return this.registrationForm.get('userLogin') as FormControl;
  }

  get userEmail1() {
    return this.registrationForm.get('userEmail') as FormControl;
  }

  get userPassword1() {
    return this.registrationForm.get('userPassword') as FormControl;
  }

  get userCFpassword() {
    return this.registrationForm.get('CFPassword') as FormControl;
  }




  async SignIn(){

    this.UserList=await this.service.getUsers();
    this.Role=await this.service.GetRoles();



      let UserArray=[];
      UserArray=this.UserList;



      this.user1=UserArray.find(p=>p.email===this.registrationForm.get('userEmail').value);

      if(this.user1)
      this.RoleName=this.Role.find(p=>p.id==this.user1.roleId).roleName;
      else
      this.user1=null;


      if(this.user1){

        var val = {
          login:this.user1.login,
          email:this.user1.email,
          id:this.user1.id,
          password:this.user1.password,
          status:this.user1.status,
          roleId:this.user1.roleId
        };


      localStorage.setItem('Users',JSON.stringify(val.login));
      localStorage.setItem('Roles',JSON.stringify(this.RoleName));
      alertify.success("Log in successful!");
      }
     else{

      alertify.error("Log in failed!");

     }




  }







  AlreadyExisted(){
    this.registrationForm.reset();
    this.check=0;

  }



  SignUp(){
    this.registrationForm.reset();
    this.check=1;
  }


  CreateAccount(){
    if(this.registrationForm.valid){

      var val = {
        login:this.registrationForm.get('userLogin').value,
        email:this.registrationForm.get('userEmail').value,
        password:this.registrationForm.get('userPassword').value,
        status:false,
        roleId:2 //default all are ordinary clients
      };
      if(confirm("Have you checked the input data?")){
      this.service.PostUser(val).subscribe(data=>{
        alert(data.toString());
      })
    }
    alertify.success("Sign up is successful");
    this.registrationForm.reset();
    }
    else{
      alertify.console.error("Kindly, provide the correct input");




    }

  }











}
