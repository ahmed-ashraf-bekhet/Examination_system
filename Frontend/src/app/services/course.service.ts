import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class CourseService {

  constructor(private myHttp: HttpClient) { }

  getAllCourses(){
    return this.myHttp.get("http://localhost:54345/api/Course");
  }

  getDepartmentCourses(ID:number){
    return this.myHttp.get(`http://localhost:54345/api/GetDepartmentCourses/${ID}`);
  }

  getCourse(ID:number){
    return this.myHttp.get(`http://localhost:54345/api/Course/${ID}`)
  }

  test(){
    return this.myHttp.get("http://localhost:54345/test/test")
  }

}
