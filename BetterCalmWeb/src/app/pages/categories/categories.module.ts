import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CategoriesDashboardComponent } from './categories-dashboard/categories-dashboard.component';
import { CategoryCardComponent } from './category-card/category-card.component';

@NgModule({
  declarations: [
    CategoryCardComponent,
    CategoriesDashboardComponent
  ],
  imports: [
    CommonModule,
    CategoriesModule
  ]
})
export class CategoriesModule { }
