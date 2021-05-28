import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { CreateAdministratorComponent } from './create-administrator/create-administrator.component';
import { RouterModule } from '@angular/router';
import { AdministratorRoutes } from './administrator.routing';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(AdministratorRoutes),
    ReactiveFormsModule
  ],
  declarations: [
    CreateAdministratorComponent
  ],
  exports: [
    CreateAdministratorComponent
  ]
})
export class AdministratorModule { }
