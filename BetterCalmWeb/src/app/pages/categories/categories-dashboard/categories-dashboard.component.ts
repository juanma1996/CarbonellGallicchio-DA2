import { Component, OnInit } from '@angular/core';
import { CategoriesService } from '../../../services/categories/categories.service'
import { catchError } from 'rxjs/operators';
import { CategoryBasicInfo } from '../../../models/category/category-basic-info';
import { AudioContentService } from 'src/app/services/audio-content/audio-content.service';
import { AudioContentModel } from 'src/app/models/audioContent/audio-content-model';

@Component({
  selector: 'app-categories-dashboard',
  templateUrl: 'categories-dashboard.component.html',
})
export class CategoriesDashboardComponent implements OnInit {
  public categories: CategoryBasicInfo[] = [];
  public audioContents: AudioContentModel[] = [];
  public errorBackend: string = '';

  constructor(
    private categoriesService: CategoriesService,
    private audioContentService: AudioContentService
  ) { }

  ngOnInit(): void {
    this.categoriesService.get()
      .subscribe(
        response => {
          this.get(response)
        },
        catchError => {
          console.log(catchError);
          this.errorBackend = catchError + ', fix it please';
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
          console.log(catchError);
        }
      )
  }


  private get(response) {
    console.log(response);
    this.categories = response;
  }
}
