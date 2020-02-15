import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl, FormControl } from '@angular/forms';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent implements OnInit {
  searchForm: FormGroup;

  constructor(private fb: FormBuilder, private userSvc: UserService) {
    this.searchForm = this.fb.group({
      searchBar: ['', Validators.required]
    });
   }

  ngOnInit(): void {
  }

  get isLoggedIn() {
    return this.userSvc.isLoggedIn();
  }

  search(data: any) {
    
  }
}
