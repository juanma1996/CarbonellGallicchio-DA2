import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VideoContentCardComponent } from './video-content-card/video-content-card.component';
import { VideoContentListComponent } from './video-content-list/video-content-list.component';
import { VideoContentDashboardComponent } from './video-content-dashboard/video-content-dashboard.component';
import { RouterModule } from '@angular/router';
import { VideoContentRoutes } from './video-content.routing';
import { SharedModuleModule } from '../shared-module/shared-module.module';

@NgModule({
  declarations: [VideoContentCardComponent, VideoContentDashboardComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(VideoContentRoutes),
    SharedModuleModule
  ]
})
export class VideoContentModule { }
