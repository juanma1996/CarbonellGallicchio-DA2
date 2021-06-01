import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AudioContentService } from 'src/app/services/audio-content/audio-content.service';
import { ToastrService } from 'ngx-toastr';
import { catchError } from 'rxjs/operators';
import { SessionService } from 'src/app/services/session/session.service';

@Component({
  selector: 'app-audio-content-dashboard',
  templateUrl: './audio-content-dashboard.component.html',
  styleUrls: ['./audio-content-dashboard.component.scss']
})
export class AudioContentDashboardComponent implements OnInit {

  public categoryId;
  public isAutenticated: boolean;
  public audioContent = [
    {
      Id: 1,
      Name: 'Colgando en tus manos',
      Creator: 'Carlos Baute',
      Duration: '3:43'
    },
    {
      Id: 2,
      Name: 'Malbec',
      Creator: 'Duki',
      Duration: '3:43'
    },
    {
      Id: 3,
      Name: 'Cual es tu plan?',
      Creator: 'Bad Bunny',
      Duration: '3:43'
    },
    {
      Id: 4,
      Name: 'Dum Dum',
      Creator: 'Patrice Baumel',
      Duration: '3:43'
    },

  ]

  constructor(
    public route: ActivatedRoute,
    private audioContentService: AudioContentService,
    private sessionService: SessionService,
    public toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.categoryId = this.route.snapshot.paramMap.get('categoryId');
    this.isAutenticated = this.sessionService.isAuthenticated();
  }

  delete(id) {
    this.audioContentService.delete(id)
      .subscribe(
        response => {
          this.setSuccess();
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
