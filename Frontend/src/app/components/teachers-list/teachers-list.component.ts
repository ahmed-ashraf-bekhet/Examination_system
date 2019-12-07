import { Component, OnInit, Input } from '@angular/core';
import { TeacherService } from '../../services/teacher.service';

@Component({
  selector: 'app-teachers-list',
  templateUrl: './teachers-list.component.html',
  styleUrls: ['./teachers-list.component.css']
})
export class TeachersListComponent implements OnInit {

  @Input() teachers_number: number;
  @Input() deptID:number;
  teachers;

  constructor(private teacherService:TeacherService) { }

  ngOnInit() {
    if(this.deptID)
      this.getDepartmentTeachers(this.deptID);
    else
      this.getAllTeachers();
  }

  getAllTeachers(){
    this.teacherService.getAllTeachers().subscribe(
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
    this.teacherService.getDepartmentTeachers(deptID).subscribe(
      (data)=>{
        this.teachers = data;
      },
      (error)=>{
        console.log(error);
      }
    )
  }
}
