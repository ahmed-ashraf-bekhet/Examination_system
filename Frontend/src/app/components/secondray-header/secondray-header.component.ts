import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-secondary-header',
  templateUrl: './secondray-header.component.html',
  styleUrls: ['./secondray-header.component.css']
})
export class SecondrayHeaderComponent implements OnInit {
  @Input() title:string;
  @Input() minor_title:string;

  constructor() { }

  ngOnInit() {
  }

}
