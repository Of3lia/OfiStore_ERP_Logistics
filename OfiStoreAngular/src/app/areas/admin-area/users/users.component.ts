import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styles: [
  ]
})
export class UsersComponent implements OnInit {

  rootURL = 'https://localhost:44369/api/users';
  public list : UserModel[] = [];
  selectedRole : Role = Role.All;
  searchUserName = "";  
  // skip and take are used for pagination
  skip = 0;
  take = 10;
  currentPage = 1;
  editIndex: number;

  constructor(
    private http: HttpClient
  ) 
  { }

  asd(id){
    window.alert(id);
  }

  ngOnInit(): void {
    this.refreshList();
  }

  refreshList(){
    var body = {
      Role : this.selectedRole,
      SearchUserName : this.searchUserName,
      Skip : this.skip,
      Take : this.take
    }

    this.http.post(this.rootURL + "/GetUsersList", body)
    .toPromise()
    .then(res => this.list = res as UserModel[]);
  }

  changeRole(){
    this.currentPage=1;
    this.skip=0
    this.refreshList();
  }

  nextPage(){
    this.skip += 10;
    this.currentPage++;
    this.refreshList();
  }

  lastPage(){
    this.skip -= 10;
    this.currentPage--;
    this.refreshList();
  }


}
class UserModel{
    userName = Text;
}

enum Role{
  Admin, Employee, Customer, All
}
