import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-categories-dashboard',
  templateUrl: './categories-dashboard.component.html',
  styleUrls: ['./categories-dashboard.component.scss']
})
export class CategoriesDashboardComponent implements OnInit {
  categories = [
    {
      Id: 1,
      name: 'Sleep',
    },
    {
      Id: 2,
      name: 'Meditate',
    },
    {
      Id: 3,
      name: 'Music',
    },
    {
      Id: 4,
      name: 'Body',
    },
  ]
  constructor() { }

  ngOnInit(): void {
  }

}
