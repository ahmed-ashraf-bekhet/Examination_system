import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { CourseService } from '../../services/course.service';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {

  constructor(private cookie:CookieService,private myService:CourseService) { }

  ngOnInit() {
  }

  send():void{
    this.cookie.set('userID','1');
    this.cookie.set('userTypeID','1');

    this.myService.test().subscribe(
      (data)=>{console.log(data)},
      (err)=>{console.log(err)}
    )
  }

}
