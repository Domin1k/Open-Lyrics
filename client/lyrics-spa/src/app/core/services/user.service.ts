import { Injectable } from '@angular/core';
import { UserLoginResponseModel } from 'src/app/shared/models/user/user-login-response.model';
import { HttpClient } from '@angular/common/http';
import * as moment from "moment";
import { tap, shareReplay } from 'rxjs/operators';
import { environment} from '../../../environments/environment';
import { UserRegisterRequestModel } from 'src/app/shared/models/user/user-register-request.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private usersUrl: string;

  constructor(private http: HttpClient) {
    this.usersUrl = `${environment.apiUrl}/api/users`;
   }

  login(username: string, password: string): Observable<UserLoginResponseModel> {
    return this.http.post<UserLoginResponseModel>(`${this.usersUrl}/login`, { username, password })
      .pipe(tap(res => this.setSession(res)));
  }

  register(input: UserRegisterRequestModel): Observable<UserLoginResponseModel> {
    return this.http.post<UserLoginResponseModel>(`${this.usersUrl}/register`, input);
  }

  logout() {
    return this.http.post(`${this.usersUrl}/logout`, [])
       .pipe(tap(() => this.unsetSession()));
  }

  isLoggedIn(): boolean {
    return localStorage.getItem('id_token') !== null;
  }

  private setSession(authResult: UserLoginResponseModel) {
    localStorage.setItem('id_token', authResult.token);
  }

  private unsetSession() {
    localStorage.removeItem('id_token');
  }
}
