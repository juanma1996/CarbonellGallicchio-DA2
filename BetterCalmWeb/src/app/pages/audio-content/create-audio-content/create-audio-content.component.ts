import { Component, OnInit, ViewChild } from '@angular/core';
import { CategoriesService } from 'src/app/services/categories/categories.service';
import { ToastrService } from 'ngx-toastr';
import { AudioContentService } from 'src/app/services/audio-content/audio-content.service';
import { catchError } from 'rxjs/operators';
import { FormGroup, FormBuilder, FormControl, Validators, Form, FormArray } from '@angular/forms';
import { PlayableContentFormComponent } from '../playable-content-form/playable-content-form.component';

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
    public toastr: ToastrService,
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
      //duration: new FormControl(null),
      imageUrl: new FormControl(null),
      audioUrl: new FormControl(null, Validators.required),
      categories: this.fb.array([], Validators.required),
      playlists: this.fb.array([], Validators.required)
    });
    this.selectedPlaylist = this.fb.group({
    })
  }

  createAudioContent() {
    this.addNewPlaylist();
    this.playableContentForm.submited = true;
    if (!this.createAudioContentForm.invalid) {
      this.audioContentService.add(this.createAudioContentForm.value)
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
    return this.createAudioContentForm.get('playlists') as FormArray;
  }

  addNewPlaylist() {
    if (this.playableContentForm.newPlaylist) {
      this.playlists.push(this.playableContentForm.selectedPlaylist);
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
