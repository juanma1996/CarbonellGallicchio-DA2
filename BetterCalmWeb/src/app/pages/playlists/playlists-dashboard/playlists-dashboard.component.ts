import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router'
import { PlaylistBasicInfo } from '../../../models/playlist/playlist-basic-info';
import { CategoriesService } from 'src/app/services/categories/categories.service';

@Component({
  selector: 'app-playlists-dashboard',
  templateUrl: './playlists-dashboard.component.html',
  styleUrls: ['./playlists-dashboard.component.scss']
})
export class PlaylistsDashboardComponent implements OnInit {

  playlists: PlaylistBasicInfo[] = [];
  public errorBackend: string = '';

  constructor(private _location: Location, public route: ActivatedRoute, private categoriesService: CategoriesService) { }

  backClicked() {
    this._location.back();
  }

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('categoryId');
    this.categoriesService.getPlaylistByCategory(id)
      .subscribe(
        response => {
          this.getPlaylists(response)
        },
        catchError => {
          console.log(catchError);
          this.errorBackend = catchError + ', fix it please';
        }
      )
  }

  private getPlaylists(response) {
    this.playlists = response;
  }

}
