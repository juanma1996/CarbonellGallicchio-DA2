import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators, FormArray } from '@angular/forms';
import { CategoriesService } from 'src/app/services/categories/categories.service';
import { AudioContentService } from 'src/app/services/audio-content/audio-content.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-audio-form',
  templateUrl: './audio-form.component.html',
  styleUrls: ['./audio-form.component.scss']
})
export class AudioFormComponent implements OnInit {
  @Input() parentForm: FormGroup;
  @Input() isAudio: boolean;
  mytime: Date = new Date();

  audioContentForm: FormGroup;
  selectedCategory: FormGroup;
  selectedPlaylist: FormGroup;
  submited: boolean = false;
  originalPlaylist = [];
  originalCategory = [];


  public categoriesData = [];
  public playlistsData = [];
  public newPlaylist: boolean = false;

  constructor(
    private categoriesService: CategoriesService,
    private audioContentService: AudioContentService,
    public toastr: ToastrService,
    private fb: FormBuilder
  ) { }

  ngOnInit(): void {
    this.getCategories();
    this.initializeAudioContentForm();
  }

  initializeAudioContentForm(): void {
    this.audioContentForm = this.parentForm;
    this.selectedPlaylist = this.fb.group({
    })
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

  getPlaylistByCategory(id: number) {
    console.log(id);
    this.playlistsData = [];
    this.categoriesService.getPlaylistByCategory(id)
      .subscribe(
        response => {
          this.mapData(response, this.playlistsData);
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

  get categories(): FormArray {
    return this.audioContentForm.get('categories') as FormArray;
  }

  get selectedCategoryId() {
    return this.selectedCategory.get('id').value;
  }

  categorySelect(item: any) {
    if (this.categories.value.length > 0) this.categories.removeAt(0);
    this.selectedCategory = this.fb.group({
      id: item.id,
      name: item.itemName
    })
    this.categories.push(this.selectedCategory);
    this.getPlaylistByCategory(item.id);
  }

  categoryDeSelect(item: any) {
    this.categories.removeAt(0);
  }

  get playlists(): FormArray {
    return this.audioContentForm.get('playlists') as FormArray;
  }

  playlistSelect(item: any) {
    if (this.playlists.value.length > 0) this.playlists.removeAt(0);
    this.selectedPlaylist = this.fb.group({
      id: item.id,
      name: item.itemName,
      description: "Empty"
    })
    this.playlists.push(this.selectedPlaylist);
  }

  playlistDeSelect(item: any) {
    this.playlists.removeAt(0);
  }

  createNewPlaylist(item: any) {
    if (this.playlists.value.length > 0) this.playlists.removeAt(0);
    this.selectedPlaylist = this.fb.group({
      name: new FormControl(null, Validators.required),
      description: new FormControl(null, Validators.required),
    })
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
