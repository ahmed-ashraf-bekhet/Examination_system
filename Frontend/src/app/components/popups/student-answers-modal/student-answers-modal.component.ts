import { Component, OnInit, Input } from '@angular/core';
import { UserService } from '../../../services/user.service';
import { ExamService } from '../../../services/exam.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-student-answers-modal',
  templateUrl: './student-answers-modal.component.html',
  styleUrls: ['./student-answers-modal.component.css']
})
export class StudentAnswersModalComponent implements OnInit {

  @Input() modal_name: string;
  students;
  exams;
  form: FormGroup;

  constructor(private builder: FormBuilder, private examService: ExamService, private userService: UserService) { }

  ngOnInit() {
    this.getAllStudents();
    this.getAllExams();

    this.form = this.builder.group({
      StudentID: ['', Validators.required],
      ExamID: ['', Validators.required]
    })
  }

  getReport(){
    this.examService.getStudentAnswers(this.form.value).subscribe(
      (success)=>{
        console.log(success);
      },
      (error)=>{
        console.log(error);
      }
    )
  }

  getAllStudents(){
    this.userService.getAllStudents().subscribe(
      (data)=>{
        this.students = data;
      },
      (error)=>{
        console.log(error);
      }
    )
  }

  getAllExams(){
    this.examService.getAllExams().subscribe(
      (data)=>{
        this.exams = data;
        console.log(data)
      },
      (error)=>{
        console.log(error);
      }
    )
  }
}
