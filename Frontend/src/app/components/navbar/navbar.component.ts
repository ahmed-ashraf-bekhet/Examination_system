import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  @Input() course_modal:string;
  @Input() student_modal:string;
  @Input() teacher_modal:string;
  @Input() department_modal:string;

  hidden:boolean;
  user;
  teacher;
  student;

  constructor(private authService:AuthService) { }

  ngOnInit() {
    if(this.authService.getCookie()){
      this.hidden = false;
      this.user = this.authService.getCookie();
      console.log(this.user)
      if(this.user.userTypeID==1){
        this.teacher = this.authService.getCookie()
        console.log(this.teacher)
        console.log(this.student)
      }
      else {
        this.student = this.authService.getCookie()
        console.log(this.teacher)
        console.log(this.student)
      }
    }
    else
      this.hidden = true;
  }

  logout(){
    this.authService.deleteCookie();
    location.href = "/"
  }

}
