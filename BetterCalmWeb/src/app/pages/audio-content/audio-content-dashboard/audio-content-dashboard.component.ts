import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AudioContentService } from 'src/app/services/audio-content/audio-content.service';
import { ToastrService } from 'ngx-toastr';
import { catchError } from 'rxjs/operators';
import { SessionService } from 'src/app/services/session/session.service';
import { AudioContentModel } from 'src/app/models/audioContent/audio-content-model';

@Component({
  selector: 'app-audio-content-dashboard',
  templateUrl: './audio-content-dashboard.component.html',
  styleUrls: ['./audio-content-dashboard.component.scss']
})
export class AudioContentDashboardComponent implements OnInit {

  public categoryId;
  public playlistId;
  public isAutenticated: boolean;
  public audioContents: AudioContentModel[] = []

  constructor(
    public route: ActivatedRoute,
    private audioContentService: AudioContentService,
    private sessionService: SessionService,
    public toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.categoryId = this.route.snapshot.paramMap.get('categoryId');
    this.playlistId = Number(this.route.snapshot.paramMap.get('playlistId'));
    this.isAutenticated = this.sessionService.isAuthenticated();
    this.getAudioContents(this.playlistId);
  }

  getAudioContents(playlistId: number) {
    this.audioContentService.getAudioContentByPlaylist(playlistId)
      .subscribe(
        response => {
          this.audioContents = response;
        },
        catchError => {
          console.log(catchError)
        }
      )
  }

  delete(id) {
    this.audioContentService.delete(id)
      .subscribe(
        response => {
          this.setSuccess();
          this.getAudioContents(this.playlistId);
        },
        catchError => {
          this.setError(catchError);
        }
      )
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
      "The audio content was successfully deleted",
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
