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
      audioUrl: new FormControl(null, Validators.required),
      categories: this.fb.array([], Validators.required),
      playlists: this.fb.array([])
    });
    this.selectedPlaylist = this.fb.group({
    })
  }

  createAudioContent() {
    this.addNewPlaylist();
    this.playableContentForm.transformTime();
    this.playableContentForm.submited = true;
    if (!this.createAudioContentForm.invalid) {
      this.audioContentService.add(this.createAudioContentForm.value)
        .subscribe(
          response => {
            this.customToastr.setSuccess("The audio content was successfully created");
            this.playableContentForm.resetForm();
            this.playableContentForm.submited = false;
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

  addNewPlaylist() {
    if (this.playableContentForm.newPlaylist) {
      this.playlists.push(this.playableContentForm.selectedPlaylist);
    }
  }

}
