import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserModel } from 'src/app/shared/models/user.model';
import { AddressModel } from 'src/app/shared/models/address.model';
import { ProfileService } from './../../shared/profile.service';
import { UserRoles } from './../../shared/enums/UserRoles';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styles: [
  ]
})
export class ProfileComponent implements OnInit {

  edit : boolean = false;

  constructor(
    private router:Router,
    public service:ProfileService,
    private http: HttpClient
  ) { }

  ngOnInit(): void {
    this.service.getUserProfile().subscribe(
      res => { 
        // User Data:
        this.service.userDownloadedData = res;

        // Role enum:
        this.service.userDownloadedData.role = UserRoles[this.service.userDownloadedData.role];

        // Assign Address:
        this.service.address = this.service.userDownloadedData.address;
      },
      err => {
        console.log(err);
      }
    )
  }

  editProfile(){
    this.edit = true;
    this.service.formModel.setValue({
      userName: this.service.userDownloadedData.userName,
      fullName: this.service.userDownloadedData.fullName,
      email: this.service.userDownloadedData.email,
    })
  }

  onSubmit(){
    this.service.putUser().subscribe(
      res =>{
        this.edit=false;
        this.service.userDownloadedData.userName = this.service.formModel.value.userName;
        this.service.userDownloadedData.fullName = this.service.formModel.value.fullName;
        this.service.userDownloadedData.email = this.service.formModel.value.email;
      },
      err => {
        console.log(err);
      }
    )
    // if(form.invalid){
    //   return;
    // }
    // this.service.putUser().subscribe(
    //   res => {
    //     //console.log(res);
    //     window.location.reload();
    //   },
    //   err => {
    //     console.log(err);
    //   }
    // )
  }

  cancelEdit(){
    this.edit = false;
  }
}