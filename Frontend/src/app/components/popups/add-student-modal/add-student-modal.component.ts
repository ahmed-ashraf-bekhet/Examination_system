import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CourseService } from '../../../services/course.service';
import { UserService } from '../../../services/user.service';
import { DepartmentService } from '../../../services/department.service';

@Component({
  selector: 'app-add-student-modal',
  templateUrl: './add-student-modal.component.html',
  styleUrls: ['./add-student-modal.component.css']
})
export class AddStudentModalComponent implements OnInit {

  @Input() modal_name: string;
  departments;
  student: FormGroup;

  constructor(private builder: FormBuilder, private courseService: CourseService, private userService: UserService,
    private deptService: DepartmentService) { }

  ngOnInit() {
    this.getAllDepartments();

    this.student = this.builder.group({
      Name: ['', Validators.required],
      UserName: ['', Validators.required],
      Password: ['', Validators.required],
      DepartmentID: ['', Validators.required]
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
    const controls = this.student.controls;
    for (const name in controls) {
      if (controls[name].invalid) {
        return;
      }
    }

    this.userService.addStudent(this.student.value).subscribe(
      (success) => {
        console.log(success);
      },
      (error) => {
        console.log(error);
      }
    )
  }

}
