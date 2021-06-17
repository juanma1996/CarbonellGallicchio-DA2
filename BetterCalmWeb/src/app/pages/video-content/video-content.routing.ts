import { Routes } from "@angular/router";
import { VideoContentDashboardComponent } from './video-content-dashboard/video-content-dashboard.component';
import { CreateVideoContentComponent } from './create-video-content/create-video-content.component';
import { AdminGuard } from 'src/app/guards/admin.guard';
import { EditVideoContentComponent } from './edit-video-content/edit-video-content.component';


export const VideoContentRoutes: Routes = [
    {
        path: "edit/:videoContentId",
        component: EditVideoContentComponent, canActivate: [AdminGuard]
    },
    {
        path: ":categoryId/:playlistId",
        component: VideoContentDashboardComponent
    },
    {
        path: "",
        component: CreateVideoContentComponent, canActivate: [AdminGuard]
    },
];
