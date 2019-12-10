import { Component, OnInit } from '@angular/core';
import { CourseService } from '../../services/course.service';
import { AuthService } from '../../services/auth.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-course-single',
  templateUrl: './course-single.component.html',
  styleUrls: ['./course-single.component.css']
})
export class CourseSingleComponent implements OnInit {

  hidden:boolean;
  normal_teacher:boolean;
  course:{};
  courseID:number;
  crsID

  constructor(public courseService:CourseService, private authService:AuthService, public myRouter: ActivatedRoute, private router:Router,public activetedRouter:ActivatedRoute) { }

  ngOnInit() {
    this.crsID = this.activetedRouter.snapshot.params['id']
    console.log(this.crsID)
    var cookie = this.authService.getCookie();
    if(!cookie || cookie.userTypeID == "2")
      this.hidden = true;
    else if(cookie.isAdmin == "1"){
      this.hidden = false;
      this.normal_teacher = false;
    }
    else{
      this.hidden = false;
      this.normal_teacher = true;
    }

    this.courseID = this.myRouter.snapshot.params['id'];
    this.getCourse(this.courseID)
  }

  getCourse(ID:number): void{
    this.courseService.getCourse(ID).subscribe(
      (data)=>{
        this.course = data;
      },
      (error)=>{
        console.log(error);
      }
    )
  }

  delete(){
    this.courseService.delete(this.courseID).subscribe(
      (success)=>{
        this.router.navigate(['']);
      },
      (error)=>{
        console.log(error)
      }
    )
  }

}
