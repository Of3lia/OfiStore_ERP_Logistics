import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { GeneralService } from './general.service';
import { UserModel } from './user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  userData: UserModel;
  userDownloadedData;

  constructor(
    private fb:FormBuilder,
    private http:HttpClient,
    private service: GeneralService
  ) { }

  formModel = this.fb.group({
    UserName:['', Validators.required],
    Email:['', Validators.email],
    FullName:[''],
    Passwords:this.fb.group({
      Password:['', [Validators.required, Validators.minLength(4)]],
      ConfirmPassword:['', Validators.required],
    }, {validator : this.comparePasswords})
  });

  comparePasswords(fb:FormGroup){
    let confirmPasswordControl = fb.get('ConfirmPassword');
    // Password Mismatch
    if(confirmPasswordControl.errors == null || 'passwordMismatch' in confirmPasswordControl.errors){
      if(fb.get('Password').value != confirmPasswordControl.value){
        confirmPasswordControl.setErrors({passwordMismatch: true});
      }else{
        confirmPasswordControl.setErrors(null);
      }
    }
  }

  register(){
    var body = {
      UserName: this.formModel.value.UserName,
      Email: this.formModel.value.Email,
      FullName: this.formModel.value.FullName,
      Password: this.formModel.value.Passwords.Password,
    };
    return this.http.post(this.service.BaseURI + '/ApplicationUser/Register', body);
  }

  login(formData){
    return this.http.post(this.service.BaseURI + '/ApplicationUser/Login', formData);
  }

  getUserProfile(){
    return this.http.get(this.service.BaseURI + '/UserProfile');
  }

  putUser(){
    return this.http.put(this.service.BaseURI + "/users", this.userData);
  }

  roleMatch(allowedRoles): boolean {
    var isMatch = false;
    var payLoad = JSON.parse(window.atob(localStorage.getItem('token').split('.')[1]));
    var userRole = payLoad.role;
    allowedRoles.forEach(element => {
      if(userRole == element) {
        isMatch = true;
        return false;
      }
    });
    return isMatch;
  }
}
