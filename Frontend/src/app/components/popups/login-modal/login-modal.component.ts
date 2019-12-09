import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login-modal',
  templateUrl: './login-modal.component.html',
  styleUrls: ['./login-modal.component.css']
})
export class LoginModalComponent implements OnInit {

  constructor(public myService:UserService,public authService:AuthService) { }
  LoginStatus = "Login"
  closingModal = false
  
  ngOnInit() {
  }
  clicked(username,password,isTeacher){
    console.log(isTeacher)
    if(isTeacher.checked){
      let teacher
      this.myService.LoginAsTeacher(username,password).subscribe(
        (response)=>{
          console.log(response)
          this.myService.getTeacherByID(response).subscribe(
            (res)=>{
              teacher = res

              this.authService.setCookie(teacher.ID,"1",teacher.IsAdmin)

              teacher = res
            },
            (error)=>{
              console.log(error);
            }
          )
          location.href = `/teacherProfile/${response}`
        },
        (error)=>{
          console.log(error);
          this.LoginStatus = "You login wrongly , Please try again ..."
        }
      )
    }
    else{
      console.log(isTeacher)
      console.log(username)
      console.log(password)
      let student
      this.myService.LoginAsStudent(username,password).subscribe(
        (response)=>{
          console.log(response)
          this.myService.getStudentByID(response).subscribe(
            (res)=>{
              console.log(res)
              student = res
              this.authService.setCookie(student.ID,"2","0")

            },
            (error)=>{
              console.log(error);
            }
          )
          window.location.href = `http://localhost:4200/studentProfile/${response}`
        },
        (error)=>{
          console.log(error);
          this.LoginStatus = "You login wrongly , Please try again ..."
        }
      )
    }
  }
}
