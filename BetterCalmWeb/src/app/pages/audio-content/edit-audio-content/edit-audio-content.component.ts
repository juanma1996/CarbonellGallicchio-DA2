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
    this.playableContentForm.selectedCategory = originalCategory;
    //Aca ponerle la categoria del objeto real.
    this.playableContentForm.getPlaylistByCategory(categories[0].id);

    // Esto tenemos que cargarlo con lo que venga del objeto real.
    var originalPlaylist = this.fb.group({
      id: playlists[0].id,
      name: playlists[0].name,
      description: playlists[0].description
    })
    this.playlists.push(originalPlaylist);
    //Creo que esta mal.
    // this.playableContentForm.originalCategory = [{ id: this.editingAudioContent.categories[0].id, itemName: this.editingAudioContent.categories[0].name }]
    // if (this.editingAudioContent.playlists.length > 0) {
    //   this.playableContentForm.originalPlaylist = [{ id: this.editingAudioContent.playlists[0].id, itemName: this.editingAudioContent.playlists[0].name }]
    // }
    this.playableContentForm.originalCategory = [{ id: categories[0].id, itemName: categories[0].name }]
    if (playlists.length > 0) {
      this.playableContentForm.originalPlaylist = [{ id: playlists[0].id, itemName: playlists[0].name }]
    }
  }

  updateAudioContent() {
    this.addNewPlaylist();
    this.playableContentForm.submited = true;
    if (!this.editAudioContentForm.invalid) {
      this.audioContentService.update(this.editAudioContentForm.value)
        .subscribe(
          response => {
            this.customToastr.setSuccess("The audio content was successfully updated");
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

  addNewPlaylist() {
    if (this.playableContentForm.newPlaylist) {
      this.playlists.push(this.playableContentForm.selectedPlaylist);
    }
  }
}
