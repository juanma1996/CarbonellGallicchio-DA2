import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AudioContentDashboardComponent } from './audio-content-dashboard/audio-content-dashboard.component';
import { RouterModule } from '@angular/router';
import { AudioContentRoutes } from './audio-content.routing';
import { TimepickerModule } from "ngx-bootstrap/timepicker";
import { CreateAudioContentComponent } from './create-audio-content/create-audio-content.component';
import { AngularMultiSelectModule } from 'angular2-multiselect-dropdown';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AudioFormComponent } from './audio-form/audio-form.component';
import { EditAudioContentComponent } from './edit-audio-content/edit-audio-content.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';

@NgModule({
  declarations: [AudioContentDashboardComponent, CreateAudioContentComponent, AudioFormComponent, EditAudioContentComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(AudioContentRoutes),
    ReactiveFormsModule.withConfig({ warnOnNgModelWithFormControl: "never" }),
    FormsModule,
    NgxDatatableModule,
    TimepickerModule.forRoot(),
    AngularMultiSelectModule,
  ],
})
export class AudioContentModule { }
