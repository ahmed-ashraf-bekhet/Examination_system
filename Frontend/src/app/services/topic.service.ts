import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TopicService {

  constructor(private myHttp: HttpClient) { }

  getTopics(courseID:number){
    return this.myHttp.get(`http://localhost:6755/api/topic/getTopics/${courseID}`)
  }
}
