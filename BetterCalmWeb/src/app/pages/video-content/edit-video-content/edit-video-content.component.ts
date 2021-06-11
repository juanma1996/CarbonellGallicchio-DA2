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
      duration: new FormControl(null),
      videoUrl: new FormControl(null, Validators.pattern(
        /^(?:(?:(?:https?|ftp):)?\/\/)(?:\S+(?::\S*)?@)?(?:(?!(?:10|127)(?:\.\d{1,3}){3})(?!(?:169\.254|192\.168)(?:\.\d{1,3}){2})(?!172\.(?:1[6-9]|2\d|3[0-1])(?:\.\d{1,3}){2})(?:[1-9]\d?|1\d\d|2[01]\d|22[0-3])(?:\.(?:1?\d{1,2}|2[0-4]\d|25[0-5])){2}(?:\.(?:[1-9]\d?|1\d\d|2[0-4]\d|25[0-4]))|(?:(?:[a-z\u00a1-\uffff0-9]-*)*[a-z\u00a1-\uffff0-9]+)(?:\.(?:[a-z\u00a1-\uffff0-9]-*)*[a-z\u00a1-\uffff0-9]+)*(?:\.(?:[a-z\u00a1-\uffff]{2,})).?)(?::\d{2,5})?(?:[\/?#]\S*)?$/i
      )),
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
    this.editVideoContentForm.get('duration').setValue(new Date(0, 0, 0, this.editingVideoContent.duration.hours, this.editingVideoContent.duration.minutes, 0, 0));
  }

  updateMultiSelects() {
    var originalCategory = this.fb.group({
      id: this.editingVideoContent.categories[0].id,
      name: this.editingVideoContent.categories[0].name
    })
    this.categories.push(originalCategory);
    this.playableContentForm.selectedCategory = originalCategory;
    this.playableContentForm.getPlaylistByCategory(this.editingVideoContent.categories[0].id);

    var originalPlaylist = this.fb.group({
      id: this.editingVideoContent.playlists[0].id,
      name: this.editingVideoContent.playlists[0].name,
      description: this.editingVideoContent.playlists[0].description
    })
    this.playlists.push(originalPlaylist);
    this.playableContentForm.originalCategory = [{ id: this.editingVideoContent.categories[0].id, itemName: this.editingVideoContent.categories[0].name }]
    if (this.editingVideoContent.playlists.length > 0) {
      this.playableContentForm.originalPlaylist = [{ id: this.editingVideoContent.playlists[0].id, itemName: this.editingVideoContent.playlists[0].name }]
    }
  }

  updateVideoContent() {
    this.addNewPlaylist();
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

  addNewPlaylist() {
    if (this.playableContentForm.newPlaylist) {
      this.playlists.push(this.playableContentForm.selectedPlaylist);
    }
  }

}
