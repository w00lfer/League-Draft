import {Injectable} from '@angular/core';
import {CanActivate, CanLoad, Router} from '@angular/router';
import {AuthService} from "../_services/auth.service";
import {AlertifyService} from "../_services/alertify.service";
import {UserRole} from "../_models/enums/user-role";

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate, CanLoad {

  constructor(
    private authService: AuthService,
    private router: Router,
    private alertify: AlertifyService) {}

  canActivate() {
    if (this.authService.loggedIn() && this.authService.userRole == UserRole.Admin) {
      {
        console.log('ssss');
        return true;
      }
    }

    this.router.navigate(['/dashboard']);
    return false;
  }
  canLoad() {
    if (this.authService.loggedIn() && this.authService.userRole == UserRole.Admin)
      return true;
    return false;
  }
}
