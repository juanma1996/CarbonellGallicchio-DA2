import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router'
import { PlaylistBasicInfo } from '../../../models/playlist/playlist-basic-info';
import { CategoriesService } from 'src/app/services/categories/categories.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-playlists-dashboard',
  templateUrl: './playlists-dashboard.component.html',
  styleUrls: ['./playlists-dashboard.component.scss']
})
export class PlaylistsDashboardComponent implements OnInit {

  playlists: PlaylistBasicInfo[] = [];
  public errorBackend: string = '';
  public categoryId;

  constructor(public route: ActivatedRoute, private categoriesService: CategoriesService, public toastr: ToastrService) { }

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
  }

  private getPlaylists(response) {
    this.playlists = response;
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
