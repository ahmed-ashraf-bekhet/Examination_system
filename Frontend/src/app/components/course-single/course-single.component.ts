import { Component, OnInit } from '@angular/core';
import { CourseService } from '../../services/course.service';
import { ActivatedRoute, Router } from '@angular/router';


import { CreateQuestionsComponent } from '../popups/create-questions/create-questions.component';
import { MatDialog, MatDialogConfig } from '@angular/material';

@Component({
  selector: 'app-course-single',
  templateUrl: './course-single.component.html',
  styleUrls: ['./course-single.component.css']
})
export class CourseSingleComponent implements OnInit {

  course:{};
  courseID:number;

  constructor(public myService:CourseService, public myRouter: ActivatedRoute, private router:Router, private dialog: MatDialog) { }

  ngOnInit() {
    this.courseID = this.myRouter.snapshot.params['id'];
    this.getCourse(this.courseID)
  }



  AddQuestion(courseItemIndex,courseID):void {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.disableClose = true;
    dialogConfig.width = "50%";
    dialogConfig.data = {courseItemIndex ,courseID };
    console.log(courseItemIndex ,courseID);
    this.dialog.open(CreateQuestionsComponent, dialogConfig).afterClosed().subscribe(res => {
      console.log(`Dialog result: M `);
    });
  }

  getCourse(ID:number): void{
    this.myService.getCourse(ID).subscribe(
      (data)=>{
        this.course = data;
      },
      (error)=>{
        console.log(error);
      }
    )
  }

  delete(){
    this.myService.delete(this.courseID).subscribe(
      (success)=>{
        this.router.navigate(['']);
      },
      (error)=>{
        console.log(error)
      }
    )
  }

}
