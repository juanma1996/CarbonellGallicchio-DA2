import { Routes } from "@angular/router";

import { CategoriesDashboardComponent } from './categories-dashboard/categories-dashboard.component';
import { VideoContentCategoriesDashboardComponent } from './video-content-categories-dashboard/video-content-categories-dashboard.component';

export const CategoriesRoutes: Routes = [
  {
    path: "audioContents",
    component: CategoriesDashboardComponent
  },
  {
    path: "videoContents",
    component: VideoContentCategoriesDashboardComponent
  },

];
