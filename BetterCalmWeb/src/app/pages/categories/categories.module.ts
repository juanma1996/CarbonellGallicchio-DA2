import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AudioContentCategoriesDashboardComponent } from './audio-content-categories-dashboard/audio-content-categories-dashboard.component';
import { CategoryCardComponent } from './category-card/category-card.component';

import { CategoriesRoutes } from "./categories.routing";
import { SharedModuleModule } from '../shared-module/shared-module.module';
import { VideoContentCategoriesDashboardComponent } from './video-content-categories-dashboard/video-content-categories-dashboard.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(CategoriesRoutes),
    SharedModuleModule
  ],
  declarations: [
    CategoryCardComponent,
    AudioContentCategoriesDashboardComponent,
    VideoContentCategoriesDashboardComponent,
  ],
  exports: [
    AudioContentCategoriesDashboardComponent,
    CategoryCardComponent
  ]
})
export class CategoriesModule { }
