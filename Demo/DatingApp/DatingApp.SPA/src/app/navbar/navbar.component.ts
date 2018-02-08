import { Component, OnInit } from '@angular/core';
import { log } from 'util';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  model: any = {};

  constructor() { }

  ngOnInit() {
  }

  login() {
    console.log(this.model);
  }
}
