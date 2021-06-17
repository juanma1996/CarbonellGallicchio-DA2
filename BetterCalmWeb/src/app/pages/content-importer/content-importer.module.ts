import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContentImporterDashboardComponent } from './content-importer-dashboard/content-importer-dashboard.component';
import { ContentImporterRoutes } from './content-importer.routing';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TagInputModule } from 'ngx-chips';
import { AngularMultiSelectModule } from 'angular2-multiselect-dropdown';
import { ModalModule } from "ngx-bootstrap/modal";

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(ContentImporterRoutes),
    FormsModule,
    ModalModule.forRoot(),
    ReactiveFormsModule.withConfig({ warnOnNgModelWithFormControl: "never" }),
    TagInputModule,
    AngularMultiSelectModule,
  ],
  declarations: [ContentImporterDashboardComponent],
  exports: [ContentImporterDashboardComponent]
})
export class ContentImporterModule { }
