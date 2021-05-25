import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { BrowserModule } from "@angular/platform-browser";
import { Routes, RouterModule } from "@angular/router";

import { AdminLayoutComponent } from "./layouts/admin-layout/admin-layout.component";
import { AuthLayoutComponent } from "./layouts/auth-layout/auth-layout.component";
import { RtlLayoutComponent } from "./layouts/rtl-layout/rtl-layout.component";
import { AdminGuard } from './guards/admin.guard';
import { PacientLayoutComponent } from './layouts/pacient-layout/pacient-layout.component';

const routes: Routes = [
  {
    path: "",
    redirectTo: "categories",
    pathMatch: "full"
  },
  {
    path: "",
    component: AdminLayoutComponent, canActivate: [AdminGuard],
    children: [
      {
        path: "",
        loadChildren:
          "./pages/examples/dashboard/dashboard.module#DashboardModule"
      },
      {
        path: "psychologist",
        loadChildren:
          "./pages/psychologist/psychologist.module#PsychologistModule"
      },
      {
        path: "components",
        loadChildren:
          "./pages/examples/components/components.module#ComponentsPageModule"
      },
      {
        path: "forms",
        loadChildren: "./pages/examples/forms/forms.module#Forms"
      },
      {
        path: "tables",
        loadChildren: "./pages/examples/tables/tables.module#TablesModule"
      },
      {
        path: "maps",
        loadChildren: "./pages/examples/maps/maps.module#MapsModule"
      },
      {
        path: "widgets",
        loadChildren: "./pages/examples/widgets/widgets.module#WidgetsModule"
      },
      {
        path: "charts",
        loadChildren: "./pages/examples/charts/charts.module#ChartsModule"
      },
      {
        path: "calendar",
        loadChildren:
          "./pages/examples/calendar/calendar.module#CalendarModulee"
      },
      {
        path: "",
        loadChildren:
          "./pages/examples/pages/user/user-profile.module#UserModule"
      },
      {
        path: "",
        loadChildren:
          "./pages/examples/pages/timeline/timeline.module#TimelineModule"
      }
    ]
  },
  {
    path: "",
    component: PacientLayoutComponent,
    children: [
      {
        path: "categories",
        loadChildren:
          "./pages/categories/categories.module#CategoriesModule"
      },
      {
        path: "audioContent",
        loadChildren:
          "./pages/audio-content/audio-content.module#AudioContentModule"
      },
      {
        path: "playlists",
        loadChildren:
          "./pages/playlists/playlists.module#PlaylistsModule"
      },
      {
        path: "consultation",
        loadChildren:
          "./pages/consultation/consultation.module#ConsultationModule"
      },
    ]
  },
  {
    path: "",
    component: AuthLayoutComponent,
    children: [
      {
        path: "pages",
        loadChildren: "./pages/examples/pages/pages.module#PagesModule"
      },
      {
        path: "login",
        loadChildren: "./pages/login/login.module#LoginModule"
      }
    ]
  },
  {
    path: "",
    component: RtlLayoutComponent,
    children: [
      {
        path: "pages",
        loadChildren: "./pages/examples/pages/rtl/rtl.module#RtlModule"
      }
    ]
  },
  {
    path: "**",
    redirectTo: "categories"
  }
];

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    RouterModule.forRoot(routes, {
      useHash: true,
      scrollPositionRestoration: "enabled",
      anchorScrolling: "enabled",
      scrollOffset: [0, 64]
    })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}
