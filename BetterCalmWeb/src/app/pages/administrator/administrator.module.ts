import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { CreateAdministratorComponent } from './create-administrator/create-administrator.component';
import { RouterModule } from '@angular/router';
import { AdministratorRoutes } from './administrator.routing';
import { EditAdministratorDashboardComponent } from './edit-administrator-dashboard/edit-administrator-dashboard.component';
import { AdministratorFormComponent } from './administrator-form/administrator-form.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    NgxDatatableModule,
    RouterModule.forChild(AdministratorRoutes),
    ReactiveFormsModule
  ],
  declarations: [
    CreateAdministratorComponent,
    EditAdministratorDashboardComponent,
    AdministratorFormComponent
  ],
  exports: [
    CreateAdministratorComponent
  ]
})
export class AdministratorModule { }
