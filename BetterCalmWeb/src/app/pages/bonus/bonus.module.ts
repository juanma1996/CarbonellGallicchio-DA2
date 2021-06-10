import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BonusDashboardComponent } from './bonus-dashboard/bonus-dashboard.component';
import { BonusRoutes } from './bonus.routing';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AngularMultiSelectModule } from 'angular2-multiselect-dropdown';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';

@NgModule({
  declarations: [BonusDashboardComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule.withConfig({ warnOnNgModelWithFormControl: "never" }),
    AngularMultiSelectModule,
    NgxDatatableModule,
    RouterModule.forChild(BonusRoutes),
  ]
})
export class BonusModule { }
