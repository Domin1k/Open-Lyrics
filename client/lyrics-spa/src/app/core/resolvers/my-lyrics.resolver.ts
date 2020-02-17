import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { LyricService } from '../services/lyric.service';
import { Observable } from 'rxjs';
import { MyLyricsResponseModel } from 'src/app/shared/models/lyric/my-lyrics-response.model';
import { MyLyricsRequestModel } from 'src/app/shared/models/lyric/my-lyrics-request.model';

@Injectable({
  providedIn: 'root'
})
export class MyLyricsResolver implements Resolve<MyLyricsResponseModel> {
  constructor(private lyricSvc: LyricService) { }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<MyLyricsResponseModel> {
    return this.lyricSvc.my(new MyLyricsRequestModel(0, 10, true));
  }
}