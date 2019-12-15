import { Component, OnInit, Input } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-teacher-single',
  templateUrl: './teacher-single.component.html',
  styleUrls: ['./teacher-single.component.css']
})
export class TeacherSingleComponent implements OnInit {
  teacher; 
  ID;
  student_answers_modal:string = "students_answers_modal";
  @Input() title:string;

  constructor(public authService:AuthService,public myService:UserService,public myActivatedRoute:ActivatedRoute) { 
    this.ID = this.myActivatedRoute.snapshot.params['id'] 
  }

  ngOnInit() {
    if(!this.authService.getCookie()){
      window.location.href = "NoAuthorization"
    }
    this.myService.getTeacherByID(this.ID).subscribe(
      (response)=>{
        this.teacher = response
        console.log(this.teacher.DeptName)
      },
      (error)=>{
        console.log(error);
      }
    )
  }
  

  clicked(username,password){
    this.teacher.Username = username;
    this.teacher.Password = password;
    this.myService.updateTeacherInfo(this.teacher).subscribe(
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
