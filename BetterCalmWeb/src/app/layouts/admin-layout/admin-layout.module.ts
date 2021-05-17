import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from "@angular/router";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";

import { AdminLayoutRoutes } from "./admin-layout.routing";
import { DashboardComponent } from "../../pages/dashboard/dashboard.component";
import { IconsComponent } from "../../pages/icons/icons.component";
import { MapComponent } from "../../pages/map/map.component";
import { NotificationsComponent } from "../../pages/notifications/notifications.component";
import { UserComponent } from "../../pages/user/user.component";
import { TablesComponent } from "../../pages/tables/tables.component";
import { TypographyComponent } from "../../pages/typography/typography.component";
import { CategoriesDashboardComponent } from "../../pages/categories/categories-dashboard/categories-dashboard.component";
import { CategoryCardComponent } from "../../pages/categories/category-card/category-card.component";
import {PlaylistsDashboardComponent} from '../../pages/playlists/playlists-dashboard/playlists-dashboard.component';
import {PlaylistCardComponent} from '../../pages/playlists/playlist-card/playlist-card.component';
import { AudioContentDashboardComponent } from "../../pages/audio-content/audio-content-dashboard/audio-content-dashboard.component";

import { NgbModule } from "@ng-bootstrap/ng-bootstrap";

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(AdminLayoutRoutes),
    FormsModule,
    HttpClientModule,
    NgbModule,
  ],
  declarations: [
    CategoriesDashboardComponent,
    CategoryCardComponent,
    PlaylistsDashboardComponent,
    PlaylistCardComponent,
    AudioContentDashboardComponent,
    DashboardComponent,
    UserComponent,
    TablesComponent,
    IconsComponent,
    TypographyComponent,
    NotificationsComponent,
    MapComponent,
    // RtlComponent
  ]
})
export class AdminLayoutModule {}
