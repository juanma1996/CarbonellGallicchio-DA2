import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators, FormArray } from '@angular/forms';
import { AudioContentModel } from 'src/app/models/audioContent/audio-content-model';
import { AudioFormComponent } from '../../audio-content/audio-form/audio-form.component';
import { VideoContentService } from 'src/app/services/video-content/video-content-service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';
import { VideoContentBasicInfo } from 'src/app/models/videoContent/video-content-basic-info';
import { ToastService } from 'src/app/common/toast.service';

@Component({
  selector: 'app-edit-video-content',
  templateUrl: './edit-video-content.component.html',
  styleUrls: ['./edit-video-content.component.scss']
})
export class EditVideoContentComponent implements OnInit {
  @ViewChild(AudioFormComponent, { static: true }) public audioForm: AudioFormComponent;
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
          console.log(response);
          this.editingVideoContent = response;
          this.updateForm();
          this.updateMultiSelects();
        },
        catchError => {
          console.log(catchError);
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
      //duration: new FormControl(null),
      videoUrl: new FormControl(null, Validators.required),
      categories: this.fb.array([], Validators.required),
      playlists: this.fb.array([], Validators.required)
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

  }

  updateMultiSelects() {
    // Dummy esperando el servicio.
    var categories = [{ id: 1, name: 'Dormir' }];
    var playlists = [{ id: 4, name: "New playlist", description: "This is a new playlist valid" }];

    // Esto tenemos que cargarlo con lo que venga del objeto real.
    var originalCategory = this.fb.group({
      id: categories[0].id,
      name: categories[0].name
    })
    this.categories.push(originalCategory);
    // Esto hay que setearlo igual para que ya aparezca el combo de playlists.
    this.audioForm.selectedCategory = originalCategory;
    //Aca ponerle la categoria del objeto real.
    this.audioForm.getPlaylistByCategory(categories[0].id);

    // Esto tenemos que cargarlo con lo que venga del objeto real.
    var originalPlaylist = this.fb.group({
      id: playlists[0].id,
      name: playlists[0].name,
      description: playlists[0].description
    })
    this.playlists.push(originalPlaylist);
    //Creo que esta mal.
    // this.audioForm.originalCategory = [{ id: this.editingAudioContent.categories[0].id, itemName: this.editingAudioContent.categories[0].name }]
    // if (this.editingAudioContent.playlists.length > 0) {
    //   this.audioForm.originalPlaylist = [{ id: this.editingAudioContent.playlists[0].id, itemName: this.editingAudioContent.playlists[0].name }]
    // }
    this.audioForm.originalCategory = [{ id: categories[0].id, itemName: categories[0].name }]
    if (playlists.length > 0) {
      this.audioForm.originalPlaylist = [{ id: playlists[0].id, itemName: playlists[0].name }]
    }
  }

  updateVideoContent() {
    this.addNewPlaylist();
    this.audioForm.submited = true;
    if (!this.editVideoContentForm.invalid) {
      this.videoContentService.update(this.editVideoContentForm.value)
        .subscribe(
          response => {
            this.customToast.setSuccess("The video content was successfully updated");
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
    if (this.audioForm.newPlaylist) {
      this.playlists.push(this.audioForm.selectedPlaylist);
    }
  }

}
