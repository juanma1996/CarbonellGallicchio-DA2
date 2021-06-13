import { Component, OnInit } from '@angular/core';
import { CategoriesService } from '../../../services/categories/categories.service'
import { catchError } from 'rxjs/operators';
import { CategoryBasicInfo } from '../../../models/category/category-basic-info';
import { AudioContentService } from 'src/app/services/audio-content/audio-content.service';
import { AudioContentModel } from 'src/app/models/audioContent/audio-content-model';
import { ToastService } from 'src/app/common/toast.service';

@Component({
  selector: 'app-audio-content-categories-dashboard',
  templateUrl: 'audio-content-categories-dashboard.component.html',
})
export class AudioContentCategoriesDashboardComponent implements OnInit {
  public categories: CategoryBasicInfo[] = [];
  public audioContents: AudioContentModel[] = [];

  constructor(
    private categoriesService: CategoriesService,
    private audioContentService: AudioContentService,
    private customToastr: ToastService
  ) { }

  ngOnInit(): void {
    this.categoriesService.get()
      .subscribe(
        response => {
          this.categories = response;
        },
        catchError => {
          this.customToastr.setError(catchError);
        }
      )
    this.getAudioContents();
  }

  getAudioContents() {
    this.audioContentService.get()
      .subscribe(
        response => {
          this.audioContents = response;
        },
        catchError => {
          this.customToastr.setError(catchError);
        }
      )
  }

  updateAudios() {
    this.getAudioContents();
  }
}
