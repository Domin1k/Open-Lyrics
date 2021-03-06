import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from 'src/app/core/services/user.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material';
import { userValidation } from 'src/app/shared/models/user/user-validation.constants';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  hidenPassword: boolean = true;

  constructor(
    private form: FormBuilder,
    private userSvc: UserService,
    private router: Router,
    private snackBar: MatSnackBar) {

    this.loginForm = this.form.group({
      username: ['', [Validators.required, Validators.minLength(userValidation.usernameLength)]],
      password: ['', [Validators.required, Validators.minLength(userValidation.passwordLength)]]
    });
  }

  ngOnInit(): void {
  }

  get f() {
    return this.loginForm.controls;
  }

  login(data) {
    this.userSvc.login(data.username, data.password)
      .subscribe(() => {
        this.snackBar.open('User logged in successfully', '', { duration: 1500, verticalPosition: 'top' })
        this.router.navigate(['/'])
      });
  }
}
