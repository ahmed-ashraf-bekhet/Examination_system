import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material";
import { CourseSingleComponent } from '../../course-single/course-single.component';

@Component({
  selector: 'app-create-questions',
  templateUrl: './create-questions.component.html',
  styleUrls: ['./create-questions.component.css']
})
export class CreateQuestionsComponent implements OnInit {

  constructor( 
    @Inject(MAT_DIALOG_DATA) public data,
    public dialogRef: MatDialogRef<CreateQuestionsComponent>) { }

  ngOnInit() {
  }

}
