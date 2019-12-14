import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { CourseService } from '../../services/course.service';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {

  image:File;

  constructor(private cookie:CookieService,private myService:CourseService) { }

  ngOnInit() {
    this.myService.test(1).subscribe(
      (s)=>{
        console.log(s);
      },
      (e)=>{
        console.log(e);
      }
    );
  }



  // send():void{
  //   this.myService.test(this.image).subscribe(
  //     (data)=>{console.log(data)},
  //     (err)=>{console.log(err)}
  //   )
  // }

  // processFile(imageInput: any){
  //   const file:File = imageInput.files[0];
  //   const reader = new FileReader();

  //   reader.addEventListener('load', (event: any) => {
  //     this.image = file;
  //   });

  //   reader.readAsDataURL(file);
  // }
}