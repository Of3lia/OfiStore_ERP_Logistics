import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { UserModel } from './../../../shared/models/user.model'
import { UserRoles } from './../../../shared/enums/UserRoles'
import { ProfileService } from './../../../shared/profile.service'
import { GeneralService  } from './../../../shared/general.service'

@Component({
  selector: 'app-all-users',
  templateUrl: './all-users.component.html',
  styleUrls: ['./all-users.component.css']
})
export class AllUsersComponent implements OnInit {

  public list : UserModel[] = [];
  selectedRole : UserRoles = UserRoles.All;
  searchUserName = "";  
  // skip and take are used for pagination
  skip = 0;
  take = 10;
  currentPage = 1;
  editIndex: number;

  userData: UserModel = new UserModel;
  
  constructor(
    private http: HttpClient,
    public profileService: ProfileService,
    public generalService: GeneralService,
  ) 
  { }


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

    this.http.post(this.generalService.BaseURI + "/ApplicationUsers/GetUsersList", body)
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

  editUser(i:number, user:UserModel){
    this.editIndex = i;
    this.userData = user;
  }

  sendUser(user:UserModel){
    this.userData.id = user.id;
    console.log(this.userData);
    this.profileService.editUser(this.userData).subscribe(
      res =>{
        window.alert("Edit succeed");
        window.location.reload();
      },
      err => {
        console.log(err);
      }
    )
  }

  deleteUser(id:string){
    this.profileService.deleteUser(id).subscribe(
      res =>{
        window.alert("Delete succeed");
        window.location.reload();
      },
      err => {
        console.log(err);
      }
    )
  }

}
