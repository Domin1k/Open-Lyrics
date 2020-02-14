import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ProfileComponent } from './profile/profile.component';
import { LogoutComponent } from './logout/logout.component';

const routes: Routes = [
    { path: 'user/login', component: LoginComponent  },
    { path: 'user/register', component: RegisterComponent },
    { path: 'user/logout', component: LogoutComponent },
    { path: 'user/profile', component: ProfileComponent },
];

export const UserRoutingModule = RouterModule.forChild(routes)