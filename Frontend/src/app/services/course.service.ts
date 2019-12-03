import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class CourseService {

  constructor(private myHttp: HttpClient) { }

  getAllCourses(){
    return this.myHttp.get("http://localhost:1600/courses");
  }

  getDepartmentCourses(ID:number){
    return this.myHttp.get(`http://localhost:1600/courses?DepartmentID=${ID}`);
  }

  getCourse(ID:number){
    return this.myHttp.get(`http://localhost:1600/courses?ID=${ID}`)
  }

  test(){
    return this.myHttp.get("http://localhost:54345/test/test")
  }

}
