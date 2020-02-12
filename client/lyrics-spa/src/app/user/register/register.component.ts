import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css', '../../shared/forms.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  error: string;
  hidenPassword: boolean = true;
  hidenConfirmPassword: boolean = true;

  constructor(private form: FormBuilder) {
    this.registerForm = this.form.group({
      username: 'admin',
      password: '123456',
      confirmPassword: '123456',
      email: 'admin@mysite.com'
    });
  }

  ngOnInit(): void {
  }

  register(data) {
    console.log(data);
  }
}
