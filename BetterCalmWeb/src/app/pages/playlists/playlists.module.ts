import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PlaylistsDashboardComponent } from './playlists-dashboard/playlists-dashboard.component';
import { PlaylistCardComponent } from './playlist-card/playlist-card.component';



@NgModule({
  declarations: [PlaylistsDashboardComponent, PlaylistCardComponent],
  imports: [
    CommonModule
  ]
})
export class PlaylistsModule { }
