import { User } from './../models/User';
import { LoginService } from './../services/login.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  user: User;

  loginForm: FormGroup;

  constructor(private fb: FormBuilder, private loginService: LoginService) { }

  ngOnInit() {
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

    console.log(this.loginForm.value, this.loginForm.value.email);

    this.loginService.logIn('http://localhost:65436/api/account/login', this.loginForm.value.email, this.loginForm.value.password)
      .subscribe(value => {
        console.log(value);
        this.user = value;
        this.setUserToLocalStorage(value)
      },
        error => {
          console.error(error);
        });
  }

  setUserToLocalStorage(user: User) {
    localStorage.setItem('user', JSON.stringify(user));
  }

}
