import { Routes } from "@angular/router";

import {CreateAdministratorComponent} from "./create-administrator/create-administrator.component"
import { EditAdministratorDashboardComponent } from './edit-administrator-dashboard/edit-administrator-dashboard.component';

export const AdministratorRoutes: Routes = [
  {
    path: "create",
    component: CreateAdministratorComponent
  },
  {
    path: "maintenance",
    component: EditAdministratorDashboardComponent
  },
];
