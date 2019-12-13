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
  isValid: boolean = true;
  tittle:string ="ADD Question";
  formAns:{
    Answer1:string,
    Answer2:string,
    Answer3:string,
    Answer4:string
  };
  constructor( 
    @Inject(MAT_DIALOG_DATA) public data,
    public dialogRef: MatDialogRef<CreateQuestionsComponent>,
    private QService:QuestionService) { }



  ngOnInit() {
    this.QService.getAllTypeOFQuestions().subscribe(res => this.typeList = res as Type[]);
    if (this.data.courseItemIndex == null){
      this.formData = {
        Question: '',
        courseID: this.data.courseID,
        TypeID: 0,
        Answer:[''],
        R_Answer: 0,
      }
      this.formAns = {
        Answer1: '',
        Answer2: '',
        Answer3: '',
        Answer4: ''
      }
    }
   
    else
      this.formData = Object.assign({}, this.QService.CreateQuestion[this.data.courseItemIndex]);
  }

  isMcQ(){
    if(this.formData.TypeID==1){
      this.formData.Answer=[
        this.formAns.Answer1.trim(),
        this.formAns.Answer2.trim(),
        this.formAns.Answer3.trim(),
        this.formAns.Answer4.trim()];
      return true;
    }
    else
    {
      return false;
    }
  }

  isTandF(){
    if(this.formData.TypeID==2){
      this.formData.Answer=[
        '1) True',
        '2) False'
      ]
      return true;
    }
    else
    {
      return false;
    }
  }

  onSubmit() {
    if (this.validateForm(this.formData)) {
      if (this.data.courseItemIndex == null){
        this.QService.Add(this.formData).subscribe(
          (success) => {
            console.log(success);
          },
          (error) => {
            console.log(error);
          }
        );
       } 
      else
        this.QService.CreateQuestion[this.data.courseItemIndex] = this.formData;
      this.dialogRef.close();
    }
  }

  validateForm(formData: CreateQuestion) {
    this.isValid = true;
    if (formData.Question == '')
      this.isValid = false;
    else if (formData.TypeID == 0)
      this.isValid = false;
    else if (formData.R_Answer == 0)
      this.isValid = false;
    else if (!(formData.Answer.length > 0))
      this.isValid = false;
    return this.isValid;
  }


}
