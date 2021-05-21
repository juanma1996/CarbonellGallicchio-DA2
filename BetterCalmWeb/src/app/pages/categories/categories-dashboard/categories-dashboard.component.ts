import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-categories-dashboard',
  templateUrl: 'categories-dashboard.component.html',
})
export class CategoriesDashboardComponent implements OnInit {
  categories = [
    {
      id: 1,
      name: 'Sleep',
    },
    {
      id: 2,
      name: 'Meditate',
    },
    {
      id: 3,
      name: 'Music',
    },
    {
      id: 4,
      name: 'Body',
    },
  ]
  constructor() { }

  ngOnInit(): void {
  }

}
