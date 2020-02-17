import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { DeleteDialogComponent } from './delete-dialog.component';
import { LyricService } from 'src/app/core/services/lyric.service';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.css']
})
export class DeleteComponent implements OnInit {
  deleteLyricForm: FormGroup;

  constructor(
    private form: FormBuilder,
    private route: ActivatedRoute,
    public dialog: MatDialog,
    private router: Router,
    private lyricSvc: LyricService,
    private snackBar: MatSnackBar) {

  }

  ngOnInit() {
    this.lyricSvc.details(this.route.snapshot.params.id)
      .subscribe(res => {
        console.log(res);
        this.deleteLyricForm = this.form.group({
          singer: [res.singer, [Validators.required, Validators.minLength(2)]],
          title: [res.title, [Validators.required, Validators.minLength(4)]],
          text: [res.text, [Validators.required, Validators.minLength(20)]]
        });
      })
  }

  remove() {
    this.dialog.open(DeleteDialogComponent).afterClosed().subscribe(result => {
      if (!result) {
        // user declines deletion
        return;
      }
      this.lyricSvc.delete(this.route.snapshot.params.id)
        .subscribe(() => {
          this.snackBar.open('Successfully deleted lyric', '', {duration: 1500, verticalPosition: 'top'});
          this.router.navigate(['lyrics/my']);
        })

    });

  }

}
