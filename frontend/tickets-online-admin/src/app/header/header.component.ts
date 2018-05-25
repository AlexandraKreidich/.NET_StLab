import { LoginComponent } from './../login/login.component';
import { User } from './../models/User';
import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../services/login.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  private isAuthorizedSubscription: Subscription;

  @Input() user: User;

  constructor(private router: Router, private loginService: LoginService) { }

  ngOnInit() {
    this.isAuthorizedSubscription = this.loginService.$isAuthorized.subscribe((value) => {
      console.log('header', value);
      if (value) {
        this.user = this.loginService.getUserState();
      } else {
        this.user = null;
      }
    });
    this.user = this.loginService.getUserState();
  }

  logOut() {
    this.loginService.removeUserFromLocalStorage();
    this.router.navigate(['']);
  }

  ngOnDestroy() {
    if (this.isAuthorizedSubscription) {
      this.isAuthorizedSubscription.unsubscribe();
    }
  }

}
