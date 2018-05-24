import { LoginComponent } from './../login/login.component';
import { User } from './../models/User';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../services/login.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  user: Subscription;

  constructor(private router: Router, private loginService: LoginService) { }

  ngOnInit() {
    this.user = this.loginComponent.user$.subscribe();
    this.user = JSON.parse(localStorage.getItem("user"));
  }

  logOut() {
    localStorage.removeItem("user");
    this.router.navigate(['']);
  }

}
