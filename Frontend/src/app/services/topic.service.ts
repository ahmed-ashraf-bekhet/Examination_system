import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class TopicService {

  constructor(private myHttp: HttpClient, private authService:AuthService) { }

  getTopics(courseID:number){
    return this.myHttp.get(`http://localhost:54345/api/topic/getTopics/${courseID}`)
  }

  delete(ID:number){
    const httpOptions = {
      headers: new HttpHeaders(this.authService.getCookie())
    };

    return this.myHttp.get(`http://localhost:54345/api/topic/delete/${ID}`,httpOptions)
  }

  update(topic){
    return this.myHttp.post("http://localhost:54345/api/topic/update",topic);
  }

  save(topic){
    return this.myHttp.post("http://localhost:54345/api/topic/add",topic);
  }
}
