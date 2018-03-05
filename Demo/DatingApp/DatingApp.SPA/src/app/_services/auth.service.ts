import { Injectable } from '@angular/core';
import { Http, RequestOptions, Headers, Response } from '@angular/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class AuthService {
  private baseUrl = 'http://localhost:50000/api/auth';
  private token: any;
  private userTokenKey = 'DatingApp.Auth.UserToken';

  constructor(private http: Http) {}

  register(model: any) {
    return this.http
          .post(this.baseUrl + '/register', model, this.requestOptions())
          .catch(this.handleError);
  }

  login(model: any) {
    return this.http.post(this.baseUrl + '/login', model, this.requestOptions())
      .map((response: Response) => {
        const user = response.json();
        if (user) {
          localStorage.setItem(this.userTokenKey, user.tokenString);
          this.token = user.tokenString;
        }
      }).catch(this.handleError);
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

  private handleError(error: any) {
    const applicationError = error.headers.get('Application-Error');
    if (applicationError) {
      return Observable.throw(applicationError);
    }

    const serverError = error.json();
    let modelStateErrors = '';
    if (serverError) {
      for (const key in serverError) {
        if (serverError[key]) {
          modelStateErrors += serverError[key] + '\n';
        }
      }
    }
    return Observable.throw(modelStateErrors || 'Server error');
  }
}