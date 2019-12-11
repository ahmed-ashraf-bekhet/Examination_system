import { Component, OnInit, Input, OnChanges } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { TopicService } from '../../../services/topic.service';

@Component({
  selector: 'app-update-topic-modal',
  templateUrl: './update-topic-modal.component.html',
  styleUrls: ['./update-topic-modal.component.css']
})
export class UpdateTopicModalComponent implements OnInit, OnChanges {

  @Input() modal_name: string;
  @Input() data;
  topic: FormGroup;

  constructor(private builder: FormBuilder, private topicService: TopicService) { }

  ngOnInit() {
    console.log(this.data)

    this.topic = this.builder.group({
      ID: [''],
      Name: ['', Validators.required],
      courseID: ['']
    })
  }

  update() {
    if (this.topic.controls.Name.invalid)
      return;

    this.topicService.update(this.topic.value).subscribe(
      (success) => {
        location.reload();
      },
      (error) => {
        console.log(error);
      }
    )
  }

  ngOnChanges(changes: import("@angular/core").SimpleChanges): void {
    if (!changes.data.firstChange) {
      this.topic.controls.Name.setValue(this.data.Name);
      this.topic.controls.ID.setValue(this.data.ID);
      this.topic.controls.courseID.setValue(this.data.courseID);
    }

  }

}
