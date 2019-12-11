import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CourseService } from '../../../services/course.service';
import { UserService } from '../../../services/user.service';
import { DepartmentService } from '../../../services/department.service';

@Component({
  selector: 'app-update-course-modal',
  templateUrl: './update-course-modal.component.html',
  styleUrls: ['./update-course-modal.component.css']
})
export class UpdateCourseModalComponent implements OnInit {

  @Input() modal_name: string;
  @Input() data;
  teachers;
  departments;
  course: FormGroup;

  constructor(private builder: FormBuilder, private courseService: CourseService, private userService: UserService,
    private deptService: DepartmentService) { }

  ngOnInit() {
    this.getAllTeachers();
    this.getAllDepartments();

    this.course = this.builder.group({
      ID:this.data['ID'],
      Name: [this.data['Name'], Validators.required],
      Description: [this.data['Description'], Validators.required],
      DepartmentID: [this.data['DepartmentID'], Validators.required],
      InstructorID: [this.data['InstructorID'], Validators.required]
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

  update() {
    const controls = this.course.controls;
    for (const name in controls) {
      if (controls[name].invalid) {
        return;
      }
    }

    this.courseService.update(this.course.value).subscribe(
      (success) => {
        location.reload();
      },
      (error) => {
        console.log(error);
      }
    )
  }

}
