import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-exam-header',
  templateUrl: './exam-header.component.html',
  styleUrls: ['./exam-header.component.css']
})
export class ExamHeaderComponent implements OnInit {
  @Input() title:string;
  @Input() minor_title:string;
  constructor() { }

  ngOnInit() {
  }

}
