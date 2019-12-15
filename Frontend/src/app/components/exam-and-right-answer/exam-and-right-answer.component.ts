import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { ExamService } from 'src/app/services/exam.service';

@Component({
  selector: 'app-exam-and-right-answer',
  templateUrl: './exam-and-right-answer.component.html',
  styleUrls: ['./exam-and-right-answer.component.css']
})
export class ExamAndRightAnswerComponent implements OnInit {

  
  constructor(public myRouter: ActivatedRoute, private authService:AuthService, private ExamService:ExamService) { }
  QandA
  ExamID
  ngOnInit() {
    this.ExamID= parseInt(this.myRouter.snapshot.params['id']),
    this.ExamService.getQuestionsAnser(this.ExamID).subscribe(
      (data)=>{
        this.QandA = data;
        console.log(this.QandA)
      },
      (error)=>{
        console.log(error);
      }
    );
  }

}
