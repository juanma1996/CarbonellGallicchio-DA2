import { Component, OnInit } from '@angular/core';
import { AudioContentModel } from 'src/app/models/audioContent/audio-content-model';
import { CategoriesService } from 'src/app/services/categories/categories.service';
import { CategoryModel } from 'src/app/models/category/category-model';
import { ToastrService } from 'ngx-toastr';
import { PlaylistBasicInfo } from 'src/app/models/playlist/playlist-basic-info';
import { PlaylistModel } from 'src/app/models/playlist/playlist-model';
import { AudioContentService } from 'src/app/services/audio-content/audio-content.service';
import { catchError } from 'rxjs/operators';

@Component({
  selector: 'app-create-audio-content',
  templateUrl: './create-audio-content.component.html',
  styleUrls: ['./create-audio-content.component.scss']
})
export class CreateAudioContentComponent implements OnInit {

  public audioContent: AudioContentModel = new AudioContentModel();

  public categoriesData = [];
  public playlistsData = [];
  public newPlaylist: boolean = false;
  public selectedCategory: CategoryModel;
  public selectedPlaylist: PlaylistBasicInfo ;

  constructor(
    private categoriesService: CategoriesService,
    private audioContentService: AudioContentService,
    public toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.getCategories();
  }

  getCategories() {
    this.categoriesService.get()
      .subscribe(
        response => {
          this.mapData(response, this.categoriesData);
        },
        catchError => {
          this.setError(catchError);
        }
      )
  }

  getPlaylistByCategory() {
    this.categoriesService.getPlaylistByCategory(this.selectedCategory.id)
      .subscribe(
        response => {
          this.mapData(response, this.playlistsData);
        },
        catchError => {
          this.setError(catchError);
        }
      )
  }

  createAudioContent() {
    delete(this.audioContent.duration);
    this.audioContent.categories.push(this.selectedCategory);
    this.audioContent.playlists.push(this.selectedPlaylist);
    this.audioContentService.add(this.audioContent)
      .subscribe(
        response => {
          this.setSuccess();
        },
        catchError => {
          this.setError(catchError);
        }
      )
  }

  mapData(originalData, multiSelectData) {
    originalData.forEach(item => {
      var data = {
        id: item.id,
        itemName: item.name
      }
      multiSelectData.push(data);
    });
  }

  categorySelect(item: any) {
    this.audioContent.categories = [];
    this.selectedCategory = {
      id: item.id,
      name: item.itemName
    };
    this.getPlaylistByCategory();
  }

  categoryDeSelect(item: any) {
    delete (this.selectedCategory)
    console.log(this.audioContent)
  }

  playlistSelect(item: any) {
    this.audioContent.playlists = [];
    this.selectedPlaylist = {
      id: item.id,
      name: item.itemName,
      description: "This is a hardcode description"
    };
  }

  playlistDeSelect(item: any) {
    delete (this.audioContent.playlists)
    console.log(this.audioContent)
  }

  createPlaylist(item: any) {
    this.selectedPlaylist = {
      name: "",
      description: ""
    } as PlaylistBasicInfo;
    console.log('Funciona');
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

  private setSuccess() {
    this.toastr.show(
      '<span data-notify="icon" class="tim-icons icon-bell-55"></span>',
      "The audio content was successfully created",
      {
        timeOut: 5000,
        closeButton: true,
        enableHtml: true,
        toastClass: "alert alert-success alert-with-icon",
        positionClass: "toast-top-right"
      }
    );
  }

}
