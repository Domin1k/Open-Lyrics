import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from 'src/app/core/services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css', '../../../shared/forms.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  hidenPassword: boolean = true;

  constructor(
    private form: FormBuilder,
    private userSvc: UserService,
    private router: Router) {

    this.loginForm = this.form.group({
      username: ['', [Validators.required, Validators.minLength(2)]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  ngOnInit(): void {
  }

  get f() {
    return this.loginForm.controls;
  }

  login(data) {
    this.userSvc.login(data.username, data.password)
      .subscribe((res) => {
        this.router.navigate(['/'])
      });
  }
}
