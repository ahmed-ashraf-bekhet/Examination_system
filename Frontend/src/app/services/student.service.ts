import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(private myHttp: HttpClient) { }


  getCountOfStudent(){
    return this.myHttp.get("http://localhost:54345/api/Student");
  }

  
}
