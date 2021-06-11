import { Component, OnInit, ViewChild } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AudioContentService } from 'src/app/services/audio-content/audio-content.service';
import { catchError } from 'rxjs/operators';
import { FormGroup, FormBuilder, FormControl, Validators, Form, FormArray } from '@angular/forms';
import { PlayableContentFormComponent } from '../playable-content-form/playable-content-form.component';
import { ToastService } from 'src/app/common/toast.service';

@Component({
  selector: 'app-create-audio-content',
  templateUrl: './create-audio-content.component.html',
  styleUrls: ['./create-audio-content.component.scss']
})
export class CreateAudioContentComponent implements OnInit {
  @ViewChild(PlayableContentFormComponent, { static: true }) public playableContentForm: PlayableContentFormComponent;
  createAudioContentForm: FormGroup;

  selectedPlaylist: FormGroup;
  create: boolean = false;


  public newPlaylist: boolean = false;

  constructor(
    private audioContentService: AudioContentService,
    public customToastr: ToastService,
    private fb: FormBuilder
  ) { }

  ngOnInit(): void {
    this.initializeAudioContentForm();
  }

  initializeAudioContentForm(): void {
    this.playableContentForm.submited = false;
    this.createAudioContentForm = this.fb.group({
      name: new FormControl(null, Validators.required),
      creatorName: new FormControl(null, Validators.required),
      duration: new FormControl(null),
      imageUrl: new FormControl(null),
      audioUrl: new FormControl(null, Validators.pattern(
        /^(?:(?:(?:https?|ftp):)?\/\/)(?:\S+(?::\S*)?@)?(?:(?!(?:10|127)(?:\.\d{1,3}){3})(?!(?:169\.254|192\.168)(?:\.\d{1,3}){2})(?!172\.(?:1[6-9]|2\d|3[0-1])(?:\.\d{1,3}){2})(?:[1-9]\d?|1\d\d|2[01]\d|22[0-3])(?:\.(?:1?\d{1,2}|2[0-4]\d|25[0-5])){2}(?:\.(?:[1-9]\d?|1\d\d|2[0-4]\d|25[0-4]))|(?:(?:[a-z\u00a1-\uffff0-9]-*)*[a-z\u00a1-\uffff0-9]+)(?:\.(?:[a-z\u00a1-\uffff0-9]-*)*[a-z\u00a1-\uffff0-9]+)*(?:\.(?:[a-z\u00a1-\uffff]{2,})).?)(?::\d{2,5})?(?:[\/?#]\S*)?$/i
      )),
      categories: this.fb.array([], Validators.required),
      playlists: this.fb.array([])
    });
    this.selectedPlaylist = this.fb.group({
    })
  }

  createAudioContent() {
    this.playableContentForm.transformTime();
    this.playableContentForm.submited = true;
    if (!this.createAudioContentForm.invalid) {
      this.audioContentService.add(this.createAudioContentForm.value)
        .subscribe(
          response => {
            this.customToastr.setSuccess("The audio content was successfully created");
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
    return this.createAudioContentForm.get('playlists') as FormArray;
  }

}
