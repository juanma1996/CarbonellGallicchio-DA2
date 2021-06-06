import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router'
import { PlaylistBasicInfo } from '../../../models/playlist/playlist-basic-info';
import { CategoriesService } from 'src/app/services/categories/categories.service';
import { ToastrService } from 'ngx-toastr';
import { AudioContentService } from 'src/app/services/audio-content/audio-content.service';
import { AudioContentModel } from 'src/app/models/audioContent/audio-content-model';

@Component({
  selector: 'app-playlists-dashboard',
  templateUrl: './playlists-dashboard.component.html',
  styleUrls: ['./playlists-dashboard.component.scss']
})
export class PlaylistsDashboardComponent implements OnInit {

  playlists: PlaylistBasicInfo[] = [];
  public audioContents: AudioContentModel[] = [];
  public errorBackend: string = '';
  public categoryId;
  public isCollapsed: boolean = false;

  constructor(
    public route: ActivatedRoute,
    private categoriesService: CategoriesService,
    public toastr: ToastrService,
    private audioContentService: AudioContentService
  ) { }

  ngOnInit() {
    this.categoryId = this.route.snapshot.paramMap.get('categoryId');
    this.categoriesService.getPlaylistByCategory(this.categoryId)
      .subscribe(
        response => {
          this.getPlaylists(response)
        },
        catchError => {
          this.setError(catchError);
        }
      )
    this.getAudioContents();
  }

  private getPlaylists(response) {
    this.playlists = response;
  }

  getAudioContents() {
    this.audioContentService.getAudioContentByCategory(this.categoryId)
      .subscribe(
        response => {
          this.audioContents = response;
        },
        catchError => {
          console.log(catchError);
        }
      )
  }

  private setError(message) {
    this.toastr.show(
      '<span data-notify="icon" class="tim-icons icon-bell-55"></span>',
      message,
      {
        timeOut: 5000,
        closeButton: true,
        enableHtml: true,
        toastClass: "alert alert-danger alert-with-icon",
        positionClass: "toast-top-right"
      }
    );
  }

}
