import { Component, OnInit } from '@angular/core';
import { EmailService } from 'src/app/services/email.service';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {

  constructor(public webService:EmailService) { }
  mail
  ngOnInit() {}
  clicked(name,email,subject,message){
    this.mail = {
      "to": "lool98439@gmail.com",
      "from": "ahmedashrafhero@gmail.com",
      "subject": subject,
      "body": "sender name : "+name+" , his/her Email : "+email+" , his/her message : "+message
    }
    this.webService.sendEmail(this.mail).subscribe(
      (res)=>{
        console.log(res)
        alert("Your mail sent successfully");
      },
      (error)=>{
        console.log(error);
        alert("Ooh , something wrong please try send your mail again ..");
      }
    )
  }

}
