import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { SessionService } from '../services/session/session.service';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate {
  constructor (private session: SessionService,
              private router: Router, public toastr: ToastrService) {}

  canActivate(): boolean {
    if (this.session.isAuthenticated() ){
      return true;
    } else {
      //this.router.navigateByUrl('login');
      this.notificateAdminPrivileges();
      return false;
    }
  }

  private notificateAdminPrivileges(){
    this.toastr.show(
      '<span data-notify="icon" class="tim-icons icon-bell-55"></span>',
      "Administrator privileges needed.",
      {
        timeOut: 5000,
        closeButton: true,
        enableHtml: true,
        toastClass: "alert alert-danger alert-with-icon",
        positionClass: "toast-top-right"
      }
    );
  }

}

