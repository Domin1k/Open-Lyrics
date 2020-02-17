import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { LogoutComponent } from './logout/logout.component';
import { AuthGuard } from 'src/app/core/guards/auth.guard';

const routes: Routes = [
    { path: 'user/login', component: LoginComponent  },
    { path: 'user/register', component: RegisterComponent },
    { path: 'user/logout', component: LogoutComponent, canActivate: [AuthGuard] },
];

export const UserRoutingModule = RouterModule.forChild(routes)