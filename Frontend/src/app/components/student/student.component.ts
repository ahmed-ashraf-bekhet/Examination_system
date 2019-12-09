import { Component, OnInit, Input } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent implements OnInit {
  student 
  title:string;
  constructor(public authService:AuthService,public myService:UserService,public myActivatedRoute:ActivatedRoute) { 
  }

  ngOnInit() {
    if(!this.authService.getCookie()){
      window.location.href = "sdabsadbk"
    }
    this.myService.getStudentByID(this.myActivatedRoute.snapshot.params['id'] ).subscribe(
      (response)=>{
        this.student = response
      },
      (error)=>{
        console.log(error);
      }
    )
  }
  
  clicked(username,password){
    this.student.Username = username;
    this.student.Password = password;
    this.myService.updateInfo(this.student).subscribe(
      (response)=>{
        console.log(response)
        this.title = "Thanks , Your Info Updated Successfully"  
      },
      (error)=>{
        console.log(error);
      }
    )
  }
  

}
