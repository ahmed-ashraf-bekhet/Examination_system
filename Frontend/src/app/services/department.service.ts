import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  constructor(private myHttp: HttpClient) { }

  getAllDepartments(){
    return this.myHttp.get("http://localhost:1600/courses");
  }

  getDepartment(ID:number){
    return this.myHttp.get(`http://localhost:1600/courses?ID=${ID}`)
  }

  getStudentsNumber(DepartmentID:number){
    return 50;
  }

  getTeachersNumber(DepartmentID:number){
    return 8;
  }

  getCoursesNumber(DepartmentID:number){
    return 4;
  }
}
