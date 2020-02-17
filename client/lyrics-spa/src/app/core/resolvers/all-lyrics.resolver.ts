import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { LyricService } from '../services/lyric.service';
import { Observable } from 'rxjs';
import { AllLyricsRequestModel } from 'src/app/shared/models/lyric/all-lyrics-request.model';
import { AllLyricsResponseModel } from 'src/app/shared/models/lyric/all-lyrics-response.model';

@Injectable({
  providedIn: 'root'
})
export class AllLyricsResolver implements Resolve<AllLyricsResponseModel> {
  constructor(private lyricSvc: LyricService) { }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<AllLyricsResponseModel> {
    return this.lyricSvc.all(new AllLyricsRequestModel(route.queryParams.searchTerm, 0, 10, true));
  }
}