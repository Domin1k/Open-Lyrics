import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router'

import { NavigationComponent } from './navigation/navigation.component';
import { CustomMaterialModule } from '../custom-material.module';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    CustomMaterialModule
  ],
  exports: [
    NavigationComponent
  ],
  declarations: [NavigationComponent]
})
export class CoreModule { }
