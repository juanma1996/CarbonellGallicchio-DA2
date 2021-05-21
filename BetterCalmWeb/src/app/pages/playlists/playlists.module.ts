import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PlaylistsDashboardComponent } from './playlists-dashboard/playlists-dashboard.component';
import { PlaylistCardComponent } from './playlist-card/playlist-card.component';
import { PlaylistRoutes } from './playlists.routing';
import { RouterModule } from '@angular/router';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(PlaylistRoutes)
  ],
  declarations: [
    PlaylistsDashboardComponent, 
    PlaylistCardComponent
  ],
  exports :[
    PlaylistsDashboardComponent, 
    PlaylistCardComponent
  ]
})
export class PlaylistsModule { }
