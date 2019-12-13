import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TeacherService {

  constructor(private myHttp: HttpClient) { }

  getAllTeachers(){
    return this.myHttp.get("http://localhost:54345/api/Instructor");
  }


  getInstructorsNumber(){
    return this.myHttp.get("http://localhost:54345/api/getInstructorsNumber");
  }

  getDepartmentTeachers(ID:number){
    return this.myHttp.get(`http://localhost:54345/api/GetDepartmentInstructors/${ID}`);
  }

  getTeacher(ID:number){
    return this.myHttp.get(`http://localhost:54345/api/Instructor/${ID}`)
  }
}
