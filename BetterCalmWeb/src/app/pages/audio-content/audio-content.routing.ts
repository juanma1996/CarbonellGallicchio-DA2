import { Routes } from "@angular/router";

import { AudioContentDashboardComponent } from "./audio-content-dashboard/audio-content-dashboard.component";
import { CreateAudioContentComponent } from './create-audio-content/create-audio-content.component';
import { AdminGuard } from 'src/app/guards/admin.guard';
import { EditAudioContentComponent } from './edit-audio-content/edit-audio-content.component';

export const AudioContentRoutes: Routes = [
  {
    path: "edit/:audioContentId",
    component: EditAudioContentComponent, canActivate: [AdminGuard]
  },
  {
    path: ":categoryId/:playlistId",
    component: AudioContentDashboardComponent
  },
  {
    path: "",
    component: CreateAudioContentComponent, canActivate: [AdminGuard]
  },
];
