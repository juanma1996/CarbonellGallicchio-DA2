import { Component, OnInit } from '@angular/core';
import { CategoryBasicInfo } from 'src/app/models/category/category-basic-info';
import { VideoContentBasicInfo } from 'src/app/models/videoContent/video-content-basic-info';
import { CategoriesService } from 'src/app/services/categories/categories.service';
import { ToastService } from 'src/app/common/toast.service';
import { VideoContentService } from 'src/app/services/video-content/video-content-service';

@Component({
  selector: 'app-video-content-categories-dashboard',
  templateUrl: './video-content-categories-dashboard.component.html',
  styleUrls: ['./video-content-categories-dashboard.component.scss']
})
export class VideoContentCategoriesDashboardComponent implements OnInit {
  public categories: CategoryBasicInfo[] = [];
  public videoContents: VideoContentBasicInfo[] = [];

  constructor(
    private categoriesService: CategoriesService,
    private videoContentService: VideoContentService,
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
    this.getVideoContents();
  }

  getVideoContents() {
    this.videoContentService.get()
      .subscribe(
        response => {
          this.videoContents = response;
        },
        catchError => {
          this.customToastr.setError(catchError);
        }
      )
  }

}
