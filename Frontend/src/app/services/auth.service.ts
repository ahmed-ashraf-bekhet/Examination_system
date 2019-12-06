import { Injectable } from '@angular/core';
import {CookieService} from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(public cookie:CookieService) { }

  getCookie(){
    // for testing
    this.setCookie(1,2);

    return {
      'userID': this.cookie.get('userID'),
      'userTypeID': this.cookie.get('userTypeID')
    }
  }

  setCookie(userID,userTypeID){
    this.cookie.set('userID', userID);
    this.cookie.set('userTypeID', userTypeID);
  }
}
