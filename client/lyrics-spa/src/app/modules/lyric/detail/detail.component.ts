import { Component, OnInit } from '@angular/core';
import { LyricDetailsResponseModel } from 'src/app/shared/models/lyric/details-lyric-response.model';
import { ActivatedRoute } from '@angular/router';
import { LyricService } from 'src/app/core/services/lyric.service';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css']
})
export class DetailComponent implements OnInit {
  lyric: LyricDetailsResponseModel;
  
  constructor(private ar: ActivatedRoute, private lyricSvc: LyricService) { }

  ngOnInit() {
    this.ar.data.subscribe(res => {
      this.lyric = res.detailLyric;
    })
  }

}
