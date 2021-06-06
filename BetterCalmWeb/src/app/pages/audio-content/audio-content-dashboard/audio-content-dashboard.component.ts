import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AudioContentService } from 'src/app/services/audio-content/audio-content.service';
import { ToastrService } from 'ngx-toastr';
import { catchError } from 'rxjs/operators';
import { SessionService } from 'src/app/services/session/session.service';
import { AudioContentModel } from 'src/app/models/audioContent/audio-content-model';
import { ToastService } from 'src/app/common/toast.service';

@Component({
  selector: 'app-audio-content-dashboard',
  templateUrl: './audio-content-dashboard.component.html',
  styleUrls: ['./audio-content-dashboard.component.scss']
})
export class AudioContentDashboardComponent implements OnInit {

  public categoryId;
  public playlistId;
  public audioContents: AudioContentModel[] = []

  constructor(
    public route: ActivatedRoute,
    private audioContentService: AudioContentService,
    private sessionService: SessionService,
    private customToastr: ToastService
  ) { }

  ngOnInit(): void {
    this.categoryId = this.route.snapshot.paramMap.get('categoryId');
    this.playlistId = Number(this.route.snapshot.paramMap.get('playlistId'));
    this.getAudioContents(this.playlistId);
  }

  getAudioContents(playlistId: number) {
    this.audioContentService.getAudioContentByPlaylist(playlistId)
      .subscribe(
        response => {
          this.audioContents = response;
        },
        catchError => {
          this.customToastr.setError(catchError);
        }
      )
  }

  delete(id) {
    this.audioContentService.delete(id)
      .subscribe(
        response => {
          this.customToastr.setSuccess("The audio content was successfully deleted");
          this.getAudioContents(this.playlistId);
        },
        catchError => {
          this.customToastr.setError(catchError);
        }
      )
  }
}
