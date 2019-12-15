import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ExamService } from 'src/app/services/exam.service';
import { AuthService } from 'src/app/services/auth.service';
import { StudentAnswerExam } from 'src/app/services/student-answer-exam.model';

@Component({
  selector: 'app-exams',
  templateUrl: './exams.component.html',
  styleUrls: ['./exams.component.css']
})
export class ExamsComponent implements OnInit {

  examID:number;
  solve:boolean;
  object: {[key: number]: any}; 
  AnswerID:[number];
  AnswerBody:[any];
  totalItems:number;
  show:boolean;
  StudentID:number;
  formdata: StudentAnswerExam;

  constructor(private router:Router, public myRouter: ActivatedRoute, private authService:AuthService, private ExamService:ExamService) { }

  ngOnInit() {
   this.formdata= {
    StudentID: parseInt(this.authService.getCookie().userID),
    QuetionID: 0,
    ExamID: parseInt(this.myRouter.snapshot.params['id']),
    ANserID:0
  }
   this.show=false;
   this.totalItems=10
   this.ExamService.seconds=0;
   this.ExamService.qnProgress=0;
   this.AnswerID=[0];
   this.AnswerBody=[''];
   this.object=new Object();
   this.StudentID =parseInt(this.authService.getCookie().userID);
   this.examID = this.myRouter.snapshot.params['id'];
   this.ExamService.GetExam(this.examID).subscribe(
      (data:any)=>{
        //console.log("yes");
        this.solve=data.solved
        //console.log(this.solve,data);
        if(!this.solve){
          this.ExamService.GetExamQuestions(this.examID).subscribe(
            (data:any)=>{
              this.ExamService.qns=data;
              for (let index = 0; index < this.ExamService.qns[this.ExamService.qnProgress].Options_ID.length; index++) {
                this.AnswerID[index]=parseInt(this.ExamService.qns[this.ExamService.qnProgress].Options_ID[index]);
                this.AnswerBody[index]=this.ExamService.qns[this.ExamService.qnProgress].Options[index];
                 Object.assign(this.object,{[this.AnswerID[index]]: this.AnswerBody[index]});
              }
              this.startTimer();
            },
            (error)=>{
              console.log(error);
            }
          );
        }
      },
      (error)=>{
        console.log(error);
      }
    );

    }

    startTimer(){
      this.ExamService.timer = setInterval(() => {
        this.ExamService.seconds++;
      }, 1000);
  }

  Answer(qID,AnsID,event){
    this.ExamService.qns[this.ExamService.qnProgress].answer = parseInt(AnsID);
    if(this.ExamService.qns[this.ExamService.qnProgress].QtypeId==2){
      event.target.checked=false;
    }
    this.ExamService.qnProgress++;
    this.object={};
    this.AnswerID=[0];
    this.AnswerBody=[''];
    this.formdata.QuetionID=parseInt(qID);
    this.formdata.ANserID=parseInt(AnsID);
    console.log(this.formdata);
    if (this.ExamService.qnProgress == 10) {
      this.ExamService.AddStudentAnswer(this.formdata).subscribe(
        (success) => {
          console.log(success);
        },
        (error) => {
          console.log(error);
        });
      clearInterval(this.ExamService.timer);
      this.show=true;

      //this.router.navigate(['/result']);
    }else{
      for (let index = 0; index < this.ExamService.qns[this.ExamService.qnProgress].Options_ID.length; index++) {
        this.AnswerID[index]=parseInt(this.ExamService.qns[this.ExamService.qnProgress].Options_ID[index]);
        this.AnswerBody[index]=this.ExamService.qns[this.ExamService.qnProgress].Options[index];
        if(this.ExamService.qns[this.ExamService.qnProgress].QtypeId==1){
          Object.assign(this.object,{[this.AnswerID[index]]: this.AnswerBody[index]});
        }
        else{
          if(this.AnswerBody[index] !=null){
            Object.assign(this.object,{[this.AnswerID[index]]: this.AnswerBody[index]});
          }
        } 
    }
    console.log(this.formdata)
     this.ExamService.AddStudentAnswer(this.formdata).subscribe(
      (success) => {
        console.log(success);
      },
      (error) => {
        console.log(error);
      });
    }

    
    //localStorage.setItem('qnProgress', this.quizService.qnProgress.toString());

  }

  onSubmit() {
    this.ExamService.CorrectExamQuestions(this.examID).subscribe(
      (success) => {
        console.log(success);
      },
      (error) => {
        console.log(error);
      }
    );
  }


}
