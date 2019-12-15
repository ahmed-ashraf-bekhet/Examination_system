import { Component, OnInit, Input } from '@angular/core';
import { CourseService } from '../../../services/course.service';
import { UserService } from '../../../services/user.service';
import { FormBuilder,FormGroup, Validators } from "@angular/forms";

@Component({
  selector: 'app-assign-student-modal',
  templateUrl: './assign-student-modal.component.html',
  styleUrls: ['./assign-student-modal.component.css']
})
export class AssignStudentModalComponent implements OnInit {

  courses;
  students;
  form:FormGroup;
  @Input() modal_name:string;

  constructor(private courseService:CourseService, private userService:UserService, private builder:FormBuilder) { }

  ngOnInit() {
    this.getAllCourses();
    this.getAllStudents();

    this.form = this.builder.group({
      StudentID:['', Validators.required],
      CourseID:['', Validators.required]
    })
  }

  save(){
    const controls = this.form.controls;
    for (const name in controls) {
      if (controls[name].invalid) {
        return;
      }
    }

    console.log(this.form.value)
    this.courseService.joinCourse(this.form.value).subscribe(
      (success)=>{
        console.log(success)
      },
      (error)=>{
        console.log(error);
      }
    )
  }

  getAllCourses(){
    this.courseService.getAllCourses().subscribe(
      (data)=>{
        this.courses = data;
      },
      (error)=>{
        console.log(error);
      }
    )
  }

  getAllStudents(){
    this.userService.getAllStudents().subscribe(
      (data)=>{
        this.students = data;
      },
      (error)=>{
        console.log(error);
      }
    )
  }

}
