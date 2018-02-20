import { Component, OnInit } from '@angular/core';
import { log } from 'util';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  model: any = {};

  constructor(private _authService: AuthService) { }

  ngOnInit() {
  }

  login() {
    this._authService.login(this.model)
      .subscribe(data => {
        console.log('success');
      }, error => {
        console.log('error happened');
      });
  }
  logout() {
    this._authService.logout();
  }
  loggedIn() {
    return this._authService.loggedIn();
  }
}
