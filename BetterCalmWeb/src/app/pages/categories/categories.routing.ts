import { Routes } from "@angular/router";

import { AudioContentCategoriesDashboardComponent } from './audio-content-categories-dashboard/audio-content-categories-dashboard.component';
import { VideoContentCategoriesDashboardComponent } from './video-content-categories-dashboard/video-content-categories-dashboard.component';

export const CategoriesRoutes: Routes = [
  {
    path: "",
    component: AudioContentCategoriesDashboardComponent
  },
  {
    path: "audioContents",
    component: AudioContentCategoriesDashboardComponent
  },
  {
    path: "videoContents",
    component: VideoContentCategoriesDashboardComponent
  },

];
