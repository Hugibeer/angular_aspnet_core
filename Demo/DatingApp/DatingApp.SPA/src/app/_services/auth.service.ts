import { Injectable } from '@angular/core';
import { Http, RequestOptions, Headers, Response } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class AuthService {
  private baseUrl = 'http://localhost:50000/api/auth';
  private token: any;
  private userTokenKey = 'DatingApp.Auth.UserToken';

  constructor(private http: Http) {}

  register(model: any) {
    return this.http.post(this.baseUrl + '/register', model, this.requestOptions());
  }

  login(model: any) {
    return this.http.post(this.baseUrl + '/login', model, this.requestOptions())
      .map((response: Response) => {
        const user = response.json();
        if (user) {
          localStorage.setItem(this.userTokenKey, user.tokenString);
          this.token = user.tokenString;
        }
      });
  }
  logout() {
    this.token = null;
    localStorage.removeItem(this.userTokenKey);
  }

  loggedIn() {
    const token = localStorage.getItem(this.userTokenKey);
    return token != null && token.length > 0;
  }

  private requestOptions() {
    const headers = new Headers({
      'Content-Type': 'application/json'
    });
    const options = new RequestOptions({
      headers: headers
    });
    return options;
  }
}