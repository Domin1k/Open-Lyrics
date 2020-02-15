import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators, AbstractControl } from '@angular/forms';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css', '../../../shared/forms.css']
})
export class CreateComponent implements OnInit {
  createLyricForm: FormGroup;
  
  constructor(private form: FormBuilder) {
    this.createLyricForm = this.form.group({
     singer: ['', [Validators.required, Validators.minLength(2)]],
     text: ['', [Validators.required, Validators.minLength(20)]],
     title: ['', [Validators.required, Validators.minLength(4)]]
    });
  }

  ngOnInit() {
  }

  get f() { return this.createLyricForm.controls;}

  create(formData: AbstractControl) {
    console.log(formData)
  }
}
