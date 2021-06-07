import { Routes } from "@angular/router";

import { PlaylistsDashboardComponent } from "./playlists-dashboard/playlists-dashboard.component";
import { VideoContentPlaylistDashboardComponent } from './video-content-playlist-dashboard/video-content-playlist-dashboard.component';

export const PlaylistRoutes: Routes = [
  {
    path: ":categoryId",
    component: PlaylistsDashboardComponent
  },
  {
    path: "videoContents/:categoryId",
    component: VideoContentPlaylistDashboardComponent
  }
];
