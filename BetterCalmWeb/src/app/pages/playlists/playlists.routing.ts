import { Routes } from "@angular/router";

import { AudioContentPlaylistsDashboardComponent } from "./audio-content-playlists-dashboard/audio-content-playlists-dashboard.component";
import { VideoContentPlaylistDashboardComponent } from './video-content-playlist-dashboard/video-content-playlist-dashboard.component';

export const PlaylistRoutes: Routes = [
  {
    path: ":categoryId",
    component: AudioContentPlaylistsDashboardComponent
  },
  {
    path: "videoContents/:categoryId",
    component: VideoContentPlaylistDashboardComponent
  }
];
