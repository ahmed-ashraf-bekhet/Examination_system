import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { TopicService } from '../../../services/topic.service';
import { CourseService } from '../../../services/course.service';

@Component({
  selector: 'app-add-topic-modal',
  templateUrl: './add-topic-modal.component.html',
  styleUrls: ['./add-topic-modal.component.css']
})

export class AddTopicModalComponent implements OnInit {

  @Input() modal_name: string;
  topic: FormGroup;
  courses;

  constructor(private builder: FormBuilder, private topicService: TopicService, private courseService:CourseService) { }

  ngOnInit() {
    this.getAllCourses();
    this.topic = this.builder.group({
      Name: ['', Validators.required],
      CourseID: ['',Validators.required]
    })
  }

  save() {
    const controls = this.topic.controls;
    for (const name in controls) {
      if (controls[name].invalid) {
        return;
      }
    }
console.log(this.topic.value)
    this.topicService.save(this.topic.value).subscribe(
      (success) => {
        console.log(success);
      },
      (error) => {
        console.log(error);
      }
    )
  }

  getAllCourses(){
    this.courseService.getAllCourses().subscribe(
      (data)=>{
        this.courses = data;
      },
      (error)=>{
        console.log(error);
      }
    )
  }

}
