import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styles: [
  ]
})
export class RegistrationComponent implements OnInit {

  constructor(
    public service: UserService
  ) { }

  ngOnInit(): void {
  }

  onSubmit(){
    this.service.register().subscribe(
      (res:any) => {
        // if(res.succeeded){
          window.alert("Register Successful");
          this.service.formModel.reset();
        // }
        // else{
        //   res.errors.forEach(element => {
        //     switch (element.code){
        //       case 'DuplicateUserName':
        //         // Username is already taken
        //         window.alert("Duplicated name");
        //         break;
              
        //       default:
        //         //Registration failed
        //         window.alert("Unknown error, register failed");
        //         break;
        //     }
        //   });
        // }
      },
      err => {
        console.log(err);
      }
    );
  }

}
