import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from './../../shared/user.service';
import { UserModel, AddressModel } from './../../shared/user.model';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styles: [
  ]
})
export class ProfileComponent implements OnInit {

  edit : boolean = false;
 // _editAddress:boolean = false;

  constructor(
    private router:Router,
    private service:UserService,
    private http: HttpClient
  ) { }

  ngOnInit(): void {
    this.service.getUserProfile().subscribe(
      res => { 
        this.service.userDownloadedData = res;
       // this.address = this.userDetails.address;
      },
      err => {
        console.log(err);
      }
    )
  }

  editProfile(){
    //this.userData = this.userDetails;
    this.edit = true;
  }

  cancelEdit(){
    this.edit = false;
  }

  updateProfile(form:NgForm){
    if(form.invalid){
      return;
    }
    this.service.putUser().subscribe(
      res => {
        //console.log(res);
        window.location.reload();
      },
      err => {
        console.log(err);
      }
    )
  }

  //Address
  
  // editAddress(){
  //   this.userData = this.userDetails;
  //   this._editAddress = true;
  // }

  // updateAddress(form:NgForm){
  //   if(form.invalid){
  //     return;
  //   }
  //   this.putAddress().subscribe(
  //     res => {
  //       console.log(res);
  //       window.location.reload();
  //     },
  //     err => {
  //       console.log(err);
  //     }
  //   )
  // }

  // putAddress(){
  //   return this.http.put(this.service.BaseURI + "/addresses/" + this.address.id , this.address);
  // }
}