import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EmailService {

  constructor(public myHttp:HttpClient) { }

  sendEmail(maiiiil){
    let mail = {
      "to": "lool98439@gmail.com",
      "from": "ahmedashrafhero@gmail.com",
      "subject": "sample string 333",
      "body": "sample string 333"
    }
    return this.myHttp.post("http://localhost:54345/api/Email",maiiiil);
  }
}
