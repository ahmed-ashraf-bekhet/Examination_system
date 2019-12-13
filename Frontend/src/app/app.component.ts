import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'Frontend';
  course_modal:string = "addCourseModal";
  department_modal:string = "department_modal";
  student_modal:string = "student_modal";
  teacher_modal:string = "teacher_modal";
}
