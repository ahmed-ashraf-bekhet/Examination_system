import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthService } from './auth.service';
import { CreateQuestion } from './create-question.model';

@Injectable({
  providedIn: 'root'
})
export class QuestionService {
  CreateQuestion: CreateQuestion[];
  constructor(private myHttp: HttpClient, private authService: AuthService) { }


  getAllTypeOFQuestions(){
    return this.myHttp.get("http://localhost:54345/api/Type");
  }



  Add(CreateQuestion){
    return this.myHttp.post("http://localhost:54345/api/createQuestion",CreateQuestion);
  }
}
