import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  hidden:boolean;

  constructor(private authService:AuthService) { }

  ngOnInit() {
    if(this.authService.getCookie())
      this.hidden = false;
    else
      this.hidden = true;
  }

  logout(){
    console.log("logout")
    this.authService.deleteCookie();
  }

}
