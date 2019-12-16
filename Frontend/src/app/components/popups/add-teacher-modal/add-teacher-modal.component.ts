import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CourseService } from '../../../services/course.service';
import { UserService } from '../../../services/user.service';
import { DepartmentService } from '../../../services/department.service';

@Component({
  selector: 'app-add-teacher-modal',
  templateUrl: './add-teacher-modal.component.html',
  styleUrls: ['./add-teacher-modal.component.css']
})
export class AddTeacherModalComponent implements OnInit {

  @Input() modal_name: string;
  departments;
  teacher: FormGroup;

  constructor(private builder: FormBuilder, private courseService: CourseService, private userService: UserService,
    private deptService: DepartmentService) { }

  ngOnInit() {
    this.getAllDepartments();

    this.teacher = this.builder.group({
      Name: ['', Validators.required],
      UserName: ['', Validators.required],
      Password: ['', Validators.required],
      DepartmentID: ['', Validators.required],
      Bio: [''],
      IsAdmin: [''],
    })
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
    const controls = this.teacher.controls;
    for (const name in controls) {
      if (controls[name].invalid) {
        return;
      }
    }

    this.userService.addTeacher(this.teacher.value).subscribe(
      (success) => {
        console.log(success);
        alert("You Added New Teacher successfully , Thanks");
      },
      (error) => {
        console.log(error);
        alert("Some Thing Wrong , Please Try Again ..");
      }
    )
  }

}
