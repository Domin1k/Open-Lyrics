import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material';

@Component({
  selector: 'app-my',
  templateUrl: './my.component.html',
  styleUrls: ['./my.component.css']
})
export class MyComponent implements OnInit {
  length = 100;
  pageSize = 10;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  data: any[];
  currentDetails: any;

  // MatPaginator Output
  pageEvent: PageEvent;

  
  constructor() {
    this.data = [
      { id: 1, name: 'Eminem Loose yourself'},
      { id: 2, name: 'Ariana grander 7 rings'},
      { id: 3, name: 'AC/DC - highway to hell'},
      { id: 4, name: 'The pretty reckless - Hit me like a man'},
    ]
   }

   ngOnInit(){}

   details(id: number) {
     this.currentDetails = {
       id: 1,
       singer: 'Eminem',
       title: 'Rap God',
       text: 'Very long text,Very long text,Very long text,Very long text,Very long text,Very long text,Very long text,Very long text,Very long text',
       author: 'Admin'
     }
   }
}
