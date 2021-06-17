import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators, FormArray } from '@angular/forms';
import { CategoriesService } from 'src/app/services/categories/categories.service';
import { ToastService } from 'src/app/common/toast.service';
import { Observable } from 'rxjs';
import { PlaylistsService } from 'src/app/services/playlists/playlists.service';

@Component({
  selector: 'app-playable-content-form',
  templateUrl: './playable-content-form.component.html',
  styleUrls: ['./playable-content-form.component.scss']
})
export class PlayableContentFormComponent implements OnInit {
  @Input() parentForm: FormGroup;
  @Input() isAudio: boolean;
  mytime: Date = new Date();

  playableContentContentForm: FormGroup;
  selectedCategory: FormGroup;
  selectedPlaylist: FormGroup;
  submited: boolean = false;
  convertedDate: boolean = false;
  originalPlaylists = [];
  originalCategories = [];


  public categoriesData = [];
  public allPlaylists = [];
  public playlistsData = [];
  public newPlaylist: boolean = false;

  constructor(
    private categoriesService: CategoriesService,
    private playlistsService: PlaylistsService,
    public customToastr: ToastService,
    private fb: FormBuilder
  ) { }

  ngOnInit(): void {
    this.getCategories();
    this.getAllPlaylists();
    this.initializePlayableContentContentForm();
  }

  initializePlayableContentContentForm(): void {
    this.playableContentContentForm = this.parentForm;
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
          this.customToastr.setError(catchError);
        }
      )
  }

  getAllPlaylists() {
    this.playlistsService.get()
      .subscribe(
        response => {
          if (response.length > 0) {
            this.mapData(response, this.playlistsData);
          } else {
            this.customToastr.setError("There are no playlist created for selection.")
          }
        },
        catchError => {
          this.customToastr.setError(catchError);
        }
      )
  }

  mapData(originalData, multiSelectData) {
    var mappedArray = [];
    originalData.forEach(item => {
      var data = {
        id: item.id,
        itemName: item.name
      }
      mappedArray.push(data);
    });
    multiSelectData.push(...mappedArray)
  }

  get duration(): FormControl {
    return this.playableContentContentForm.get('duration') as FormControl;
  }

  transformTime() {
    if (this.duration.value && !this.convertedDate) {
      this.convertedDate = true;
      var date = new Date(this.duration.value);
      var transformedDuration: string = date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds();
      this.playableContentContentForm.get('duration').setValue(transformedDuration);
    }
  }

  get categories(): FormArray {
    return this.playableContentContentForm.get('categories') as FormArray;
  }

  get selectedCategoryId() {
    return this.selectedCategory.get('id').value;
  }

  categorySelect(item: any) {
    this.selectedCategory = this.fb.group({
      id: item.id,
      name: item.itemName
    })
    this.categories.push(this.selectedCategory);
  }

  categoryDeSelect(item: any) {
    let index = this.categories.value.findIndex(x => x.id === item.id);
    this.categories.removeAt(index);
  }

  get playlists(): FormArray {
    return this.playableContentContentForm.get('playlists') as FormArray;
  }

  playlistSelect(item: any) {
    this.selectedPlaylist = this.fb.group({
      id: item.id,
      name: item.itemName,
      description: "Empty"
    })
    this.playlists.push(this.selectedPlaylist);
  }

  playlistDeSelect(item: any) {
    let index = this.playlists.value.findIndex(x => x.id === item.id);
    this.playlists.removeAt(index);
  }

  createNewPlaylist(item: any) {
    this.selectedPlaylist = this.fb.group({
      name: new FormControl(null, Validators.required),
      description: new FormControl(null, Validators.required),
    })
    this.playlists.push(this.selectedPlaylist);
  }

  resetForm() {
    this.submited = false;
    this.playableContentContentForm.reset();
    this.originalCategories = [];
    this.originalPlaylists = [];
  }
}
