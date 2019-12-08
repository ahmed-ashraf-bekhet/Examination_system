import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  constructor(private myHttp: HttpClient, private authService:AuthService) { }

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

  delete(ID:number){
    const httpOptions = {
      headers: new HttpHeaders(this.authService.getCookie())
    };

    return this.myHttp.get(`http://localhost:54345/api/department/delete/${ID}`,httpOptions);
  }
}
