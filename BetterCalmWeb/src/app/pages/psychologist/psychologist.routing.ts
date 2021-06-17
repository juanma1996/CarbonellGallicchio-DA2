import { Routes } from "@angular/router";
import { RegisterPsychologistComponent } from "./register-psychologist/register-psychologist.component"
import { EditPsychologistDashboardComponent } from './edit-psychologist-dashboard/edit-psychologist-dashboard.component';
import { EditPsychologistComponent } from './edit-psychologist/edit-psychologist.component';

export const PsychologistRoutes: Routes = [
  {
    path: "create",
    component: RegisterPsychologistComponent
  },
  {
    path: "maintenance",
    component: EditPsychologistDashboardComponent
  },
  {
    path: "edit/:psychologistId",
    component: EditPsychologistComponent
  }
];
