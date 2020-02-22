import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { LyricService } from 'src/app/core/services/lyric.service';
import { CreateLyricRequestModel } from '../../../shared/models/lyric/create-lyric-request.model'
import { Router } from '@angular/router';
import { lyricValidation } from 'src/app/shared/models/lyric/lyric-validation.constants';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {
  createLyricForm: FormGroup;

  constructor(
    private form: FormBuilder,
     private lyricSvc: LyricService,
      private router: Router,
      private snackBar: MatSnackBar) {
    this.createLyricForm = this.form.group({
      singer: ['', [Validators.required, Validators.minLength(lyricValidation.singerLength)]],
      text: ['', [Validators.required, Validators.minLength(lyricValidation.textLength)]],
      title: ['', [Validators.required, Validators.minLength(lyricValidation.titleLength)]]
    });
  }

  get f() { return this.createLyricForm.controls; }

  ngOnInit() {
  }

  create(formData: any) {
    this.lyricSvc.create(new CreateLyricRequestModel(formData.text, formData.title, formData.singer))
      .subscribe(res => {
        this.snackBar.open('Lyric created successfully', '', { duration: 1500, verticalPosition: 'top' })
        this.router.navigate(['/lyrics/detail/', res])
      })
  }
}
