import { Component, OnInit, Input } from '@angular/core';
import { CourseService } from '../../services/course.service';

@Component({
  selector: 'app-courses-list',
  templateUrl: './courses-list.component.html',
  styleUrls: ['./courses-list.component.css']
})
export class CoursesListComponent implements OnInit {
  @Input() courses_number: number;
  @Input() deptID:number;
  @Input() studentID:number;
  @Input() teacherID:number;

  courses;

  constructor(public courseService: CourseService) { }

  ngOnInit() {
    if(this.deptID)
      this.getDepartmentCourses(this.deptID);
    else if(this.studentID){
      this.getStudentCourses(this.studentID);
    }
    else if(this.teacherID){
      this.getTeacherCourses(this.teacherID);
    }
    else{
      this.getAllCourses();
    }
  }

  getAllCourses(){
    this.courseService.getAllCourses().subscribe(
      (data) => {
        this.courses = data ;
        
        if(this.courses_number > 0)
          this.courses = this.courses.slice(0,this.courses_number) 
      },
      (error)=>{
        console.log(error);
      }
    )
  }

  getDepartmentCourses(deptID){
    this.courseService.getDepartmentCourses(deptID).subscribe(
      (data)=>{
        this.courses = data;
      },
      (error)=>{
        console.log(error);
      }
    )
  }

  getStudentCourses(studentID){
    this.courseService.getStudentCourses(studentID).subscribe(
      (data)=>{
        this.courses = data.courses;
        console.log(this.courses)
      },
      (error)=>{
        console.log(error);
      }
    )
  }

  getTeacherCourses(teacherID){
    this.courseService.getStudentCourses(teacherID).subscribe(
      (data)=>{
        this.courses = data.courses;
        console.log(this.courses)
      },
      (error)=>{
        console.log(error);
      }
    )
  }

}