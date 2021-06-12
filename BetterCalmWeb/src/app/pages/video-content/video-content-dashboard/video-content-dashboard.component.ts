import { Component, OnInit } from '@angular/core';
import { VideoContentBasicInfo } from 'src/app/models/videoContent/video-content-basic-info';
import { VideoContentService } from 'src/app/services/video-content/video-content-service';
import { ToastService } from 'src/app/common/toast.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-video-content-dashboard',
  templateUrl: './video-content-dashboard.component.html',
  styleUrls: ['./video-content-dashboard.component.scss']
})
export class VideoContentDashboardComponent implements OnInit {
  public videoContents: VideoContentBasicInfo[] = [];
  public playlistId: number;

  constructor(
    public route: ActivatedRoute,
    private videoContentService: VideoContentService,
    private customToastr: ToastService
  ) { }

  ngOnInit(): void {
    this.playlistId = Number(this.route.snapshot.paramMap.get('playlistId'));
    this.getVideoContents(this.playlistId);
  }

  getVideoContents(id: number) {
    this.videoContentService.getVideoContentByPlaylist(id)
      .subscribe(
        response => {
          this.videoContents = response;
        },
        catchError => {
          this.customToastr.setError(catchError);
        }
      )
  }

  updateVideos() {
    this.getVideoContents(this.playlistId);
  }

}
