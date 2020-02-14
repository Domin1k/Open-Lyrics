import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { DeleteDialogComponent } from './delete-dialog.component';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.css', '../../../shared/forms.css']
})
export class DeleteComponent implements OnInit {
  deleteLyricForm: FormGroup;

  constructor(
    private form: FormBuilder,
    private route: ActivatedRoute,
    public dialog: MatDialog) {
    this.deleteLyricForm = this.form.group({
      singer: ['Info retrieved from server', Validators.required],
      text: ['Info retrieved from server', Validators.required],
      title: ['Info retrieved from server', Validators.required]
    });
  }

  ngOnInit() {
  }

  remove() {
    this.dialog.open(DeleteDialogComponent).afterClosed().subscribe(result => {
      if (!result) {
        // user declines deletion
        return;
      }
      console.log(this.route.snapshot.params.id);
    });

  }

}
