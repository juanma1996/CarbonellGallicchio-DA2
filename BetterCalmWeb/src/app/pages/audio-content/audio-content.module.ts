import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AudioContentDashboardComponent } from './audio-content-dashboard/audio-content-dashboard.component';
import { RouterModule } from '@angular/router';
import { AudioContentRoutes } from './audio-content.routing';

@NgModule({
  declarations: [AudioContentDashboardComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(AudioContentRoutes),
  ]
})
export class AudioContentModule { }
