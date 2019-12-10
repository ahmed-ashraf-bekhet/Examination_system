import { Component, OnInit, Input } from '@angular/core';
import { TopicService } from '../../services/topic.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-topics',
  templateUrl: './topics.component.html',
  styleUrls: ['./topics.component.css']
})
export class TopicsComponent implements OnInit {

  @Input() courseID: number;
  update_modal: string = "updateTopicModal";
  topics;

  constructor(private topicService: TopicService, private router: Router) { }

  ngOnInit() {
    this.getTopics();
  }

  getTopics() {
    this.topicService.getTopics(this.courseID).subscribe(
      (data) => {
        this.topics = data;
      },
      (error) => {
        console.log(error);
      }
    )
  }

  delete(ID) {
    this.topicService.delete(ID).subscribe(
      (success) => {
        this.router.navigateByUrl('/RefreshComponent', { skipLocationChange: true }).then(() => {
          this.router.navigate(['/courses', this.courseID]);
        });
      },
      (error) => {
        console.log(error);
      }
    )
  }
}
