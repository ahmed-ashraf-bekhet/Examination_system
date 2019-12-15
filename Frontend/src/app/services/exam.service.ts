import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { AuthService } from './auth.service';
import { StudentAnswerExam } from './student-answer-exam.model';

@Injectable({
  providedIn: 'root'
})
export class ExamService {
  qns: any[];
  seconds: number;
  timer;
  qnProgress: number;
  stExamAns: StudentAnswerExam;
  
  constructor(private myHttp: HttpClient, private authService: AuthService) { }

  displayTimeElapsed() {
    return Math.floor(this.seconds / 3600) + ':' + Math.floor(this.seconds / 60) + ':' + Math.floor(this.seconds % 60);
  }

  save(exam){
    return this.myHttp.post("http://localhost:54345/api/exam/add",exam);
  }


  GetExam(ID:number){
    const httpOptions = {
      headers: new HttpHeaders(this.authService.getCookie())
    };
    return this.myHttp.get(`http://localhost:54345/api/exam/getExam/${ID}`,httpOptions);
  }

  GetExamQuestions(ID:number){
    return this.myHttp.get(`http://localhost:54345/api/examquestion/${ID}`);
  }

  CorrectExamQuestions(ID:number){
    const httpOptions = {
      headers: new HttpHeaders(this.authService.getCookie())
    };
    return this.myHttp.get(`http://localhost:54345/api/exam/correct/${ID}`,httpOptions);
  }

  AddStudentAnswer(exam:StudentAnswerExam){
    console.log(exam);
    return this.myHttp.post("http://localhost:54345/api/StudentAnswer",exam);
  }

}

