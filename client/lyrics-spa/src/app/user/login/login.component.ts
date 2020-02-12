import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css', '../../shared/forms.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  error: string;
  hidenPassword: boolean = true;

  constructor(private form: FormBuilder) {
    this.loginForm = this.form.group({
      username: 'admin',
      password: '123456'
    });
   }

  ngOnInit(): void {
  }

  login(data) {
    console.log(data);
  }
}
