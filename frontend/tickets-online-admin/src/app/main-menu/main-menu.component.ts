import { User } from './../models/User';
import { Component, OnInit } from '@angular/core';
import { LoginService } from '../services/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main-menu',
  templateUrl: './main-menu.component.html',
  styleUrls: ['./main-menu.component.css']
})
export class MainMenuComponent implements OnInit {
  user: User;

  constructor(private loginService: LoginService, private router: Router) { }

  ngOnInit() {
    this.user = this.loginService.getUserState();
    if (!this.user) {
      this.router.navigate(['/']);
    }
  }

}