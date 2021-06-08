import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AudioContentDashboardComponent } from './audio-content-dashboard/audio-content-dashboard.component';
import { RouterModule } from '@angular/router';
import { AudioContentRoutes } from './audio-content.routing';
import { TimepickerModule } from "ngx-bootstrap/timepicker";
import { CreateAudioContentComponent } from './create-audio-content/create-audio-content.component';
import { AngularMultiSelectModule } from 'angular2-multiselect-dropdown';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EditAudioContentComponent } from './edit-audio-content/edit-audio-content.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { SharedModuleModule } from '../shared-module/shared-module.module';

@NgModule({
  declarations: [AudioContentDashboardComponent, CreateAudioContentComponent, EditAudioContentComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(AudioContentRoutes),
    ReactiveFormsModule.withConfig({ warnOnNgModelWithFormControl: "never" }),
    FormsModule,
    NgxDatatableModule,
    TimepickerModule.forRoot(),
    AngularMultiSelectModule,
    SharedModuleModule
  ],
  exports: [
  ]
})
export class AudioContentModule { }
