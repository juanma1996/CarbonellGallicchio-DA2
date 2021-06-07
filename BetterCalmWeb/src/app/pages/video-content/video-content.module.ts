import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VideoContentCardComponent } from './video-content-card/video-content-card.component';
import { VideoContentListComponent } from './video-content-list/video-content-list.component';

@NgModule({
  declarations: [VideoContentCardComponent, VideoContentListComponent],
  imports: [
    CommonModule
  ]
})
export class VideoContentModule { }
