import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PlaylistsDashboardComponent } from './playlists-dashboard/playlists-dashboard.component';
import { PlaylistCardComponent } from './playlist-card/playlist-card.component';
import { PlaylistRoutes } from './playlists.routing';
import { RouterModule } from '@angular/router';
import { SharedModuleModule } from '../shared-module/shared-module.module';
import { CollapseModule } from "ngx-bootstrap/collapse";

@NgModule({
  imports: [
    CommonModule,
    CollapseModule.forRoot(),
    RouterModule.forChild(PlaylistRoutes),
    SharedModuleModule,
  ],
  declarations: [
    PlaylistsDashboardComponent,
    PlaylistCardComponent
  ],
  exports: [
    PlaylistsDashboardComponent,
    PlaylistCardComponent
  ]
})
export class PlaylistsModule { }
