import { Component, OnInit } from '@angular/core';
import { DepartmentService } from '../../services/department.service';
import { ActivatedRoute } from '@angular/router'

@Component({
  selector: 'app-department-single',
  templateUrl: './department-single.component.html',
  styleUrls: ['./department-single.component.css']
})
export class DepartmentSingleComponent implements OnInit {

  department:{};
  departmentID: number = this.myRouter.snapshot.params['id'];

  constructor(public myService:DepartmentService, public myRouter: ActivatedRoute) { }

  ngOnInit() {
    this.getDepartment(this.departmentID)
  }

  getDepartment(ID:number): void{
    this.myService.getDepartment(ID).subscribe(
      (data)=>{
        this.department = data[0];
      },
      (error)=>{
        console.log(error);
      }
    )
  }

  getStudentsNumber(ID:number){
    return 50;
  }

  getTeachersNumber(DepartmentID:number){
    return 8;
  }

  getCoursesNumber(DepartmentID:number){
    return 4;
  }
}
