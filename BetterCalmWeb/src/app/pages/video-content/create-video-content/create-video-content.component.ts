import { Component, OnInit, ViewChild } from '@angular/core';
import { PlayableContentFormComponent } from '../../audio-content/playable-content-form/playable-content-form.component';
import { ToastrService } from 'ngx-toastr';
import { FormBuilder, FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { VideoContentService } from 'src/app/services/video-content/video-content-service';
import { ToastService } from 'src/app/common/toast.service';

@Component({
  selector: 'app-create-video-content',
  templateUrl: './create-video-content.component.html',
  styleUrls: ['./create-video-content.component.scss']
})
export class CreateVideoContentComponent implements OnInit {
  @ViewChild(PlayableContentFormComponent, { static: true }) public playableContentForm: PlayableContentFormComponent;
  urlRegex = /^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$/;
  createVideoContentForm: FormGroup;

  selectedPlaylist: FormGroup;
  create: boolean = false;


  public newPlaylist: boolean = false;

  constructor(
    private videoContentService: VideoContentService,
    public customToastr: ToastService,
    private fb: FormBuilder
  ) { }

  ngOnInit(): void {
    this.initializeVideoContentForm();
  }

  initializeVideoContentForm(): void {
    this.playableContentForm.submited = false;
    this.createVideoContentForm = this.fb.group({
      name: new FormControl(null, Validators.required),
      creatorName: new FormControl(null, Validators.required),
      //duration: new FormControl(null),
      videoUrl: new FormControl(null, [Validators.required, Validators.pattern(this.urlRegex)]),
      categories: this.fb.array([], Validators.required),
      playlists: this.fb.array([], Validators.required)
    });
    this.selectedPlaylist = this.fb.group({
    })
  }

  createVideoContent() {
    this.addNewPlaylist();
    this.playableContentForm.submited = true;
    if (!this.createVideoContentForm.invalid) {

      this.videoContentService.add(this.createVideoContentForm.value)
        .subscribe(
          response => {
            this.customToastr.setSuccess("The video content was created sucessfully");
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
    return this.createVideoContentForm.get('playlists') as FormArray;
  }

  addNewPlaylist() {
    if (this.playableContentForm.newPlaylist) {
      this.playlists.push(this.playableContentForm.selectedPlaylist);
    }
  }

}
