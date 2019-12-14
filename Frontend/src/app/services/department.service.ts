import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  constructor(private myHttp: HttpClient, private authService:AuthService) { }

  getAllDepartments(){
    return this.myHttp.get("http://localhost:6755/api/Department");
  }

  getDepartment(DepartmentID:number){
    return this.myHttp.get(`http://localhost:6755/api/Department/${DepartmentID}`);
  }

  getStudentsNumber(DepartmentID:number){
    return this.myHttp.get(`http://localhost:6755/api/getStudentsNumber/${DepartmentID}`);
  }

  getTeachersNumber(DepartmentID:number){
    return this.myHttp.get(`http://localhost:6755/api/getInstructorsNumber/${DepartmentID}`);
  }

  getCoursesNumber(DepartmentID:number){
    return this.myHttp.get(`http://localhost:6755/api/getCoursesNumber/${DepartmentID}`);
  }

  save(department){
    return this.myHttp.post("http://localhost:6755/api/department/add",department);
  }

  delete(ID:number){
    const httpOptions = {
      headers: new HttpHeaders(this.authService.getCookie())
    };

    return this.myHttp.get(`http://localhost:6755/api/department/delete/${ID}`,httpOptions);
  }

  update(department){
    return this.myHttp.post("http://localhost:6755/api/department/update",department);
  }
}
