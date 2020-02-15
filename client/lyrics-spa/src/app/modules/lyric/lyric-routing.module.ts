import { RouterModule, Routes } from '@angular/router';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';
import { DeleteComponent } from './delete/delete.component';
import { MyComponent } from './my/my.component';
import { AuthGuard } from 'src/app/core/guards/auth.guard';

const routes: Routes = [
    { path: 'lyrics/create', component:  CreateComponent, canActivate: [AuthGuard]},
    { path: 'lyrics/my', component:  MyComponent, canActivate: [AuthGuard]},
    { path: 'lyrics/edit/:id', component:  EditComponent, canActivate: [AuthGuard] },
    { path: 'lyrics/delete/:id', component:  DeleteComponent, canActivate: [AuthGuard] },
];

export const LyricRoutingModule = RouterModule.forChild(routes)