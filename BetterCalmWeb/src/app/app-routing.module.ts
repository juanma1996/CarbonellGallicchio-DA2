import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { BrowserModule } from "@angular/platform-browser";
import { Routes, RouterModule } from "@angular/router";

import { AdminLayoutComponent } from "./layouts/admin-layout/admin-layout.component";
import { AuthLayoutComponent } from "./layouts/auth-layout/auth-layout.component";
import { AdminGuard } from './guards/admin.guard';
import { PacientLayoutComponent } from './layouts/pacient-layout/pacient-layout.component';

const routes: Routes = [
  {
    path: "",
    redirectTo: "categories/audioContents",
    pathMatch: "full"
  },
  {
    path: "",
    component: AdminLayoutComponent, canActivate: [AdminGuard],
    children: [
      {
        path: "administrator",
        loadChildren:
          "./pages/administrator/administrator.module#AdministratorModule"
      },
      {
        path: "psychologist",
        loadChildren:
          "./pages/psychologist/psychologist.module#PsychologistModule"
      },
      {
        path: "bonus",
        loadChildren:
          "./pages/bonus/bonus.module#BonusModule"
      },
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
        path: "videoContent",
        loadChildren:
          "./pages/video-content/video-content.module#VideoContentModule"
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
      {
        path: "contentImporter",
        loadChildren:
          "./pages/content-importer/content-importer.module#ContentImporterModule"
      },
    ]
  },
  {
    path: "",
    component: AuthLayoutComponent,
    children: [
      {
        path: "login",
        loadChildren: "./pages/login/login.module#LoginModule"
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
export class AppRoutingModule { }
