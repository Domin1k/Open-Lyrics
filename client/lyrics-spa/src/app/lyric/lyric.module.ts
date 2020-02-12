import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DetailComponent } from './detail/detail.component';
import { CustomMaterialModule } from '../custom-material.module';
import { CreateComponent } from './create/create.component';
import { LyricRoutingModule } from './lyric-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { EditComponent } from './edit/edit.component';
import { DeleteComponent } from './delete/delete.component';
import { DeleteDialogComponent } from './delete/delete-dialog.component';



@NgModule({
  declarations: [DetailComponent, CreateComponent, EditComponent, DeleteComponent, DeleteDialogComponent],
  imports: [
    CommonModule,
    CustomMaterialModule,
    LyricRoutingModule,
    ReactiveFormsModule
  ],
  entryComponents: [DeleteDialogComponent]
})
export class LyricModule { }
