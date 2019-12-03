import { Component, OnInit } from '@angular/core';
import { CourseService } from '../../services/course.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-course-single',
  templateUrl: './course-single.component.html',
  styleUrls: ['./course-single.component.css']
})
export class CourseSingleComponent implements OnInit {

  course:{};

  constructor(public myService:CourseService, public myRouter: ActivatedRoute) { }

  ngOnInit() {
    this.getCourse(this.myRouter.snapshot.params['id'])
  }

  getCourse(ID:number): void{
    this.myService.getCourse(ID).subscribe(
      (data)=>{
        this.course = data[0];
      },
      (error)=>{
        console.log(error);
      }
    )
  }

}
