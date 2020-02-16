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
import { MyComponent } from './my/my.component';
import { DetailLyricResolver } from 'src/app/core/resolvers/detail-lyric.resolver';



@NgModule({
  declarations: [DetailComponent, CreateComponent, EditComponent, DeleteComponent, DeleteDialogComponent, MyComponent],
  imports: [
    CommonModule,
    CustomMaterialModule,
    LyricRoutingModule,
    ReactiveFormsModule
  ],
  providers: [DetailLyricResolver],
  entryComponents: [DeleteDialogComponent]
})
export class LyricModule { }
