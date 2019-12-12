import { Component, OnInit } from '@angular/core';
import { TeacherService } from 'src/app/services/teacher.service';
import { CourseService } from 'src/app/services/course.service';
import { StudentService } from 'src/app/services/student.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent implements OnInit {


  Count_Of_Cources:number
  Count_Of_Students:number
  Count_Of_teachers:number

  constructor(private UserService:UserService, private CService:CourseService) {
   }

  ngOnInit() {
    this.getAllTeachers();
    this.getAllCoursesCount();
    this.getCountOfStudent();
  }

  getAllTeachers(): void{
    this.UserService.getInstructorsNumber().subscribe(
      (data)=>{
        //console.log(data)
        this.Count_Of_teachers = data as number   
      },
      (error)=>{
        console.log(error);
      }
    )
  }


  getAllCoursesCount(): void{
    this.CService.getCoursesNumber().subscribe(
      (data)=>{
        //console.log(data)
        this.Count_Of_Cources = data as number;  
      },
      (error)=>{
        console.log(error);
      }
    )
  }


  getCountOfStudent(): void{
    this.UserService.getCountOfStudent().subscribe(
      (data)=>{
        //console.log(data)
        this.Count_Of_Students = data as number;
      },
      (error)=>{
        console.log(error);
      }
    )
  }

}
