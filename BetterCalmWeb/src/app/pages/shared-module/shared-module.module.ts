import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AudioContentTableComponent } from 'src/app/pages/audio-content/audio-content-table/audio-content-table.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { RouterModule } from '@angular/router';
import { VideoContentListComponent } from '../video-content/video-content-list/video-content-list.component';
import { SafePipe } from './safe.pipe';

@NgModule({
  declarations: [
    AudioContentTableComponent,
    VideoContentListComponent,
    SafePipe
  ],
  imports: [
    NgxDatatableModule,
    RouterModule,
    CommonModule
  ],
  exports: [AudioContentTableComponent, VideoContentListComponent]
})
export class SharedModuleModule { }
