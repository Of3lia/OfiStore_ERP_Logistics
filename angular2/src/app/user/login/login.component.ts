import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: [
  ]
})
export class LoginComponent implements OnInit {

  formModel={
    UserName : '',
    Password: ''
  }

  constructor(
    private service:UserService,
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
    this.service.login(form.value).subscribe(
      (res:any) => {
        localStorage.setItem('token',res.token);
        this.router.navigateByUrl('/home');
      },
      err => {
        if(err.status == 400){
          window.alert('Incorrect username or password');
        }else{
          console.log(err);
        }
      }
    );
  }

}
