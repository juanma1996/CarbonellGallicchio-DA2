import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterPsychologistComponent } from './register-psychologist/register-psychologist.component';
import { RouterModule } from '@angular/router';
import { PsychologistRoutes } from './psychologist.routing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AngularMultiSelectModule } from 'angular2-multiselect-dropdown';
import { PsychologistFormComponent } from './psychologist-form/psychologist-form.component';
import { EditPsychologistDashboardComponent } from './edit-psychologist-dashboard/edit-psychologist-dashboard.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';



@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    NgxDatatableModule,
    RouterModule.forChild(PsychologistRoutes),
    AngularMultiSelectModule,
    ReactiveFormsModule.withConfig({ warnOnNgModelWithFormControl: "never" }),
  ],
  declarations: [
    RegisterPsychologistComponent,
    PsychologistFormComponent,
    EditPsychologistDashboardComponent
  ],
  exports: [

  ]
})
export class PsychologistModule { }
