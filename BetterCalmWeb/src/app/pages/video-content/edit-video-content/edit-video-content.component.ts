import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators, FormArray } from '@angular/forms';
import { AudioContentModel } from 'src/app/models/audioContent/audio-content-model';
import { PlayableContentFormComponent } from '../../audio-content/playable-content-form/playable-content-form.component';
import { VideoContentService } from 'src/app/services/video-content/video-content-service';
import { ActivatedRoute, Router } from '@angular/router';
import { VideoContentBasicInfo } from 'src/app/models/videoContent/video-content-basic-info';
import { ToastService } from 'src/app/common/toast.service';

@Component({
  selector: 'app-edit-video-content',
  templateUrl: './edit-video-content.component.html',
  styleUrls: ['./edit-video-content.component.scss']
})
export class EditVideoContentComponent implements OnInit {
  @ViewChild(PlayableContentFormComponent, { static: true }) public playableContentForm: PlayableContentFormComponent;
  editVideoContentForm: FormGroup;
  videoContentId;
  editingVideoContent: VideoContentBasicInfo = {} as VideoContentBasicInfo;

  selectedPlaylist: FormGroup;

  public newPlaylist: boolean = false;

  constructor(
    private videoContentService: VideoContentService,
    private fb: FormBuilder,
    public route: ActivatedRoute,
    private router: Router,
    public customToast: ToastService
  ) { }

  ngOnInit(): void {
    this.videoContentId = Number(this.route.snapshot.paramMap.get('videoContentId'));
    this.getVideoContentInfo(this.videoContentId);
    this.initializeVideoContentForm();
  }

  getVideoContentInfo(id: number) {
    this.videoContentService.getVideoContentById(id)
      .subscribe(
        response => {
          this.editingVideoContent = response;
          this.updateForm();
          this.updateMultiSelects();
        },
        catchError => {
          this.router.navigateByUrl('categories');
          this.customToast.setError(catchError)
        }
      )
  }

  initializeVideoContentForm(): void {
    this.editVideoContentForm = this.fb.group({
      id: new FormControl(this.videoContentId, Validators.required),
      name: new FormControl(null, Validators.required),
      creatorName: new FormControl(null, Validators.required),
      duration: new FormControl(null, Validators.required),
      videoUrl: new FormControl(null, [Validators.pattern(
        /^(?:(?:(?:https?|ftp):)?\/\/)(?:\S+(?::\S*)?@)?(?:(?!(?:10|127)(?:\.\d{1,3}){3})(?!(?:169\.254|192\.168)(?:\.\d{1,3}){2})(?!172\.(?:1[6-9]|2\d|3[0-1])(?:\.\d{1,3}){2})(?:[1-9]\d?|1\d\d|2[01]\d|22[0-3])(?:\.(?:1?\d{1,2}|2[0-4]\d|25[0-5])){2}(?:\.(?:[1-9]\d?|1\d\d|2[0-4]\d|25[0-4]))|(?:(?:[a-z\u00a1-\uffff0-9]-*)*[a-z\u00a1-\uffff0-9]+)(?:\.(?:[a-z\u00a1-\uffff0-9]-*)*[a-z\u00a1-\uffff0-9]+)*(?:\.(?:[a-z\u00a1-\uffff]{2,})).?)(?::\d{2,5})?(?:[\/?#]\S*)?$/i
      ), Validators.required]),
      categories: this.fb.array([], Validators.required),
      playlists: this.fb.array([])
    });
    this.selectedPlaylist = this.fb.group({
    })
  }

  get categories(): FormArray {
    return this.editVideoContentForm.get('categories') as FormArray;
  }

  updateForm() {
    this.editVideoContentForm.get('name').setValue(this.editingVideoContent.name);
    this.editVideoContentForm.get('creatorName').setValue(this.editingVideoContent.creatorName);
    this.editVideoContentForm.get('videoUrl').setValue(this.editingVideoContent.videoUrl);
    this.editVideoContentForm.get('duration').setValue(this.toDate(this.editingVideoContent.duration));
  }

  updateMultiSelects() {
    this.editingVideoContent.categories.forEach(category => {
      var originalCategory = this.fb.group({
        id: category.id,
        name: category.name
      })
      this.playableContentForm.selectedCategory = originalCategory;
      this.categories.push(originalCategory);
      this.playableContentForm.originalCategories.push({ id: category.id, itemName: category.name });
      this.playableContentForm.getPlaylistByCategory(category.id);
    });

    this.editingVideoContent.playlists.forEach(playlist => {
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

  updateVideoContent() {
    this.playableContentForm.transformTime();
    this.playableContentForm.submited = true;
    if (!this.editVideoContentForm.invalid) {
      this.videoContentService.update(this.editVideoContentForm.value)
        .subscribe(
          response => {
            this.customToast.setSuccess("The video content was successfully updated");
            this.playableContentForm.resetForm();
          },
          catchError => {
            this.customToast.setError(catchError);
          }
        )
    }
    else {
      this.customToast.setError("Please verify the entered data.");
    }
  }

  get playlists(): FormArray {
    return this.editVideoContentForm.get('playlists') as FormArray;
  }

}
