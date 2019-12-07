import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class UserService {
  url : string = "http://localhost:6755/api/student/update"
  teacherUrl : string = "http://localhost:6755/api/instructor/update"
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
}

