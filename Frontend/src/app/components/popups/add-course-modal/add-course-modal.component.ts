import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CourseService } from '../../../services/course.service';
import { UserService } from '../../../services/user.service';
import { DepartmentService } from '../../../services/department.service';

@Component({
  selector: 'app-add-course-modal',
  templateUrl: './add-course-modal.component.html',
  styleUrls: ['./add-course-modal.component.css']
})
export class AddCourseModalComponent implements OnInit {

  @Input() modal_name: string;
  teachers;
  departments;
  course: FormGroup;

  constructor(private builder: FormBuilder, private courseService: CourseService, private userService: UserService,
    private deptService: DepartmentService) { }

  ngOnInit() {
    this.getAllTeachers();
    this.getAllDepartments();

    this.course = this.builder.group({
      Name: ['', Validators.required],
      Description: ['', Validators.required],
      DepartmentID: ['', Validators.required],
      InstructorID: ['', Validators.required]
    })
  }

  getAllTeachers() {
    this.userService.getAllTeachers().subscribe(
      (data) => {
        this.teachers = data;
        console.log(this.teachers)
      },
      (error) => {
        console.log(error);
      }
    )
  }

  getAllDepartments() {
    this.deptService.getAllDepartments().subscribe(
      (data) => {
        this.departments = data;
      },
      (error) => {
        console.log(error);
      }
    )
  }

  save() {
    const controls = this.course.controls;
    for (const name in controls) {
      if (controls[name].invalid) {
        return;
      }
    }

    this.courseService.save(this.course.value).subscribe(
      (success) => {
        console.log(success);
      },
      (error) => {
        console.log(error);
      }
    )
  }

}
