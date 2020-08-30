import {Component, OnInit, Output, EventEmitter} from '@angular/core';
import {AuthService} from '../../../_services/auth.service';
import {AlertifyService} from '../../../_services/alertify.service';
import {Router} from '@angular/router';
import {SignInDialogComponent} from './sign-in-dialog/sign-in-dialog.component';
import {MatDialog} from '@angular/material/dialog';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  @Output() toggleSideBarAfterClick: EventEmitter<any> = new EventEmitter();

  constructor(public dialog: MatDialog, private authService: AuthService, private router: Router, private alertify: AlertifyService) { }

  ngOnInit(): void {
  }

  toggleSideBar() {
    this.toggleSideBarAfterClick.emit();
  }

  openSignInDialog(): void {
    const dialogRef = this.dialog.open(SignInDialogComponent, {
    });

    dialogRef.afterClosed().subscribe(result => {
    });
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  logout() {
    this.authService.logout();
    localStorage.removeItem('token');
    this.alertify.success('logged out');
    this.router.navigate(['/home']);
  }
}
