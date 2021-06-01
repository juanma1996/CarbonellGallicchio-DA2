import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormArray, FormGroup, FormControl, Validators } from '@angular/forms';
import { CategoriesService } from 'src/app/services/categories/categories.service';
import { AudioContentService } from 'src/app/services/audio-content/audio-content.service';
import { ToastrService } from 'ngx-toastr';
import { AudioFormComponent } from '../audio-form/audio-form.component';
import { ActivatedRoute, Router } from '@angular/router';
import { AudioContentModel } from 'src/app/models/audioContent/audio-content-model';

@Component({
  selector: 'app-edit-audio-content',
  templateUrl: './edit-audio-content.component.html',
  styleUrls: ['./edit-audio-content.component.scss']
})
export class EditAudioContentComponent implements OnInit {
  @ViewChild(AudioFormComponent, { static: true }) public audioForm: AudioFormComponent;
  editAudioContentForm: FormGroup;
  audioContentId;
  editingAudioContent: AudioContentModel = {} as AudioContentModel;

  selectedPlaylist: FormGroup;

  public newPlaylist: boolean = false;

  constructor(
    private audioContentService: AudioContentService,
    public toastr: ToastrService,
    private fb: FormBuilder,
    public route: ActivatedRoute,
    private router: Router,
  ) { }

  ngOnInit(): void {
    this.audioContentId = Number(this.route.snapshot.paramMap.get('audioContentId'));
    this.getAudioContentInfo(this.audioContentId);
    this.initializeAudioContentForm(this.editingAudioContent);
  }

  async getAudioContentInfo(id: number) {
    this.audioContentService.getAudioContentById(id)
      .subscribe(
        response => {
          console.log(response);
          this.editingAudioContent = response;
          this.updateForm();
          this.updateMultiSelects();
        },
        catchError => {
          console.log(catchError);
          this.router.navigateByUrl('categories');
          this.setError(catchError)
        }
      )
  }

  initializeAudioContentForm(audioContent): void {
    this.editAudioContentForm = this.fb.group({
      id: new FormControl(this.audioContentId, Validators.required),
      name: new FormControl(audioContent.name, Validators.required),
      creatorName: new FormControl(audioContent.creatorName, Validators.required),
      //duration: new FormControl(null),
      imageUrl: new FormControl(audioContent.imageUrl),
      audioUrl: new FormControl(audioContent.audioUrl, Validators.required),
      categories: this.fb.array([], Validators.required),
      playlists: this.fb.array([], Validators.required)
    });
    this.selectedPlaylist = this.fb.group({
    })
  }

  get categories(): FormArray {
    return this.editAudioContentForm.get('categories') as FormArray;
  }

  updateForm() {
    this.editAudioContentForm.get('name').setValue(this.editingAudioContent.name);
    this.editAudioContentForm.get('creatorName').setValue(this.editingAudioContent.creatorName);
    this.editAudioContentForm.get('imageUrl').setValue(this.editingAudioContent.imageUrl);
    this.editAudioContentForm.get('audioUrl').setValue(this.editingAudioContent.audioUrl);
    
  }

  updateMultiSelects() {
    var categories = [{ id: 1, name: 'Meditar' }];
    var playlists = [{ id: 21, name: "Chupala", description: "Hardcode" }];
    var originalCategory = this.fb.group({
      id: categories[0].id,
      name: categories[0].name
    })
    this.categories.push(originalCategory);

    var originalPlaylist = this.fb.group({
      id : playlists[0].id,
      name: playlists[0].name,
      description: playlists[0].description
    })
    this.playlists.push(originalPlaylist);
    // this.audioForm.originalCategory = [{ id: this.editingAudioContent.categories[0].id, itemName: this.editingAudioContent.categories[0].name }]
    // if (this.editingAudioContent.playlists.length > 0) {
    //   this.audioForm.originalPlaylist = [{ id: this.editingAudioContent.playlists[0].id, itemName: this.editingAudioContent.playlists[0].name }]
    // }
    this.audioForm.originalCategory = [{ id: categories[0].id, itemName: categories[0].name }]
    if (playlists.length > 0) {
      this.audioForm.originalPlaylist = [{ id: playlists[0].id, itemName: playlists[0].name }]
    }
  }

  updateAudioContent() {
    this.addNewPlaylist();
    this.audioForm.submited = true;
    if (!this.editAudioContentForm.invalid) {
      this.audioContentService.update(this.editAudioContentForm.value)
        .subscribe(
          response => {
            this.setSuccess();
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

  get playlists(): FormArray {
    return this.editAudioContentForm.get('playlists') as FormArray;
  }

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
      "The audio content was successfully updated",
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
