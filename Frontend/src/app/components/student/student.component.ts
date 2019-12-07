import { Component, OnInit, Input } from '@angular/core';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent implements OnInit {
  student = {
    ID: 1,
    Name: "done",
    Username: "sample string 3",
    Password: "sample string 4"
  }
  @Input() title:string;
  constructor(public myService:UserService) { }
  clicked(username,password){
    this.myService.updateInfo(this.student).subscribe(
      (response)=>{
        console.log(response)
        this.title = "Thanks , Your Info Updated Successfully"
      },
      (error)=>{
        console.log(error);
      }
    )
    console.log('dsa')
  }
  ngOnInit() {
  }

}
