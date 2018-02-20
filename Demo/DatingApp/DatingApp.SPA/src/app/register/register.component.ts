import { AuthService } from './../_services/auth.service';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  model = {
    Username: '',
    Password: ''
  };
  @Output()
  cancelRegister = new EventEmitter();

  constructor(private _authService: AuthService) { }

  ngOnInit() {
  }

  register() {
    this._authService.register(this.model)
      .subscribe(() => {
        this._authService.login(this.model);
      }, error => {
        console.log(error);
      });
  }
  cancel() {
    this.cancelRegister.emit(false);
  }
}
