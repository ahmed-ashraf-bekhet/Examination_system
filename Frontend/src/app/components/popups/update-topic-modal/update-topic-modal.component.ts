import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { TopicService } from '../../../services/topic.service';

@Component({
  selector: 'app-update-topic-modal',
  templateUrl: './update-topic-modal.component.html',
  styleUrls: ['./update-topic-modal.component.css']
})
export class UpdateTopicModalComponent implements OnInit {
  @Input() modal_name:string;
  @Input() courseID:string;
  topic:FormGroup;

  constructor(private builder:FormBuilder,private topicService:TopicService) { }

  ngOnInit() {
    this.topic = this.builder.group({
      Name:['',Validators.required]
    })
  }

  update(){
    if(this.topic.controls.Name.invalid)
      return;

    this.topicService.update(this.topic.value).subscribe(
      (success)=>{
        location.href = `/courses/${this.courseID}`;
      },
      (error)=>{
        console.log(error);
      }
    )
  }

}
