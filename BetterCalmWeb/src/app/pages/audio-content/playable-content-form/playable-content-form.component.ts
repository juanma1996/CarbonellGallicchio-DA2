import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators, FormArray } from '@angular/forms';
import { CategoriesService } from 'src/app/services/categories/categories.service';
import { ToastService } from 'src/app/common/toast.service';
import { Observable } from 'rxjs';

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
  originalPlaylists = [];
  originalCategories = [];


  public categoriesData = [];
  public allPlaylists = [];
  public playlistsData = [];
  public newPlaylist: boolean = false;

  constructor(
    private categoriesService: CategoriesService,
    public customToastr: ToastService,
    private fb: FormBuilder
  ) { }

  ngOnInit(): void {
    console.log(this.selectedCategory)
    this.getCategories();
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
          this.getAllPlaylists();
        },
        catchError => {
          this.customToastr.setError(catchError);
        }
      )
  }

  async getPlaylistByCategory(id: number) {
    this.playlistsData = [];
    this.categoriesService.getPlaylistByCategory(id)
      .subscribe(
        response => {
          this.allPlaylists.push(...response);
          this.mapData(this.allPlaylists, this.playlistsData)
        },
        catchError => {
          this.customToastr.setError(catchError);
        }
      )
  }

  getAllPlaylists() {
    this.categoriesData.forEach(async category => {
      await this.getPlaylistByCategory(category.id);
    })
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
    var date = new Date(this.duration.value);
    var transformDuration = {
      "hours": date.getHours(),
      "minutes": date.getMinutes(),
    }
    this.playableContentContentForm.get('duration').setValue(transformDuration);
  }

  get categories(): FormArray {
    return this.playableContentContentForm.get('categories') as FormArray;
  }

  get selectedCategoryId() {
    return this.selectedCategory.get('id').value;
  }

  categorySelect(item: any) {
    //if (this.categories.value.length > 0) this.categories.removeAt(0);
    this.selectedCategory = this.fb.group({
      id: item.id,
      name: item.itemName
    })
    this.categories.push(this.selectedCategory);
    // this.getPlaylistByCategory(item.id);
  }

  categoryDeSelect(item: any) {
    let index = this.categories.value.findIndex(x => x.id === item.id);
    this.categories.removeAt(index);
  }

  get playlists(): FormArray {
    return this.playableContentContentForm.get('playlists') as FormArray;
  }

  playlistSelect(item: any) {
    //if (this.playlists.value.length > 0) this.playlists.removeAt(0);
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
