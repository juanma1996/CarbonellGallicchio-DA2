import { Component, OnInit, OnDestroy } from "@angular/core";
import { SessionUserModel } from 'src/app/models/session/session-user-model';
import { SessionService } from 'src/app/services/session/session.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: "app-login",
  templateUrl: "login.component.html"
})
export class LoginComponent implements OnInit, OnDestroy {
  focus;
  focus1;
  public administrator: SessionUserModel = new SessionUserModel();

  constructor(
    private sessionService: SessionService,
    public toastr: ToastrService,
    private router: Router,
  ) { }

  ngOnInit() {
    var body = document.getElementsByTagName("body")[0];
    body.classList.add("login-page");
  }
  ngOnDestroy() {
    var body = document.getElementsByTagName("body")[0];
    body.classList.remove("login-page");
  }

  login = function () {
    this.sessionService.login(this.administrator).
      subscribe(
        response => {
          this.setSuccess()
          localStorage.setItem('email', this.administrator.email);
          this.router.navigateByUrl('categories/audioContents');
        },
        catchError => {
          this.setError(catchError.error);
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
      "The log in was successful",
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
