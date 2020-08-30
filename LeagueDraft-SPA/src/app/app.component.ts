import {Component, OnInit} from '@angular/core';
import {AuthService} from './_services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'LeagueDraft-SPA';
  sideBarOpen = false;

  constructor(public authService: AuthService) {
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  sideBarToggle($event: any) {
    this.sideBarOpen = !this.sideBarOpen;
  }

  ngOnInit() {
    const token = localStorage.getItem('token');
    if (token) {
      this.authService.setUserInfo(token);
    }
  }
}
