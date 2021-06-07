import { Routes } from "@angular/router";
import { VideoContentDashboardComponent } from './video-content-dashboard/video-content-dashboard.component';


export const VideoContentRoutes: Routes = [
    //   {
    //     path: "edit/:audioContentId",
    //     component: EditAudioContentComponent, canActivate: [AdminGuard]
    //   },
    {
        path: ":categoryId/:playlistId",
        component: VideoContentDashboardComponent
    },
    //   {
    //     path: "",
    //     component: CreateAudioContentComponent, canActivate: [AdminGuard]
    //   },
];
