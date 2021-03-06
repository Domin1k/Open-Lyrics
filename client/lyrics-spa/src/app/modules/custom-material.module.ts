import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  MatPaginatorModule,
  MatToolbarModule,
  MatSidenavModule,
  MatListModule,
  MatButtonModule,
  MatIconModule,
  MatCardModule,
  MatInputModule,
  MatDialogModule,
  MatProgressSpinnerModule,
  MatSnackBarModule,
  MatProgressBarModule
} from '@angular/material';

const modules: any = [
  CommonModule,
  MatToolbarModule,
  MatSidenavModule,
  MatListModule,
  MatButtonModule,
  MatIconModule,
  MatCardModule,
  MatInputModule,
  MatPaginatorModule,
  MatDialogModule,
  MatProgressSpinnerModule,
  MatSnackBarModule,
  MatProgressBarModule
];

@NgModule({
  imports: modules,
  exports: modules
})
export class CustomMaterialModule { }
