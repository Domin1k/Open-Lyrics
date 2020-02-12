import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators, AbstractControl } from '@angular/forms';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css', '../../shared/forms.css']
})
export class CreateComponent implements OnInit {
  createLyricForm: FormGroup;
  error: string;
  
  constructor(private form: FormBuilder) {
    this.createLyricForm = this.form.group({
     singer: ['', Validators.required],
     text: ['', Validators.required],
     title: ['', Validators.required]
    });
  }

  ngOnInit() {
  }

  create(formData: AbstractControl) {
    console.log(formData)
  }
}
