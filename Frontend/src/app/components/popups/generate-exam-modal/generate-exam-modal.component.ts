import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators} from '@angular/forms';
import { ExamService } from '../../../services/exam.service';

@Component({
  selector: 'app-generate-exam-modal',
  templateUrl: './generate-exam-modal.component.html',
  styleUrls: ['./generate-exam-modal.component.css']
})
export class GenerateExamModalComponent implements OnInit {

  @Input() courseID:number;
  @Input() modal_name:string;
  exam:FormGroup;
  constructor(private builder:FormBuilder, private examService:ExamService) { }

  ngOnInit() {
    this.exam = this.builder.group({
      Title: ['',Validators.required],
      Duration: ['',[Validators.required,Validators.min(0)]],
      TFQuestionsNumber: ['',[Validators.required,Validators.min(0)]],
      MCQQuestionsNumber: ['',[Validators.required,Validators.min(0)]],
      CourseID: this.courseID
    })
  }

  save() {
    const controls = this.exam.controls;
    for (const name in controls) {
      if (controls[name].invalid) {
        return;
      }
    }

    this.examService.save(this.exam.value).subscribe(
      (success) => {
        console.log(success);
      },
      (error) => {
        console.log(error);
      }
    )
  }

}
