import { Component, OnInit } from '@angular/core';
import { ProfileService } from './../../../shared/profile.service';
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styles: [
  ]
})
export class AddressComponent implements OnInit {

  edit:boolean = false;

  constructor(
    private service: ProfileService
  ) { }

  ngOnInit(): void {
  }

  //Address
  
  editAddress(){
    this.edit = true;
  }

  updateAddress(form:NgForm){
    if(form.invalid){
      return;
    }
    this.service.putAddress().subscribe(
      res => {
        this.edit = false;
      },
      err => {
        console.log(err);
      }
    )
  }
}
