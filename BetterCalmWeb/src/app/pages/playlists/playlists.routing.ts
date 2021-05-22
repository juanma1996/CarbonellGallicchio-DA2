import { Routes } from "@angular/router";

import {PlaylistsDashboardComponent} from "./playlists-dashboard/playlists-dashboard.component";

export const PlaylistRoutes: Routes = [
  {
    path: ":categoryId",
    component: PlaylistsDashboardComponent
  }
];
