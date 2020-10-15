import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styles: [
  ]
})
export class UsersComponent implements OnInit {

  rootURL = 'https://localhost:44369/api/user';
  public list : UserModel[];
  selectedRole : Role = Role.Customer;
  orderBy;

  constructor(
    private http: HttpClient
  ) 
  { }

  ngOnInit(): void {
    this.refreshList();
  }

  refreshList(){

    var body = {
      role : this.selectedRole
    }

    this.http.post(this.rootURL, body)
    .toPromise()
    .then(res => this.list = res as UserModel[]);
  }

  asd(){
    window.alert(this.selectedRole);
  }

  // getUsers(){
  //   var body = {
  //     UserName: this.formModel.value.UserName,
  //     Email: this.formModel.value.Email,
  //     FullName: this.formModel.value.FullName,
  //     Password: this.formModel.value.Passwords.Password,
  //   };
  //   return this.http.post(this.BaseURI + '/ApplicationUser/Register', body);
  // }
}
class UserModel{
    userName = Text;
}

enum Role{
  Admin, Employee, Customer
}
