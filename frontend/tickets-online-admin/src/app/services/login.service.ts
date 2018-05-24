import { User } from './../models/User';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { Options } from 'selenium-webdriver/firefox';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  user$: BehaviorSubject<User>;

  logIn(url: string, userEmail: string, userPassword: string): Observable<User> {
    let headers = new HttpHeaders();
    headers = headers.append('Content-Type', 'application/json');
    headers = headers.append('Access-Control-Allow-Origin', '*');

    const body = { email: userEmail, password: userPassword };

    return this.httpClient.post<User>(url, body, { headers: headers });
  }

  setUser(user: User) {
    this.user$.next(user);
  }

  setUserToLocalStorage(user: User) {
    localStorage.setItem('user', JSON.stringify(user));
  }

  constructor(private httpClient: HttpClient) { }
}
