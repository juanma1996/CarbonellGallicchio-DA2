import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VideoContentListComponent } from './video-content-list/video-content-list.component';
import { VideoContentDashboardComponent } from './video-content-dashboard/video-content-dashboard.component';
import { RouterModule } from '@angular/router';
import { VideoContentRoutes } from './video-content.routing';
import { SharedModuleModule } from '../shared-module/shared-module.module';
import { CreateVideoContentComponent } from './create-video-content/create-video-content.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EditVideoContentComponent } from './edit-video-content/edit-video-content.component';

@NgModule({
  declarations: [VideoContentDashboardComponent, CreateVideoContentComponent, EditVideoContentComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule.withConfig({ warnOnNgModelWithFormControl: "never" }),
    FormsModule,
    RouterModule.forChild(VideoContentRoutes),
    SharedModuleModule
  ]
})
export class VideoContentModule { }
