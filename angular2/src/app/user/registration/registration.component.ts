import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/user.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styles: [
  ]
})
export class RegistrationComponent implements OnInit {

  constructor(
    public service: UserService,
    private toastr: ToastrService,
  ) { }

  ngOnInit(): void {
  }

  onSubmit(){
    this.service.register().subscribe(
      (res:any) => {
        // if(res.succeeded){
          this.toastr.success('Registered succeessfully', 'Good!');
          this.service.formModel.reset();
          setTimeout(function(){  window.location.replace('/home/login'); }, 1000);
         
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
        this.toastr.error('Name is already taken', 'Error!');

        console.log(err);
      }
    );
  }

}
