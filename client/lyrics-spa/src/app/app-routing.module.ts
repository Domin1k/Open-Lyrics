import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './modules/home/home.component';
import { AllLyricsResolver } from './core/resolvers/all-lyrics.resolver';

const routes: Routes = [
    {
        path: "",
        pathMatch: 'full',
        component: HomeComponent,
        resolve: {
            allLyrics: AllLyricsResolver
        }
    }
]

export const AppRoutingModule = RouterModule.forRoot(routes);