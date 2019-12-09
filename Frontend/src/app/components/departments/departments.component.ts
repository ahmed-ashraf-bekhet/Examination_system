import { Component, OnInit } from '@angular/core';
import { DepartmentService } from '../../services/department.service';

@Component({
  selector: 'app-departments',
  templateUrl: './departments.component.html',
  styleUrls: ['./departments.component.css']
})
export class DepartmentsComponent implements OnInit {

  modal_name:string = "addDepartmentModal";
  departments;

  constructor(private myService:DepartmentService) { }

  ngOnInit() {
    this.getDepartments();
  }

  getDepartments(): void{
    this.myService.getAllDepartments().subscribe(
      (data)=>{
        this.departments = data;
      },
      (error)=>{
        console.log(error);
      }
    )
  }

}
