import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PlaylistBasicInfo } from 'src/app/models/playlist/playlist-basic-info';
import { CategoriesService } from 'src/app/services/categories/categories.service';
import { ToastService } from 'src/app/common/toast.service';
import { VideoContentService } from 'src/app/services/video-content/video-content-service';
import { VideoContentBasicInfo } from 'src/app/models/videoContent/video-content-basic-info';

@Component({
  selector: 'app-video-content-playlist-dashboard',
  templateUrl: './video-content-playlist-dashboard.component.html',
  styleUrls: ['./video-content-playlist-dashboard.component.scss']
})
export class VideoContentPlaylistDashboardComponent implements OnInit {

  playlists: PlaylistBasicInfo[] = [];
  public videoContents: VideoContentBasicInfo[] = [];
  public categoryId;
  public isCollapsed: boolean = false;

  constructor(
    public route: ActivatedRoute,
    private categoriesService: CategoriesService,
    private videoContentService: VideoContentService,
    private customToastr: ToastService,
  ) { }

  ngOnInit() {
    this.categoryId = this.route.snapshot.paramMap.get('categoryId');
    this.categoriesService.getPlaylistByCategory(this.categoryId)
      .subscribe(
        response => {
          this.playlists = response;
        },
        catchError => {
          this.customToastr.setError(catchError);
        }
      )
    this.getVideoContents();
  }

  getVideoContents() {
    this.videoContentService.getVideoContentByCategory(this.categoryId)
      .subscribe(
        response => {
          this.videoContents = response;
        },
        catchError => {
          this.customToastr.setError(catchError);
        }
      )
  }
}
