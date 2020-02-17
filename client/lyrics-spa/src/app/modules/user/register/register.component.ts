import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserService } from 'src/app/core/services/user.service';
import { UserRegisterRequestModel } from 'src/app/shared/models/user/user-register-request.model';
import { MustMatch } from 'src/app/shared/validators/mustMatch.validator';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material';
import { userValidation } from 'src/app/shared/models/user/user-validation.constants';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  error: string;
  hidenPassword: boolean = true;
  hidenConfirmPassword: boolean = true;

  constructor(
    private form: FormBuilder,
    private userSvc: UserService,
    private router: Router,
    private snackBar: MatSnackBar) {

    this.registerForm = this.form.group({
      firstName: ['', [Validators.required, Validators.minLength(userValidation.firstNameLength)]],
      lastName: ['', [Validators.required, Validators.minLength(userValidation.lastNameLength)]],
      username: ['', [Validators.required, Validators.minLength(userValidation.usernameLength)]],
      password: ['', [Validators.required, Validators.minLength(userValidation.passwordLength)]],
      confirmPassword: ['', [Validators.required]],
      email: ['', [Validators.required, , Validators.email]]
    },
      {
        validator: MustMatch('password', 'confirmPassword')
      });
  }

  get f() {
    return this.registerForm.controls;
  }

  ngOnInit(): void {
  }

  register(data) {
    const user: UserRegisterRequestModel = data as UserRegisterRequestModel;
    if (user) {
      this.userSvc.register(user).subscribe((res) => {
        this.router.navigate(['/user/login', data]);
        this.snackBar.open('User registered successfully', '', {duration: 1500, verticalPosition: 'top'})
      });
    } else {
      this.snackBar.open('Form data is invalid', 'Error', { duration: 2000, verticalPosition: 'top', horizontalPosition: 'center' });
    }
  }
}
