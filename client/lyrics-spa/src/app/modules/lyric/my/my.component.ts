import { Component, OnInit, HostBinding } from '@angular/core';
import { PageEvent } from '@angular/material';
import { LyricResponseModel } from 'src/app/shared/models/lyric/lyric-response.model';
import { ActivatedRoute } from '@angular/router';
import { LyricService } from 'src/app/core/services/lyric.service';
import { MyLyricsRequestModel } from 'src/app/shared/models/lyric/my-lyrics-request.model';
import { MyLyricsResponseModel } from 'src/app/shared/models/lyric/my-lyrics-response.model';
import { LyricDetailsResponseModel } from 'src/app/shared/models/lyric/details-lyric-response.model';
import { trigger, transition, animate, style, query, stagger } from '@angular/animations';

@Component({
  selector: 'app-my',
  templateUrl: './my.component.html',
  styleUrls: ['./my.component.css'],
  animations: [
    trigger('pageAnimations', [
      transition(':enter', [
        query('.my-lyrics', [
          style({opacity: 0, transform: 'translateY(-100px)'}),
          stagger(-30, [
            animate('500ms cubic-bezier(0.35, 0, 0.25, 1)', style({ opacity: 1, transform: 'none' }))
          ])
        ], { optional: true })
      ])
    ])
  ]
})
export class MyComponent implements OnInit {
  @HostBinding('@pageAnimations')
  public animatePage = true;
  
  length: number;
  pageSize = 10;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  lyricsData: LyricResponseModel[];
  currentLyricDetails: LyricDetailsResponseModel;

  constructor(private ar: ActivatedRoute, private lyricSvc: LyricService) { }

  ngOnInit() {
    this.ar.data.subscribe(res => {
      this.lyricsData = res.myLyrics.lyrics;
      this.length = res.myLyrics.total;
    })
  }

  getMy(pageEvent?: PageEvent) {
    this.lyricSvc.my(new MyLyricsRequestModel(pageEvent.pageIndex, pageEvent.pageSize, false))
      .subscribe((res: MyLyricsResponseModel) => {
        this.lyricsData = res.lyrics;
      })
  }

  details(lyric: LyricResponseModel) {
    this.currentLyricDetails = {
      id: lyric.id,
      text: lyric.text,
      authorName: lyric.authorName,
      singer: lyric.singer,
      title: lyric.title,
      authorId: lyric.authorId
    };
  }
}
