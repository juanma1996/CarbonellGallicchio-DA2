import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { CategoriesDashboardComponent } from './categories-dashboard/categories-dashboard.component';
import { CategoryCardComponent } from './category-card/category-card.component';

import { CategoriesRoutes } from "./categories.routing";
import { SharedModuleModule } from '../shared-module/shared-module.module';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(CategoriesRoutes),
    SharedModuleModule
  ],
  declarations: [
    CategoryCardComponent,
    CategoriesDashboardComponent,
  ],
  exports: [
    CategoriesDashboardComponent,
    CategoryCardComponent
  ]
})
export class CategoriesModule { }
