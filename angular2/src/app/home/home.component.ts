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

  constructor(
    private router:Router
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
