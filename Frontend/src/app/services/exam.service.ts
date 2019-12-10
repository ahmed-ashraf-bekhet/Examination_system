import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ExamService {

  constructor(private myHttp: HttpClient) { }

  save(exam){
    return this.myHttp.post("http://localhost:54345/api/exam/add",exam);
  }

}
