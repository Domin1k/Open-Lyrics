import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css', '../../../shared/forms.css']
})
export class EditComponent implements OnInit {
  editLyricForm: FormGroup;
  error: string;

  constructor(private form: FormBuilder) {
    this.editLyricForm = this.form.group({
      singer: ['Lyric title is here', [Validators.required, Validators.minLength(2)]],
      title: ['Lyric text is here', [Validators.required, Validators.minLength(4)]],
      text: ['Very long text.Very long text.Very long text.Very long text.Very long text.Very long text.Very long text', [Validators.required, Validators.minLength(20)]]
    });
  }

  ngOnInit() {
  }

  get f() { return this.editLyricForm.controls; }

  edit(formData: AbstractControl) {
    console.log(formData)
  }
}
