import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { LyricService } from 'src/app/core/services/lyric.service';
import { EditLyricRequestModel } from 'src/app/shared/models/lyric/edit-lyric-request.model';
import { Router, ActivatedRoute } from '@angular/router';
import { MatSnackBar } from '@angular/material';
import { lyricValidation } from 'src/app/shared/models/lyric/lyric-validation.constants';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  editLyricForm: FormGroup;
  error: string;

  constructor(
    private form: FormBuilder,
    private route: ActivatedRoute,
    private lyricSvc: LyricService,
    private router: Router,
    private snackBar: MatSnackBar) {
  }

  ngOnInit() {
    this.lyricSvc.details(this.route.snapshot.params.id)
      .subscribe(res => {
        console.log(res);
        this.editLyricForm = this.form.group({
          singer: [res.singer, [Validators.required, Validators.minLength(lyricValidation.singerLength)]],
          title: [res.title, [Validators.required, Validators.minLength(lyricValidation.titleLength)]],
          text: [res.text, [Validators.required, Validators.minLength(lyricValidation.textLength)]]
        });
      })
  }

  get f() { return this.editLyricForm.controls; }

  edit(formData: any) {
    this.lyricSvc.edit(this.route.snapshot.params.id, new EditLyricRequestModel(formData.text, formData.title, formData.singer))
      .subscribe(res => {
        this.snackBar.open('Successfully edited lyric', '', {duration: 1500, verticalPosition: 'top'});
        this.router.navigate(['/lyrics/my'])
      })
  }
}
