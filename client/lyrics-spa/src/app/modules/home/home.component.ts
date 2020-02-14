import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  length = 100;
  pageSize = 10;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  data: any[];

  // MatPaginator Output
  pageEvent: PageEvent;

  
  constructor() {
    this.data = [
      { name: 'Eminem Loose yourself', info: 'Uploaded by admin'},
      { name: 'Ariana grander 7 rings', info: 'Uploaded by admin'},
      { name: 'AC/DC - highway to hell', info: 'Uploaded by admin'},
      { name: 'The pretty reckless - Hit me like a man', info: 'Uploaded by admin'},
    ]
   }

  ngOnInit() {
  }
}
