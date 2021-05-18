import { Routes } from "@angular/router";

import { DashboardComponent } from "../../pages/dashboard/dashboard.component";
import { IconsComponent } from "../../pages/icons/icons.component";
import { MapComponent } from "../../pages/map/map.component";
import { NotificationsComponent } from "../../pages/notifications/notifications.component";
import { UserComponent } from "../../pages/user/user.component";
import { TablesComponent } from "../../pages/tables/tables.component";
import { TypographyComponent } from "../../pages/typography/typography.component";
import { CategoriesDashboardComponent as CategoriesComponent } from "../../pages/categories/categories-dashboard/categories-dashboard.component";
import { PlaylistsDashboardComponent as PlaylistComponent } from "../../pages/playlists/playlists-dashboard/playlists-dashboard.component";
import { AudioContentDashboardComponent } from "../../pages/audio-content/audio-content-dashboard/audio-content-dashboard.component";
import { ConsultationDashboardComponent } from "../../pages/consultation/consultation-dashboard/consultation-dashboard.component";
// import { RtlComponent } from "../../pages/rtl/rtl.component";

export const AdminLayoutRoutes: Routes = [
  { path: "categories", component: CategoriesComponent },
  { path: "playlists/:categoryId", component: PlaylistComponent },
  { path: "audioContent", component: AudioContentDashboardComponent },
  { path: "consultation", component: ConsultationDashboardComponent },
  { path: "dashboard", component: DashboardComponent },
  { path: "icons", component: IconsComponent },
  { path: "maps", component: MapComponent },
  { path: "notifications", component: NotificationsComponent },
  { path: "user", component: UserComponent },
  { path: "tables", component: TablesComponent },
  { path: "typography", component: TypographyComponent },
  // { path: "rtl", component: RtlComponent }
];
