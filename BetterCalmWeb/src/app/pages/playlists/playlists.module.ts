import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PlaylistsDashboardComponent } from './playlists-dashboard/playlists-dashboard.component';
import { PlaylistCardComponent } from './playlist-card/playlist-card.component';
import { PlaylistRoutes } from './playlists.routing';
import { RouterModule } from '@angular/router';
import { SharedModuleModule } from '../shared-module/shared-module.module';
import { CollapseModule } from "ngx-bootstrap/collapse";
import { VideoContentPlaylistDashboardComponent } from './video-content-playlist-dashboard/video-content-playlist-dashboard.component';

@NgModule({
  imports: [
    CommonModule,
    CollapseModule.forRoot(),
    RouterModule.forChild(PlaylistRoutes),
    SharedModuleModule,
  ],
  declarations: [
    PlaylistsDashboardComponent,
    PlaylistCardComponent,
    VideoContentPlaylistDashboardComponent
  ],
  exports: [
    PlaylistsDashboardComponent,
    PlaylistCardComponent
  ]
})
export class PlaylistsModule { }
