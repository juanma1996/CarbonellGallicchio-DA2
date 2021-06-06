import { Component, OnInit, Input } from '@angular/core';
import { SessionService } from 'src/app/services/session/session.service';
import { AudioContentService } from 'src/app/services/audio-content/audio-content.service';
import { ToastService } from 'src/app/common/toast.service';

@Component({
  selector: 'app-audio-content-table',
  templateUrl: './audio-content-table.component.html',
  styleUrls: ['./audio-content-table.component.scss']
})
export class AudioContentTableComponent implements OnInit {
  @Input() audios: [];
  public isAutenticated: boolean;

  constructor(
    private sessionService: SessionService,
    private audioContentService: AudioContentService,
    private customToastr: ToastService
  ) { }

  ngOnInit(): void {
    this.isAutenticated = this.sessionService.isAuthenticated();
  }

  delete(id) {
    this.audioContentService.delete(id)
      .subscribe(
        response => {
          this.customToastr.setSuccess("The audio content was successfully deleted");
        },
        catchError => {
          this.customToastr.setError(catchError);
        }
      )
  }
}
