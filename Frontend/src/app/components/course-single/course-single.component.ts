import { Component, OnInit } from '@angular/core';
import { CourseService } from '../../services/course.service';
import { AuthService } from '../../services/auth.service';
import { ActivatedRoute, Router } from '@angular/router';


import { CreateQuestionsComponent } from '../popups/create-questions/create-questions.component';
import { MatDialog, MatDialogConfig } from '@angular/material';

@Component({
  selector: 'app-course-single',
  templateUrl: './course-single.component.html',
  styleUrls: ['./course-single.component.css']
})
export class CourseSingleComponent implements OnInit {

  hidden:boolean;
  isAdmin:boolean = false;
  generate_exam_modal:string = "generateExamModal";

  course:{};
  courseID:number;
  update_modal = "updateCourseModal";

  constructor(public courseService:CourseService, private authService:AuthService, public myRouter: ActivatedRoute, private router:Router,private dialog: MatDialog) { }

  ngOnInit() {
    var cookie = this.authService.getCookie();
    if(!cookie || cookie.userTypeID == "2")
      this.hidden = true;
    else if(cookie.isAdmin == "1"){
      this.hidden = false;
      this.isAdmin = true;
    }
    else{
      this.hidden = false;
    }

    this.courseID = this.myRouter.snapshot.params['id'];
    this.getCourse(this.courseID)
  }

  getTopicsReport(){
    this.courseService.getTopicsReport(this.courseID).subscribe(
      (success)=>{
        console.log(success);
      },
      (error) =>{
        console.log(error);
      }
    )
  }


  AddQuestion(courseItemIndex,courseID):void {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.disableClose = true;  
    dialogConfig.width = "50%";
    dialogConfig.height="50%";
    dialogConfig.position={
    top: '20%',
    };
    dialogConfig.data = {courseItemIndex ,courseID };
    this.dialog.open(CreateQuestionsComponent, dialogConfig).afterClosed().subscribe(res => {
      console.log(`Dialog result: M `);
    });
  }

  getCourse(ID:number): void{
    this.courseService.getCourse(ID).subscribe(
      (data)=>{
        this.course = data;
      },
      (error)=>{
        console.log(error);
      }
    )
  }

  delete(){
    this.courseService.delete(this.courseID).subscribe(
      (success)=>{
        this.router.navigate(['']);
      },
      (error)=>{
        console.log(error)
      }
    )
  }

}
