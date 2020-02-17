import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl, FormControl } from '@angular/forms';
import { UserService } from '../services/user.service';
import { LyricService } from '../services/lyric.service';
import { AllLyricsRequestModel } from 'src/app/shared/models/lyric/all-lyrics-request.model';
import { AllLyricsResponseModel } from 'src/app/shared/models/lyric/all-lyrics-response.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent implements OnInit {
  searchForm: FormGroup;
  searchLyricData: AllLyricsResponseModel;
  
  constructor(
    private fb: FormBuilder,
    private userSvc: UserService,
    private lyricSvc: LyricService,
    private router: Router) {

    this.searchForm = this.fb.group({
      searchBar: ['', (Validators.required, Validators.minLength(2))]
    });
  }

  ngOnInit(): void {
  }

  get isLoggedIn() {
    return this.userSvc.isLoggedIn();
  }

  search(data: any) {
    this.router.navigate(['/'], { queryParams: { searchTerm: data.searchBar}});
  }
}
