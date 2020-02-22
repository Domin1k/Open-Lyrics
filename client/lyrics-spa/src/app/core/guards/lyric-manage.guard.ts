import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { LyricService } from '../services/lyric.service';
import { map } from 'rxjs/operators';
import { CanManageLyricResponseModel } from 'src/app/shared/models/lyric/canManage-lyric-response.model';

@Injectable({
  providedIn: 'root'
})
export class LyricManageGuard implements CanActivate {
  constructor(private lyricSvc: LyricService, private router: Router) { }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> {

    return this.lyricSvc.canManage(next.params['id'])
    .pipe(
      map((res: CanManageLyricResponseModel) => {
        if (res.canManage === false) {
              this.router.navigate(['/lyrics/my']);
              return false;
            }
            return true;
      }));
  }

}
