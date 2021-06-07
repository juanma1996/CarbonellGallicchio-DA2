import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AudioContentTableComponent } from 'src/app/pages/audio-content/audio-content-table/audio-content-table.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { RouterModule } from '@angular/router';
import { VideoContentListComponent } from '../video-content/video-content-list/video-content-list.component';
import { SafePipe } from './safe.pipe';
import { AudioFormComponent } from '../audio-content/audio-form/audio-form.component';
import { TimepickerModule } from 'ngx-bootstrap/timepicker/public_api';
import { AngularMultiSelectModule } from 'angular2-multiselect-dropdown';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AudioContentTableComponent,
    VideoContentListComponent,
    AudioFormComponent,
    SafePipe
  ],
  imports: [
    NgxDatatableModule,
    RouterModule,
    CommonModule,
    AngularMultiSelectModule,
    ReactiveFormsModule.withConfig({ warnOnNgModelWithFormControl: "never" }),
    FormsModule,
  ],
  exports: [AudioContentTableComponent, VideoContentListComponent, AudioFormComponent]
})
export class SharedModuleModule { }
