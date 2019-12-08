import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-guest-header',
  templateUrl: './guest-header.component.html',
  styleUrls: ['./guest-header.component.css']
})
export class GuestHeaderComponent implements OnInit {

  hidden:boolean;

  constructor(private authService:AuthService) { }

  ngOnInit() {
    if(this.authService.getCookie())
      this.hidden = true;
    else
      this.hidden = false;
  }

}
