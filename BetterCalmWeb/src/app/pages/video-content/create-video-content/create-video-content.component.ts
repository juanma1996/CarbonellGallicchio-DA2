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
      videoUrl: new FormControl(null, [Validators.required, Validators.pattern(
        /^(?:(?:(?:https?|ftp):)?\/\/)(?:\S+(?::\S*)?@)?(?:(?!(?:10|127)(?:\.\d{1,3}){3})(?!(?:169\.254|192\.168)(?:\.\d{1,3}){2})(?!172\.(?:1[6-9]|2\d|3[0-1])(?:\.\d{1,3}){2})(?:[1-9]\d?|1\d\d|2[01]\d|22[0-3])(?:\.(?:1?\d{1,2}|2[0-4]\d|25[0-5])){2}(?:\.(?:[1-9]\d?|1\d\d|2[0-4]\d|25[0-4]))|(?:(?:[a-z\u00a1-\uffff0-9]-*)*[a-z\u00a1-\uffff0-9]+)(?:\.(?:[a-z\u00a1-\uffff0-9]-*)*[a-z\u00a1-\uffff0-9]+)*(?:\.(?:[a-z\u00a1-\uffff]{2,})).?)(?::\d{2,5})?(?:[\/?#]\S*)?$/i
      )]),
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
