import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { LyricService } from 'src/app/core/services/lyric.service';
import {CreateLyricRequestModel} from '../../../shared/models/lyric/create-lyric-request.model'
import { Router } from '@angular/router';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css', '../../../shared/forms.css']
})
export class CreateComponent implements OnInit {
  createLyricForm: FormGroup;
  
  constructor(private form: FormBuilder, private lyricSvc: LyricService, private router: Router) {
    this.createLyricForm = this.form.group({
     singer: ['', [Validators.required, Validators.minLength(2)]],
     text: ['', [Validators.required, Validators.minLength(20)]],
     title: ['', [Validators.required, Validators.minLength(4)]]
    });
  }

  get f() { return this.createLyricForm.controls;}

  ngOnInit() {
  }

  create(formData: any) {
    console.log(formData)
    this.lyricSvc.create(new CreateLyricRequestModel(formData.text, formData.title, formData.singer))
      .subscribe(res => {
       this.router.navigate(['/lyrics/detail/', res]) 
      })
  }
}
