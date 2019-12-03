import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-see-all-header',
  templateUrl: './see-all-header.component.html',
  styleUrls: ['./see-all-header.component.css']
})
export class SeeAllHeaderComponent implements OnInit {

  @Input() title:string;
  @Input() link:string;

  constructor() { }

  ngOnInit() {
  }

}
