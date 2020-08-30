
import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { SignUpUser } from '../_models/sign-up-user';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  signUpUser: SignUpUser = new SignUpUser();

  constructor(private authService: AuthService, private alertify: AlertifyService) {
  }

  ngOnInit() {
  }

  register() {
    this.authService.register(this.signUpUser).subscribe(() => {
      this.alertify.success('Registration succesful');
    }, error => {
      this.alertify.error(error);
    });
  }
}
