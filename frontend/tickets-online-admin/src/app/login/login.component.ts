import { User } from './../models/User';
import { LoginService } from './../services/login.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BehaviorSubject, Subscription } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  private isAuthorizedSubscription: Subscription;

  user: User;

  loginForm: FormGroup;

  constructor(private fb: FormBuilder, private loginService: LoginService, private router: Router) { }

  ngOnInit() {
    this.isAuthorizedSubscription = this.loginService.$isAuthorized.subscribe((value) => {
      if (value) {
        this.user = this.loginService.getUserState();
        this.gotoMaimMenu();
      } else {
        this.user = null;
      }
    });
    this.user = this.loginService.getUserState();
    if (this.user) {
      this.gotoMaimMenu();
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

    this.loginService.logIn(this.loginForm.value.email, this.loginForm.value.password);
  }

  gotoMaimMenu() {
    this.router.navigate(['/menu']);
  }

  ngOnDestroy() {
    if (this.isAuthorizedSubscription) {
      this.isAuthorizedSubscription.unsubscribe();
    }
  }
}
