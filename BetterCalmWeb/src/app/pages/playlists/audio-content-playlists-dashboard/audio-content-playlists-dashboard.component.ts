import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router'
import { PlaylistBasicInfo } from '../../../models/playlist/playlist-basic-info';
import { CategoriesService } from 'src/app/services/categories/categories.service';
import { AudioContentService } from 'src/app/services/audio-content/audio-content.service';
import { AudioContentModel } from 'src/app/models/audioContent/audio-content-model';
import { ToastService } from 'src/app/common/toast.service';

@Component({
  selector: 'app-audio-content-playlists-dashboard',
  templateUrl: './audio-content-playlists-dashboard.component.html',
  styleUrls: ['./audio-content-playlists-dashboard.component.scss']
})
export class AudioContentPlaylistsDashboardComponent implements OnInit {

  playlists: PlaylistBasicInfo[] = [];
  public audioContents: AudioContentModel[] = [];
  public errorBackend: string = '';
  public categoryId;
  public isCollapsed: boolean = false;

  constructor(
    public route: ActivatedRoute,
    private categoriesService: CategoriesService,
    private customToastr: ToastService,
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
          this.customToastr.setError(catchError);
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
          this.customToastr.setError(catchError);
        }
      )
  }


}
