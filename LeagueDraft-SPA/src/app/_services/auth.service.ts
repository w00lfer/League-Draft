
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map} from 'rxjs/operators';
import { JwtHelperService} from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';
import {SignInUser} from '../_models/sign-in-user';
import {SignUpUser} from '../_models/sign-up-user';
import {UserRole} from "../_models/enums/user-role";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = environment.apiUrl + 'auth/';
  jwtHelper = new JwtHelperService();
  decodedToken: any;
  userRole: UserRole;
  userName: string;

  constructor(private http: HttpClient) { }

  login(signInUser: SignInUser) {
    return this.http.post(this.baseUrl + 'login', signInUser)
      .pipe(
        map((response: any) => {
          const user = response;
          if (user) {
            localStorage.setItem('token', user.token);
            this.setUserInfo(user.token)
          }
        })
      );
  }

  register(signUpUser: SignUpUser) {
    return this.http.post(this.baseUrl + 'register', signUpUser)
      .pipe(
        map((response: any) => {
          const user = response;
          if (user) {
            localStorage.setItem('token', user.token);
            this.setUserInfo(user.token)
          }
        })
      );
  }

  logout(){
    return this.http.post(this.baseUrl + 'logout', new HttpHeaders({Authorization: 'Bearer ' + localStorage.getItem('token')}));
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }

  setUserInfo(token: string): void {
    this.decodedToken = this.jwtHelper.decodeToken(token);
    this.setUserNameAndRole();
  }

  private setUserNameAndRole(): void {
    this.userName = this.decodedToken.unique_name;
    this.userRole = this.decodedToken.role;
  }

}
