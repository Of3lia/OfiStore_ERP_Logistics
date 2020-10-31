import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  userDetails;
  role:string;
  logged: boolean;

  constructor(
    private router:Router
  ) { }

  ngOnInit(): void {
    this.getUserRoleFromJwt();
  }
    
  onLogout(){
    localStorage.removeItem('token');
    window.location.replace("home/store");
    // this.router.navigate(['/user/login']);
  }

  getUserRoleFromJwt(){
    // Get user role from JWT
    if(localStorage.getItem('token') != null){
      this.logged = true;
      this.role = JSON.parse(atob(localStorage.getItem('token').split('.')[1])).role;
    }else{
      this.logged = false;
    }
  }
}
