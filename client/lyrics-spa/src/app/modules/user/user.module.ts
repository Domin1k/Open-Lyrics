import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { UserRoutingModule } from './user-routing.module';
import { CustomMaterialModule } from '../custom-material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { ProfileComponent } from './profile/profile.component';
import { LogoutComponent } from './logout/logout.component';



@NgModule({
  declarations: [LoginComponent, RegisterComponent, ProfileComponent, LogoutComponent],
  imports: [
    CommonModule,
    UserRoutingModule,
    CustomMaterialModule,
    ReactiveFormsModule
  ]
})
export class UserModule { }