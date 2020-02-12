import { RouterModule, Routes } from '@angular/router';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';
import { DeleteComponent } from './delete/delete.component';

const routes: Routes = [
    { path: 'lyrics/create', component:  CreateComponent},
    { path: 'lyrics/edit/:id', component:  EditComponent },
    { path: 'lyrics/delete/:id', component:  DeleteComponent },
];

export const LyricRoutingModule = RouterModule.forChild(routes)