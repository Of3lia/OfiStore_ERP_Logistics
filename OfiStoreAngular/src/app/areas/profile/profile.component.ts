import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from './../../shared/user.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styles: [
  ]
})
export class ProfileComponent implements OnInit {

  userDetails;
  edit : boolean = false;
  _editAddress:boolean = false;
  userData: UserModel;
  address: AddressModel;

  constructor(
    private router:Router,
    private service:UserService,
    private http: HttpClient
  ) { }

  ngOnInit(): void {
    this.service.getUserProfile().subscribe(
      res => { 
        this.userDetails = res;
        this.address = this.userDetails.address;
      },
      err => {
        console.log(err);
      }
    )
  }

  editProfile(){
    this.userData = this.userDetails;
    this.edit = true;
  }

  cancelEdit(){
    this.edit = false;
  }

  updateProfile(form:NgForm){
    if(form.invalid){
      return;
    }
    this.putProfile().subscribe(
      res => {
        console.log(res);
        window.location.reload();
      },
      err => {
        console.log(err);
      }
    )
  }

  putProfile(){
    console.log(this.userData);
    return this.http.put(this.service.BaseURI + "/users", this.userData);
  }

  //Address
  
  editAddress(){
    this.userData = this.userDetails;
    this._editAddress = true;
  }

  updateAddress(form:NgForm){
    if(form.invalid){
      return;
    }
    this.putAddress().subscribe(
      res => {
        console.log(res);
        window.location.reload();
      },
      err => {
        console.log(err);
      }
    )
  }

  putAddress(){
    return this.http.put(this.service.BaseURI + "/addresses/" + this.address.id , this.address);
  }
}

class UserModel{
  id:string = '';
  userName: string = '';
  fullName?: string = '';
  email?:string = '';
  address: AddressModel = {
    id : '',
    street : '',
    streetNumber : undefined,
    door : '',
    city : '',
    country : '',
    postalCode : '',
  };
}

class AddressModel{
  id:string = '';
  street?: string = '';
  streetNumber?: number = undefined;
  door?:string = '';
  city?:string = '';
  country?:string = '';
  postalCode?:string = '';
}