import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserService } from 'src/app/core/services/user.service';
import { UserRegisterRequestModel } from 'src/app/shared/models/user/user-register-request.model';
import { MustMatch } from 'src/app/shared/validators/mustMatch.validator';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css', '../../../shared/forms.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  error: string;
  hidenPassword: boolean = true;
  hidenConfirmPassword: boolean = true;

  constructor(private form: FormBuilder, private userSvc: UserService, private router: Router) {
    this.registerForm = this.form.group({
      firstName: ['Kris', [Validators.required, Validators.minLength(4)]],
      lastName: ['Lyubenov', [Validators.required, Validators.minLength(4)]],
      username: ['admin', [Validators.required, Validators.minLength(2)]],
      password: ['123123', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['123123', [Validators.required]],
      email: ['admin@mysite.com', [Validators.required, , Validators.email]]
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
    this.userSvc.register(user).subscribe((res) => {
      console.log(`API returned -> ${res}`);
      this.router.navigate(['/user/login', data]);
    });
  }
}