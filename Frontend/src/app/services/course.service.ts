import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})

export class CourseService {

  constructor(private myHttp: HttpClient, private authService: AuthService) { }

  getAllCourses(){
    
    return this.myHttp.get("http://localhost:6755/api/Course");

  }

  getDepartmentCourses(ID:number){
    return this.myHttp.get(`http://localhost:6755/api/GetDepartmentCourses/${ID}`);
  }

  getCourse(ID:number){
    return this.myHttp.get(`http://localhost:6755/api/Course/${ID}`)
  }
  getStudentCourses(ID:number){
    return this.myHttp.get(`http://localhost:6755/api/GetStudentCourses/${ID}`)
  }
  getTeacherCourses(ID:number){
    return this.myHttp.get(`http://localhost:6755/api/GetInstructorCourses/${ID}`)
  }

  getCourseQuestions(courseID:number){
    return this.myHttp.get(`http://localhost:6755/api/coursequestion/${courseID}`)
  }

  save(course){
    return this.myHttp.post("http://localhost:6755/api/course/add",course);
  }

  update(course){
    return this.myHttp.post("http://localhost:54345/api/course/update",course);
  }

  delete(ID:number){
    const httpOptions = {
      headers: new HttpHeaders(this.authService.getCookie())
    };

    return this.myHttp.get(`http://localhost:6755/api/course/delete/${ID}`,httpOptions);
  }

  test(image: File){
    const formData = new FormData();
    formData.append('image', image);
    
    const httpOptions = {
      headers: new HttpHeaders(this.authService.getCookie())
    };
    
    return this.myHttp.get("http://localhost:6755/test/test",httpOptions)
  }

  getCourseExams(courseID){
    return this.myHttp.get(`http://localhost:6755/api/exam/getCourseExams/${courseID}`)
  }

}
