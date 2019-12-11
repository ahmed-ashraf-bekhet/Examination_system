import { Component, OnInit, Input } from '@angular/core';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-teachers-list',
  templateUrl: './teachers-list.component.html',
  styleUrls: ['./teachers-list.component.css']
})
export class TeachersListComponent implements OnInit {

  @Input() teachers_number: number;
  @Input() deptID:number;
  teachers;

  constructor(private userService:UserService) { }

  ngOnInit() {
    if(this.deptID)
      this.getDepartmentTeachers(this.deptID);
    else
      this.getAllTeachers();
  }

  getAllTeachers(){
    this.userService.getAllTeachers().subscribe(
      (data) => {
        this.teachers = data ;
        
        if(this.teachers_number > 0)
          this.teachers = this.teachers.slice(0,this.teachers_number) 
      },
      (error)=>{
        console.log(error);
      }
    )
  }

  getDepartmentTeachers(deptID){
    this.userService.getDepartmentTeachers(deptID).subscribe(
      (data)=>{
        this.teachers = data;
      },
      (error)=>{
        console.log(error);
      }
    )
  }
}
