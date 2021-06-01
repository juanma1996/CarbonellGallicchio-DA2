import { Component, OnInit, ViewChild } from '@angular/core';
import { CategoriesService } from 'src/app/services/categories/categories.service';
import { ToastrService } from 'ngx-toastr';
import { AudioContentService } from 'src/app/services/audio-content/audio-content.service';
import { catchError } from 'rxjs/operators';
import { FormGroup, FormBuilder, FormControl, Validators, Form, FormArray } from '@angular/forms';
import { AudioFormComponent } from '../audio-form/audio-form.component';

@Component({
  selector: 'app-create-audio-content',
  templateUrl: './create-audio-content.component.html',
  styleUrls: ['./create-audio-content.component.scss']
})
export class CreateAudioContentComponent implements OnInit {
  @ViewChild(AudioFormComponent, { static: true }) public audioForm: AudioFormComponent;
  createAudioContentForm: FormGroup;

  // mytime: Date = new Date();

  // audioContentForm: FormGroup;
  // selectedCategory: FormGroup;
  selectedPlaylist: FormGroup;
  create: boolean = false;


  // public categoriesData = [];
  // public playlistsData = [];
  public newPlaylist: boolean = false;

  constructor(
    private categoriesService: CategoriesService,
    private audioContentService: AudioContentService,
    public toastr: ToastrService,
    private fb: FormBuilder
  ) { }

  ngOnInit(): void {
    // this.getCategories();
    this.initializeAudioContentForm();
  }

  initializeAudioContentForm(): void {
    this.audioForm.create =true;
    this.createAudioContentForm = this.fb.group({
      name: new FormControl("Juan", Validators.required),
      creatorName: new FormControl("Desde create", Validators.required),
      //duration: new FormControl(null),
      imageUrl: new FormControl(null),
      audioUrl: new FormControl(null, Validators.required),
      categories: this.fb.array([], Validators.required),
      playlists: this.fb.array([], Validators.required)
    });
    this.selectedPlaylist = this.fb.group({
    })
  }

  // initializeAudioContentForm(): void {
  //   this.audioContentForm = this.fb.group({
  //     name: new FormControl(null, Validators.required),
  //     creatorName: new FormControl(null, Validators.required),
  //     //duration: new FormControl(null),
  //     imageUrl: new FormControl(null),
  //     audioUrl: new FormControl(null, Validators.required),
  //     categories: this.fb.array([], Validators.required),
  //     playlists: this.fb.array([], Validators.required)
  //   });
  //   this.selectedPlaylist = this.fb.group({
  //   })
  // }

  // getCategories() {
  //   this.categoriesService.get()
  //     .subscribe(
  //       response => {
  //         this.mapData(response, this.categoriesData);
  //       },
  //       catchError => {
  //         this.setError(catchError);
  //       }
  //     )
  // }

  // getPlaylistByCategory() {
  //   console.log(this.selectedCategoryId);
  //   this.playlistsData = [];
  //   this.categoriesService.getPlaylistByCategory(this.selectedCategoryId)
  //     .subscribe(
  //       response => {
  //         this.mapData(response, this.playlistsData);
  //       },
  //       catchError => {
  //         this.setError(catchError);
  //       }
  //     )
  // }

  createAudioContent() {
    console.log("estoy afuera perrito")
    this.addNewPlaylist();
    this.create = true;
    if (!this.createAudioContentForm.invalid) {

      this.audioContentService.add(this.createAudioContentForm.value)
        .subscribe(
          response => {
            this.setSuccess();
            //this.getCategories();
          },
          catchError => {
            this.setError(catchError);
          }
        )
    }
    else {
      this.setError("Please verify the entered data.");
    }
  }

  // mapData(originalData, multiSelectData) {
  //   originalData.forEach(item => {
  //     var data = {
  //       id: item.id,
  //       itemName: item.name
  //     }
  //     multiSelectData.push(data);
  //   });
  // }

  // get categories(): FormArray {
  //   return this.createAudioContentForm.get('categories') as FormArray;
  // }

  // get selectedCategoryId() {
  //   return this.selectedCategory.get('id').value;
  // }

  // categorySelect(item: any) {
  //   if (this.categories.value.length > 0) this.categories.removeAt(0);
  //   this.selectedCategory = this.fb.group({
  //     id: item.id,
  //     name: item.itemName
  //   })
  //   this.categories.push(this.selectedCategory);
  //   this.getPlaylistByCategory();
  // }

  // categoryDeSelect(item: any) {
  //   this.categories.removeAt(0);
  // }

  get playlists(): FormArray {
    return this.createAudioContentForm.get('playlists') as FormArray;
  }

  // playlistSelect(item: any) {
  //   if (this.playlists.value.length > 0) this.playlists.removeAt(0);
  //   this.selectedPlaylist = this.fb.group({
  //     id: (item.id, Validators.required),
  //     name: item.itemName,
  //     description: "Empty"
  //   })
  //   this.playlists.push(this.selectedPlaylist);
  // }

  // playlistDeSelect(item: any) {
  //   this.playlists.removeAt(0);
  // }

  // createNewPlaylist(item: any) {
  //   if (this.playlists.value.length > 0) this.playlists.removeAt(0);
  //   this.selectedPlaylist = this.fb.group({
  //     name: new FormControl(null, Validators.required),
  //     description: new FormControl(null, Validators.required),
  //   })
  // }

  addNewPlaylist() {
    if (this.audioForm.newPlaylist) {
      this.playlists.push(this.audioForm.selectedPlaylist);
    }
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
