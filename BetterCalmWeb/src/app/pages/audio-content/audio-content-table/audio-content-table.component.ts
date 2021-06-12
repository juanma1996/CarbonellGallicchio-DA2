import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { SessionService } from 'src/app/services/session/session.service';
import { AudioContentService } from 'src/app/services/audio-content/audio-content.service';
import { ToastService } from 'src/app/common/toast.service';
import { AlertService } from 'src/app/common/alert.service';

@Component({
  selector: 'app-audio-content-table',
  templateUrl: './audio-content-table.component.html',
  styleUrls: ['./audio-content-table.component.scss']
})
export class AudioContentTableComponent implements OnInit {
  @Input() audios;
  filteredAudios;
  @Output() updateAudios = new EventEmitter();
  entries: number = 10;
  public isAutenticated: boolean;

  constructor(
    private sessionService: SessionService,
    private audioContentService: AudioContentService,
    private customToastr: ToastService,
    private alert: AlertService
  ) { }

  ngOnInit(): void {
    this.isAutenticated = this.sessionService.isAuthenticated();
    this.filteredAudios = this.audios;
  }

  deleteModal(id) {
    this.alert.showAlert("Are you sure you want to delete the audio content?", "I'm sure", this.delete.bind(this, id));
  }

  delete(id) {
    console.log("id " + id);
    this.audioContentService.delete(id)
      .subscribe(
        response => {
          this.customToastr.setSuccess("The audio content was successfully deleted");
          this.updateAudios.emit();
        },
        catchError => {
          this.customToastr.setError(catchError);
        }
      )
  }

  entriesChange($event) {
    this.entries = $event.target.value;
  }

  filterTable($event) {
    let val = $event.target.value;
    this.filteredAudios = this.audios.filter(audio => {
      return audio.name.includes(val);
    });
  }

}
