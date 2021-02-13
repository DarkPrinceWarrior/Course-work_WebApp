import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { SharedService } from 'src/app/shared.service';
import * as alertify from 'alertifyjs';
import { AppComponent } from 'src/app/app.component';

@Component({
  selector: 'app-admin-login',
  templateUrl: './admin-login.component.html',
  styleUrls: ['./admin-login.component.css']
})
export class AdminLoginComponent implements OnInit {

  constructor(private service:SharedService,private fb:FormBuilder, private appComp:AppComponent) { }

  registrationForm: FormGroup;

  ngOnInit(): void {

    this.appComp.IsActivated=false;

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
    alertify.success("User Created!");
    this.registrationForm.reset();
    }
    else{
      alertify.console.error("Kindly, provide the correct input");




    }

  }


}
