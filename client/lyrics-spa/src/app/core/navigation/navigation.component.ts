import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent implements OnInit {
  searchForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private userSvc: UserService,
    private router: Router) {

    this.searchForm = this.fb.group({
      searchBar: ['', [Validators.required, Validators.minLength(2), Validators.pattern('[a-zA-Z0-9]+')]]
    });
  }

  get f() { return this.searchForm.controls; }

  ngOnInit(): void {
  }

  get isLoggedIn() {
    return this.userSvc.isLoggedIn();
  }

  search(data: any) {
    this.router.navigate(['/'], { queryParams: { searchTerm: data.searchBar } }).then(() => this.searchForm.reset());
  }
}
