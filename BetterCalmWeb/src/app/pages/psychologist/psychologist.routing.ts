import { Routes } from "@angular/router";
import { RegisterPsychologistComponent } from "./register-psychologist/register-psychologist.component"
import { EditPsychologistDashboardComponent } from './edit-psychologist-dashboard/edit-psychologist-dashboard.component';

export const PsychologistRoutes: Routes = [
  {
    path: "create",
    component: RegisterPsychologistComponent
  },
  {
    path: "maintenance",
    component: EditPsychologistDashboardComponent
  }
];
