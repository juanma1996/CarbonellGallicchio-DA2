import { Component, OnInit, OnDestroy } from "@angular/core";
import { SessionUserModel } from 'src/app/models/session/session-user-model';
import { SessionService } from 'src/app/services/session/session.service';
import { Router } from '@angular/router';
import { ToastService } from 'src/app/common/toast.service';

@Component({
  selector: "app-login",
  templateUrl: "login.component.html"
})
export class LoginComponent implements OnInit {
  focus;
  focus1;
  public administrator: SessionUserModel = new SessionUserModel();

  constructor(
    private sessionService: SessionService,
    public customToastr: ToastService,
    private router: Router,
  ) { }

  ngOnInit() {
    var body = document.getElementsByTagName("body")[0];
    body.classList.add("login-page");
  }

  login = function () {
    this.sessionService.login(this.administrator).
      subscribe(
        response => {
          this.customToastr.setSuccess("The log in was successful")
          localStorage.setItem('email', this.administrator.email);
          this.router.navigateByUrl('categories/audioContents');
        },
        catchError => {
          this.customToastr.setError(catchError.error);
        }
      )
  }
}
