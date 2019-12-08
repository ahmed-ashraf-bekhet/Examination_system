import { Injectable } from '@angular/core';
import {CookieService} from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(public cookie:CookieService) { }

  getCookie(){
    // for testing
    this.setCookie(1,2,0);

    return {
      'userID': this.cookie.get('userID'),
      'userTypeID': this.cookie.get('userTypeID'),
      'isAdmin': this.cookie.get('isAdmin')
    }
  }

  setCookie(userID,userTypeID,isAdmin){
    this.cookie.set('userID', userID);
    this.cookie.set('userTypeID', userTypeID);
    this.cookie.set('isAdmin',isAdmin);
  }
}
