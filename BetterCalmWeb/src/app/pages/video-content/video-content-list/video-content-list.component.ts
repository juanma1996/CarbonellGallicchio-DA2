import { Component, OnInit, Input } from '@angular/core';
import { VideoContentBasicInfo } from 'src/app/models/videoContent/video-content-basic-info';
import { DomSanitizer, SafeResourceUrl, } from '@angular/platform-browser';
import { VideoContentService } from 'src/app/services/video-content/video-content-service';
import { ToastService } from 'src/app/common/toast.service';
import { SessionService } from 'src/app/services/session/session.service';

@Component({
  selector: 'app-video-content-list',
  templateUrl: './video-content-list.component.html',
  styleUrls: ['./video-content-list.component.scss']
})
export class VideoContentListComponent implements OnInit {
  @Input() videos: VideoContentBasicInfo[];
  public isAutenticated: boolean;

  constructor(
    private videoContentService: VideoContentService,
    private sessionService: SessionService,
    public customToastr: ToastService,
  ) { }

  ngOnInit(): void {
    this.isAutenticated = this.sessionService.isAuthenticated();
  }

  delete(id) {
    this.videoContentService.delete(id)
      .subscribe(
        response => {
          this.customToastr.setSuccess("The video content was successfully deleted");
        },
        catchError => {
          this.customToastr.setError(catchError);
        }
      )
  }

}
