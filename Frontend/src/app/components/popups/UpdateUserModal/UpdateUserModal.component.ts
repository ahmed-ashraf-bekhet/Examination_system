import { Component, OnInit, Input } from '@angular/core';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-pop-ups',
  templateUrl: './UpdateUserModal.component.html',
  styleUrls: ['./UpdateUserModal.component.css']
})
export class UpdateUserModalComponent implements OnInit {
  @Input() student
  @Input() teacher
  user
  


  title:string;
  constructor(public myService:UserService) { }

  ngOnInit() {
    if(this.student){
      this.user = this.student
    }

    if(this.teacher){
      this.user = this.teacher
    }
  }

  clicked(username, password) {
    if (this.student) {
      console.log(this.user.ID)
      this.user.Username = username;
      this.user.Password = password;
      console.log(this.user.Username)
      console.log(this.user.Password)
      console.log(this.user)
      this.myService.updateInfo(this.user).subscribe(
        (response) => {
          console.log(response)
          this.title = "Thanks , Your Info Updated Successfully"
        },
        (error) => {
          console.log(error);
        }
      )
    }

    else if (this.teacher) {
      console.log(this.user.ID)
      this.user.Username = username;
      this.user.Password = password;
      console.log(this.user.Username)
      console.log(this.user.Password)
      console.log(this.user)
      this.myService.updateTeacherInfo(this.user).subscribe(
        (response) => {
          console.log(response)
          this.title = "Thanks , Your Info Updated Successfully"
        },
        (error) => {
          console.log(error);
        }
      )
    }

  }

}
