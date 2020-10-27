import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { UserModel } from './models/user.model';
import { GeneralService } from './general.service';
import { AddressModel } from './models/address.model';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  userData: UserModel = new UserModel;
  userDownloadedData;
  address:AddressModel;

  constructor(
    public fb:FormBuilder,
    private http:HttpClient,
    private generalService:GeneralService,
  ) { }

  formModel = this.fb.group({
    userName:['', Validators.required],
    email:['', Validators.email],
    fullName:[''],
  });

  getUserProfile(){
    return this.http.get(this.generalService.BaseURI + '/UserProfile');
  }

  putUser(){
    var body = {
      id : this.userDownloadedData.id,
      userName : this.formModel.value.userName,
      fullName : this.formModel.value.fullName,
      email : this.formModel.value.email,
    }
    return this.http.put(this.generalService.BaseURI + "/users", body);
  }

  // Address

  putAddress(){
    return this.http.put(this.generalService.BaseURI + "/addresses/" + this.address.id , this.address);
  }

  // Admin-Panel

  editUser(user:UserModel){
    var body = {
      id : user.id,
      userName : user.userName,
      fullName : user.fullName,
      email : user.email,
      role: user.role,
    }
    return this.http.put(this.generalService.BaseURI + "/users", body);
  }

  deleteUser(id:string){
    window.alert(id);
    return this.http.delete(this.generalService.BaseURI + "/users/" + id);
  }

}
