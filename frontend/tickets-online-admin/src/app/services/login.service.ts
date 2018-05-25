import { User } from './../models/User';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { Options } from 'selenium-webdriver/firefox';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  public $isAuthorized = new Subject<boolean>();

  url = 'http://localhost:65436/api/account/login';

  logIn(userEmail: string, userPassword: string) {
    let headers = new HttpHeaders();
    headers = headers.append('Content-Type', 'application/json');
    headers = headers.append('Access-Control-Allow-Origin', '*');

    const body = { email: userEmail, password: userPassword };

    this.httpClient.post<User>(this.url, body, { headers: headers }).subscribe(value => {
      if (value.token) {
        this.setUserToLocalStorage(value);
        this.setIsAuthorizedValue(true);
      }
    }, error => {
      console.error(error);
    });
  }

  setIsAuthorizedValue(value: boolean) {
    this.$isAuthorized.next(value);
  }

  setUserToLocalStorage(user: User) {
    localStorage.setItem('user', JSON.stringify(user));
  }

  getUserState(): User {
    let user = JSON.parse(localStorage.getItem("user"));
    if (user && !this.$isAuthorized) {
      this.setIsAuthorizedValue(true);
    }
    return user;
  }

  removeUserFromLocalStorage() {
    localStorage.removeItem("user");
    this.setIsAuthorizedValue(false);
  }

  constructor(private httpClient: HttpClient) { }
}
