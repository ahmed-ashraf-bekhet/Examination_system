import { Component, OnInit, Input } from '@angular/core';
import { TopicService } from '../../services/topic.service';

@Component({
  selector: 'app-topics',
  templateUrl: './topics.component.html',
  styleUrls: ['./topics.component.css']
})
export class TopicsComponent implements OnInit {

  @Input() courseID:number;
  topics;

  constructor(private topicService:TopicService) { }

  ngOnInit() {
    this.getTopics();
  }

  getTopics(){
    this.topicService.getTopics(this.courseID).subscribe(
      (data)=>{
        this.topics = data;
        console.log(this.topics)
      },
      (error)=>{
        console.log(error);
      }
    )
  }
}
