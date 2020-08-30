import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { AuthService } from 'src/app/_services/auth.service';
import { SignInUser } from 'src/app/_models/sign-in-user';
import { Router } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Component({
  selector: 'app-sign-in-dialog',
  templateUrl: './sign-in-dialog.component.html',
  styleUrls: ['./sign-in-dialog.component.css']
})
export class SignInDialogComponent implements OnInit {
  signInUser: SignInUser = new SignInUser();

  constructor(private dialogRef: MatDialogRef<SignInDialogComponent>, private authService: AuthService, private router: Router, private alertify: AlertifyService) {}

  ngOnInit() {
  }

  login() {
    this.authService.login(this.signInUser).subscribe(() => {
      this.closeDialog();
      this.alertify.success('Logged in successfully!');
      this.router.navigate(['/dashboard']) ;
    }, error => {
      this.alertify.error(error);
    });
  }

  closeDialog(): void {
    this.dialogRef.close();
  }

}
