import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-edit-administrator-dashboard',
  templateUrl: './edit-administrator-dashboard.component.html',
  styleUrls: ['./edit-administrator-dashboard.component.scss']
})
export class EditAdministratorDashboardComponent implements OnInit {

  public administrators = [
    {
      Id: 1,
      Name: 'SuperAdmin',
      Email: 'admin@gmail.com',
      Password: '1234'
    },
    {
      Id: 3,
      Name: 'Fede',
      Email: 'fede@hotmail.com',
      Password: 'Fede1'
    },
    {
      Id: 4,
      Name: 'Juan',
      Email: 'Juan@Juan.com',
      Password: 'Juan1'
    },
    {
      Id: 5,
      Name: 'fede',
      Email: 'Fede@fede.com',
      Password: 'Fede'
    },

  ]

  constructor(
    public toastr: ToastrService
  ) { }

  ngOnInit(): void {
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
