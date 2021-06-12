import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { VideoContentBasicInfo } from 'src/app/models/videoContent/video-content-basic-info';
import { DomSanitizer, SafeResourceUrl, } from '@angular/platform-browser';
import { VideoContentService } from 'src/app/services/video-content/video-content-service';
import { ToastService } from 'src/app/common/toast.service';
import { SessionService } from 'src/app/services/session/session.service';
import { AlertService } from 'src/app/common/alert.service';

@Component({
  selector: 'app-video-content-list',
  templateUrl: './video-content-list.component.html',
  styleUrls: ['./video-content-list.component.scss']
})
export class VideoContentListComponent implements OnInit {
  @Input() videos: VideoContentBasicInfo[];
  @Output() updateVideos = new EventEmitter();
  public isAutenticated: boolean;

  constructor(
    private videoContentService: VideoContentService,
    private sessionService: SessionService,
    public customToastr: ToastService,
    private alert: AlertService
  ) { }

  ngOnInit(): void {
    this.isAutenticated = this.sessionService.isAuthenticated();
  }

  deleteModal(id) {
    this.alert.showAlert("Are you sure you want to delete the video content?", "I'm sure", this.delete.bind(this, id));
  }

  delete(id) {
    this.videoContentService.delete(id)
      .subscribe(
        response => {
          this.customToastr.setSuccess("The video content was successfully deleted");
          this.updateVideos.emit();
        },
        catchError => {
          this.customToastr.setError(catchError);
        }
      )
  }

}
