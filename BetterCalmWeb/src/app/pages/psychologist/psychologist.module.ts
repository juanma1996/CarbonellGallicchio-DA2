import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterPsychologistComponent } from './register-psychologist/register-psychologist.component';
import { RouterModule } from '@angular/router';
import { PsychologistRoutes } from './psychologist.routing';
import { FormsModule } from '@angular/forms';
import { AngularMultiSelectModule } from 'angular2-multiselect-dropdown';



@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(PsychologistRoutes),
    AngularMultiSelectModule,
  ],
  declarations: [
    RegisterPsychologistComponent
  ],
  exports: [

  ]
})
export class PsychologistModule { }
