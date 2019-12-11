import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material";
import { CreateQuestion } from 'src/app/services/create-question.model';
import { QuestionService } from 'src/app/services/question.service';
import { Type } from 'src/app/services/type.model';

@Component({
  selector: 'app-create-questions',
  templateUrl: './create-questions.component.html',
  styleUrls: ['./create-questions.component.css']
})
export class CreateQuestionsComponent implements OnInit {
  formData: CreateQuestion;
  typeList:Type[];

  constructor( 
    @Inject(MAT_DIALOG_DATA) public data,
    public dialogRef: MatDialogRef<CreateQuestionsComponent>,
    private QService:QuestionService) { }



  ngOnInit() {
    this.QService.getAllTypeOFQuestions().subscribe(res => this.typeList = res as Type[]);
    if (this.data.courseItemIndex == null)
      this.formData = {
        Question: null,
        courseID: this.data.courseID,
        TypeID: 0,
        Answer: [''],
        R_Answer: 0,
      }
    else
      this.formData = Object.assign({}, this.QService.CreateQuestion[this.data.courseItemIndex]);
  }

}
