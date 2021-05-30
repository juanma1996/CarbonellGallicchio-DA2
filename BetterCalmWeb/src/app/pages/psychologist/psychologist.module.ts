import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterPsychologistComponent } from './register-psychologist/register-psychologist.component';
import { RouterModule } from '@angular/router';
import { PsychologistRoutes } from './psychologist.routing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AngularMultiSelectModule } from 'angular2-multiselect-dropdown';



@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(PsychologistRoutes),
    AngularMultiSelectModule,
    ReactiveFormsModule.withConfig({ warnOnNgModelWithFormControl: "never" }),
  ],
  declarations: [
    RegisterPsychologistComponent
  ],
  exports: [

  ]
})
export class PsychologistModule { }
