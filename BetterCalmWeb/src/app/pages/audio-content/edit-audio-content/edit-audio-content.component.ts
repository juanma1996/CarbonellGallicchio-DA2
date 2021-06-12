import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormArray, FormGroup, FormControl, Validators } from '@angular/forms';
import { CategoriesService } from 'src/app/services/categories/categories.service';
import { AudioContentService } from 'src/app/services/audio-content/audio-content.service';
import { ToastrService } from 'ngx-toastr';
import { PlayableContentFormComponent } from '../playable-content-form/playable-content-form.component';
import { ActivatedRoute, Router } from '@angular/router';
import { AudioContentModel } from 'src/app/models/audioContent/audio-content-model';
import { ToastService } from 'src/app/common/toast.service';

@Component({
  selector: 'app-edit-audio-content',
  templateUrl: './edit-audio-content.component.html',
  styleUrls: ['./edit-audio-content.component.scss']
})
export class EditAudioContentComponent implements OnInit {
  @ViewChild(PlayableContentFormComponent, { static: true }) public playableContentForm: PlayableContentFormComponent;
  editAudioContentForm: FormGroup;
  audioContentId;
  editingAudioContent: AudioContentModel = {} as AudioContentModel;

  selectedPlaylist: FormGroup;

  public newPlaylist: boolean = false;

  constructor(
    private audioContentService: AudioContentService,
    public customToastr: ToastService,
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
          this.editingAudioContent = response;
          this.updateForm();
          this.updateMultiSelects();
        },
        catchError => {
          this.router.navigateByUrl('categories');
          this.customToastr.setError(catchError)
        }
      )
  }

  initializeAudioContentForm(audioContent): void {
    this.editAudioContentForm = this.fb.group({
      id: new FormControl(this.audioContentId, Validators.required),
      name: new FormControl(audioContent.name, Validators.required),
      creatorName: new FormControl(audioContent.creatorName, Validators.required),
      duration: new FormControl(null),
      imageUrl: new FormControl(audioContent.imageUrl),
      audioUrl: new FormControl(audioContent.audioUrl, Validators.pattern(
        /^(?:(?:(?:https?|ftp):)?\/\/)(?:\S+(?::\S*)?@)?(?:(?!(?:10|127)(?:\.\d{1,3}){3})(?!(?:169\.254|192\.168)(?:\.\d{1,3}){2})(?!172\.(?:1[6-9]|2\d|3[0-1])(?:\.\d{1,3}){2})(?:[1-9]\d?|1\d\d|2[01]\d|22[0-3])(?:\.(?:1?\d{1,2}|2[0-4]\d|25[0-5])){2}(?:\.(?:[1-9]\d?|1\d\d|2[0-4]\d|25[0-4]))|(?:(?:[a-z\u00a1-\uffff0-9]-*)*[a-z\u00a1-\uffff0-9]+)(?:\.(?:[a-z\u00a1-\uffff0-9]-*)*[a-z\u00a1-\uffff0-9]+)*(?:\.(?:[a-z\u00a1-\uffff]{2,})).?)(?::\d{2,5})?(?:[\/?#]\S*)?$/i
      )),
      categories: this.fb.array([], Validators.required),
      playlists: this.fb.array([])
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
    this.editAudioContentForm.get('duration').setValue(this.toDate(this.editingAudioContent.duration));
  }

  updateMultiSelects() {
    this.editingAudioContent.categories.forEach(category => {
      var originalCategory = this.fb.group({
        id: category.id,
        name: category.name
      })
      this.playableContentForm.selectedCategory = originalCategory;
      this.categories.push(originalCategory);
      this.playableContentForm.originalCategories.push({ id: category.id, itemName: category.name });
      this.playableContentForm.getPlaylistByCategory(category.id);
    });

    this.editingAudioContent.playlists.forEach(playlist => {
      var originalPlaylist = this.fb.group({
        id: playlist.id,
        name: playlist.name,
        description: playlist.description
      })
      this.playlists.push(originalPlaylist);
      this.playableContentForm.originalPlaylists.push({ id: playlist.id, itemName: playlist.name });
    })
  }

  toDate(originalDuration) {
    var now = new Date();
    now.setHours(originalDuration.substr(0, originalDuration.indexOf(":")));
    now.setMinutes(originalDuration.substr(3, originalDuration.indexOf(":")));
    now.setSeconds(originalDuration.substr(6, originalDuration.indexOf(":")));
    return now;
  }

  updateAudioContent() {
    this.playableContentForm.transformTime();
    this.playableContentForm.submited = true;
    if (!this.editAudioContentForm.invalid) {
      this.audioContentService.update(this.editAudioContentForm.value)
        .subscribe(
          response => {
            this.customToastr.setSuccess("The audio content was successfully updated");
            this.playableContentForm.resetForm();
          },
          catchError => {
            this.customToastr.setError(catchError);
          }
        )
    }
    else {
      this.customToastr.setError("Please verify the entered data.");
    }
  }

  get playlists(): FormArray {
    return this.editAudioContentForm.get('playlists') as FormArray;
  }

}
