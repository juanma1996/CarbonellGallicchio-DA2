import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { CategoriesDashboardComponent } from './categories-dashboard/categories-dashboard.component';
import { CategoryCardComponent } from './category-card/category-card.component';

import { CategoriesRoutes } from "./categories.routing";

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(CategoriesRoutes),
  ],
  declarations: [
    CategoryCardComponent,
    CategoriesDashboardComponent
  ],
  exports :[
    CategoriesDashboardComponent,
    CategoryCardComponent
  ]
})
export class CategoriesModule { }
