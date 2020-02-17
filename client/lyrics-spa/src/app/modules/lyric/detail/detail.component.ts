import { Component, OnInit, Input } from '@angular/core';
import { LyricDetailsResponseModel } from 'src/app/shared/models/lyric/details-lyric-response.model';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css']
})
export class DetailComponent implements OnInit {
  @Input() lyric: LyricDetailsResponseModel;

  constructor(private ar: ActivatedRoute) { }

  ngOnInit() {
    this.ar.data.subscribe(res => {
      if (res.detailLyric) {
        this.lyric = res.detailLyric;
      }
    })
  }
}
