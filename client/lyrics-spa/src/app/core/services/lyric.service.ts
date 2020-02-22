import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CreateLyricRequestModel } from 'src/app/shared/models/lyric/create-lyric-request.model';
import { HttpClient } from '@angular/common/http';
import { EditLyricRequestModel } from 'src/app/shared/models/lyric/edit-lyric-request.model';
import { LyricDetailsResponseModel } from 'src/app/shared/models/lyric/details-lyric-response.model';
import { AllLyricsRequestModel } from 'src/app/shared/models/lyric/all-lyrics-request.model';
import { AllLyricsResponseModel } from 'src/app/shared/models/lyric/all-lyrics-response.model';
import { MyLyricsRequestModel } from 'src/app/shared/models/lyric/my-lyrics-request.model';
import { MyLyricsResponseModel } from 'src/app/shared/models/lyric/my-lyrics-response.model';
import { CanManageLyricResponseModel } from 'src/app/shared/models/lyric/canManage-lyric-response.model';

@Injectable({
  providedIn: 'root'
})
export class LyricService {
  private lyricBaseUrl: string;

  constructor(private http: HttpClient) {
    this.lyricBaseUrl = `${environment.apiUrl}/api/lyrics`;
  }

  create(request: CreateLyricRequestModel) {
    return this.http.post(`${this.lyricBaseUrl}/create`, request);
  }

  edit(id: number, request: EditLyricRequestModel) {
    return this.http.put(`${this.lyricBaseUrl}/edit/${id}`, request);
  }

  delete(id: number) {
    return this.http.delete(`${this.lyricBaseUrl}/delete/${id}`);
  }

  details(id: number) {
    return this.http.get<LyricDetailsResponseModel>(`${this.lyricBaseUrl}/details/${id}`);
  }

  canManage(id: number) {
    return this.http.get<CanManageLyricResponseModel>(`${this.lyricBaseUrl}/canManage/${id}`);
  }

  all(request: AllLyricsRequestModel) {
    const url = `${this.lyricBaseUrl}/all?searchTerm=${request.searchTerm}&page=${request.page}&pageSize=${request.pageSize}&includeCount=${request.includeCount}`;
    return this.http.get<AllLyricsResponseModel>(url);
  }

  my(request: MyLyricsRequestModel) {
    const url = `${this.lyricBaseUrl}/my?page=${request.page}&pageSize=${request.pageSize}&includeCount=${request.includeCount}`;
    return this.http.get<MyLyricsResponseModel>(url);
  }
}
