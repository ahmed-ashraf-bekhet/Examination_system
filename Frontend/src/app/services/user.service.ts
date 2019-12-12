import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class UserService {
  url : string = "http://localhost:54345/api/student/update"
  teacherUrl : string = "http://localhost:54345/api/instructor/update"
  basic = ''
  
  headers = new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': this.basic 
  });
  
  constructor(public myHttp:HttpClient) { }
  
  updateInfo(student){
    return this.myHttp.post(this.url, student)
  }

  updateTeacherInfo(teacher){
    return this.myHttp.post(this.teacherUrl, teacher)
  }

  LoginAsTeacher(username,password){
    console.log(username)
    console.log(password)
    let teacher = {
      Username : username,
      Password : password 
    }
    return this.myHttp.post("http://localhost:54345/api/instructor/login",teacher)
  }

  LoginAsStudent(username,password){
    console.log(username)
    console.log(password)
    let student = {
      Username : username,
      Password : password 
    }
    return this.myHttp.post("http://localhost:54345/api/student/login",student)
  }

  getStudentByID(ID){
    return this.myHttp.get(`http://localhost:54345/api/student/${ID}`)
  }

  getTeacherByID(ID){
    return this.myHttp.get(`http://localhost:54345/api/instructor/${ID}`)
  }

  getAllTeachers(){
    return this.myHttp.get("http://localhost:54345/api/Instructor");
  }

  getDepartmentTeachers(ID:number){
    return this.myHttp.get(`http://localhost:54345/api/GetDepartmentInstructors/${ID}`);
  }

  addStudent(student){
    return this.myHttp.post("http://localhost:54345/api/student/add",student)
  }

  addTeacher(teacher){
    return this.myHttp.post("http://localhost:54345/api/instructor/add",teacher)
  }

}

