import { User } from './../models/User';
import { LoginService } from './../services/login.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  user: Subscription;

  loginForm: FormGroup;

  constructor(private fb: FormBuilder, private loginService: LoginService, private router: Router) { }

  ngOnInit() {
    this.user = JSON.parse(localStorage.getItem("user"));

    if (this.user$ !== null) {
      this.gotoMaimMenu();
    } else {
      console.log(this.user$);
    }

    this.initForm();
  }

  initForm() {
    this.loginForm = this.fb.group({
      email: ['', [
        Validators.required,
        Validators.email
      ]],
      password: [null, [
        Validators.required
      ]]
    });
  }

  isControlInvalid(controlName: string): boolean {
    const control = this.loginForm.controls[controlName];
    const result = control.invalid && control.touched;

    return result;
  }

  onSubmit() {
    const controls = this.loginForm.controls;

    if (this.loginForm.invalid) {
      Object.keys(controls)
        .forEach(controlName => controls[controlName].markAsTouched());
      return;
    }

    this.loginService.logIn('http://localhost:65436/api/account/login', this.loginForm.value.email, this.loginForm.value.password)
      .subscribe(value => {
        this.setUser(value);
        this.loginService.setUserToLocalStorage(value)
      },
        error => {
          console.error(error);
        });
  }

  gotoMaimMenu() {
    this.router.navigate(['/menu']);
  }

  loginUser(email: string, password: string) {

  }
}
