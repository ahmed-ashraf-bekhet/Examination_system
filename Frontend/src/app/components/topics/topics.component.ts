import { Component, OnInit, Input } from '@angular/core';
import { TopicService } from '../../services/topic.service';
import { AuthService } from '../../services/auth.service';
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
  topic;
  hidden:boolean = false;

  constructor(private topicService: TopicService, private authService:AuthService, private router: Router) { }

  ngOnInit() {
    var cookie = this.authService.getCookie();
    if(!cookie || cookie.isAdmin == "0")
      this.hidden = true;

    this.getTopics();
  }

  setTopic(ID,Name){
    this.topic = {ID,Name,courseID:this.courseID};
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
