import { Component, OnInit } from '@angular/core';
import { CourseService } from 'src/app/services/course.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.css']
})
export class QuestionsComponent implements OnInit {

  constructor(public activatedRoute: ActivatedRoute, public webService: CourseService) { }
  id
  questions
  ngOnInit() {
    this.id = this.activatedRoute.snapshot.params['id']
    this.webService.getCourseQuestions(this.id).subscribe(
      (response) => {
        this.questions = response
        console.log(response)
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
