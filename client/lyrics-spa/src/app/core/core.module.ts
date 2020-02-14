import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router'

import { NavigationComponent } from './navigation/navigation.component';
import { CustomMaterialModule } from '../custom-material.module';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    CustomMaterialModule,
    ReactiveFormsModule
  ],
  exports: [
    NavigationComponent
  ],
  declarations: [NavigationComponent]
})
export class CoreModule { }
