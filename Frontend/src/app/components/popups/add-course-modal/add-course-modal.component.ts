import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CourseService } from '../../../services/course.service';

@Component({
  selector: 'app-add-course-modal',
  templateUrl: './add-course-modal.component.html',
  styleUrls: ['./add-course-modal.component.css']
})
export class AddCourseModalComponent implements OnInit {

  @Input() modal_name:string;
  course:FormGroup;

  constructor(private builder:FormBuilder,private courseService:CourseService) { }

  ngOnInit() {
    this.course = this.builder.group({
      Name:['',Validators.required],
      Description:['', Validators.required]
    })
  }

  save(){
    const controls = this.course.controls;
    for (const name in controls) {
        if (controls[name].invalid) {
            return;
        }
    }

console.log(this.course.value)

    // this.courseService.save(this.course.value).subscribe(
    //   (success)=>{
    //     location.href = '/courses'
    //   },
    //   (error)=>{
    //     console.log(error);
        
    //   }
    // )
  }

}
