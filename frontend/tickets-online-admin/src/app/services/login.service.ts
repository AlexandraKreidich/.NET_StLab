import { User } from './../models/User';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Options } from 'selenium-webdriver/firefox';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  logIn(url: string, userEmail: string, userPassword: string): Observable<User> {
    let headers = new HttpHeaders();
    headers = headers.append('Content-Type', 'application/json');
    headers = headers.append('Access-Control-Allow-Origin', '*');

    const body = { email: userEmail, password: userPassword };

    return this.httpClient.post<User>(url, body, { headers: headers });
  }

  constructor(private httpClient: HttpClient) { }
}
