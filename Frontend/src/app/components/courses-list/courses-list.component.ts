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

  courses;

  constructor(public courseService: CourseService) { }

  ngOnInit() {
    if(this.deptID)
      this.getDepartmentCourses(this.deptID);
    else
      this.getAllCourses();
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
        console.log(this.courses+"aaaa")
      },
      (error)=>{
        console.log(error);
      }
    )
  }
}