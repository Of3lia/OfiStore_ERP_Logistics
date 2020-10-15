import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../shared/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: [
  ]
})
export class HomeComponent implements OnInit {

  userDetails;
  role:string;

  constructor(
    private router:Router,
    private service:UserService
  ) { }

  ngOnInit(): void {
      // Get user role from JWT
    this.role = JSON.parse(atob(localStorage.getItem('token').split('.')[1])).role;
  }

  onLogout(){
    localStorage.removeItem('token');
    this.router.navigate(['/user/login']);
  }
}
