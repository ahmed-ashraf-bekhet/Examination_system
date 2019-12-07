import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  constructor(private myHttp: HttpClient) { }

  getAllDepartments(){
    return this.myHttp.get("http://localhost:54345/api/Department");
  }

  getDepartment(DepartmentID:number){
    return this.myHttp.get(`http://localhost:54345/api/Department/${DepartmentID}`);
  }

  getStudentsNumber(DepartmentID:number){
    return this.myHttp.get(`http://localhost:54345/api/getStudentsNumber/${DepartmentID}`);
  }

  getTeachersNumber(DepartmentID:number){
    return this.myHttp.get(`http://localhost:54345/api/getInstructorsNumber/${DepartmentID}`);
  }

  getCoursesNumber(DepartmentID:number){
    return this.myHttp.get(`http://localhost:54345/api/getCoursesNumber/${DepartmentID}`);
  }
}
