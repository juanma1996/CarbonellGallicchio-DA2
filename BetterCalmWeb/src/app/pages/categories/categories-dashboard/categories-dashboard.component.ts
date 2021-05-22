import { Component, OnInit } from '@angular/core';
import {CategoriesService} from '../../../services/categories/categories.service'
import { catchError } from 'rxjs/operators';

@Component({
  selector: 'app-categories-dashboard',
  templateUrl: 'categories-dashboard.component.html',
})
export class CategoriesDashboardComponent implements OnInit {
  public categories = [];
  public errorBackend: string = '';

  constructor(private categoriesService: CategoriesService) { }

  ngOnInit(): void {
    this.categoriesService.get()
      .subscribe(
        response => {
          this.get(response)
        },
        catchError => {
          console.log(catchError);
          this.errorBackend = catchError + ', fix it please';
        }
      )
  }


  private get(response){
    console.log(response);
    this.categories = response;
  }
}
