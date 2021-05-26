import { Routes } from "@angular/router";

import {AudioContentDashboardComponent} from "./audio-content-dashboard/audio-content-dashboard.component";
import { CreateAudioContentComponent } from './create-audio-content/create-audio-content.component';
import { AdminGuard } from 'src/app/guards/admin.guard';

export const AudioContentRoutes: Routes = [
  {
    path: ":categoryId",
    component: AudioContentDashboardComponent
  },
  {
    path: "",
    component: CreateAudioContentComponent,  canActivate: [AdminGuard]
  }
];
