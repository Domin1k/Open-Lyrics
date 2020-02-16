import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { LyricService } from '../services/lyric.service';
import { Observable } from 'rxjs';
import { LyricDetailsResponseModel } from 'src/app/shared/models/lyric/details-lyric-response.model';

@Injectable({
  providedIn: 'root'
})
export class DetailLyricResolver implements Resolve<LyricDetailsResponseModel> {
    constructor(private lyricSvc: LyricService) {}
    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) :Observable<LyricDetailsResponseModel> {
        const lyricId = Number.parseInt(route.params['id']);
        return this.lyricSvc.details(lyricId);
    }

}