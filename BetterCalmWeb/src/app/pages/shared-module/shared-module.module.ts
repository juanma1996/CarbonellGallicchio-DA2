import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AudioContentTableComponent } from 'src/app/pages/audio-content/audio-content-table/audio-content-table.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    AudioContentTableComponent
  ],
  imports: [
    NgxDatatableModule,
    RouterModule,
    CommonModule
  ],
  exports: [AudioContentTableComponent]
})
export class SharedModuleModule { }
