import { Component, OnInit, Input, HostBinding } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { ActivatedRoute } from '@angular/router';
import { LyricResponseModel } from 'src/app/shared/models/lyric/lyric-response.model';
import { LyricService } from 'src/app/core/services/lyric.service';
import { AllLyricsRequestModel } from 'src/app/shared/models/lyric/all-lyrics-request.model';
import { AllLyricsResponseModel } from 'src/app/shared/models/lyric/all-lyrics-response.model';
import { trigger, transition, animate, style, query, stagger } from '@angular/animations';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  animations: [
    trigger('pageAnimations', [
      transition(':enter', [
        query('.all-lyrics', [
          style({opacity: 0, transform: 'translateY(-100px)'}),
          stagger(-30, [
            animate('500ms cubic-bezier(0.35, 0, 0.25, 1)', style({ opacity: 1, transform: 'none' }))
          ])
        ])
      ])
    ])
  ]
})
export class HomeComponent implements OnInit {
  @HostBinding('@pageAnimations')
  public animatePage = true;
  
  length: number;
  pageSize = 10;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  lyricsData: LyricResponseModel[];
  @Input() test: AllLyricsResponseModel;
  
  constructor(private ar: ActivatedRoute, private lyricSvc: LyricService) { }

  ngOnInit() {
    this.ar.data.subscribe(res => {
      this.lyricsData = res.allLyrics.lyrics;
      this.length = res.allLyrics.total;
    })
  }

  getAll(pageEvent?: PageEvent) {
    this.lyricSvc.all(new AllLyricsRequestModel('', pageEvent.pageIndex, pageEvent.pageSize, false))
      .subscribe((res: AllLyricsResponseModel) => {
        this.lyricsData = res.lyrics;
      })
  }
}
