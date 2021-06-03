import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-edit-administrator-dashboard',
  templateUrl: './edit-administrator-dashboard.component.html',
  styleUrls: ['./edit-administrator-dashboard.component.scss']
})
export class EditAdministratorDashboardComponent implements OnInit {
  entries: number = 10;
  selected: any[] = [];
  administrators = [];
  public isAutenticated: boolean;

  rows: any = [
    {
      name: 'SuperAdmin',
      email: 'admin@gmail.com',
      password: '1234'
    },
    {
      name: 'Fede',
      email: 'fede@hotmail.com',
      password: 'Fede1'
    },
    {
      name: 'Juan',
      email: 'Juan@Juan.com',
      password: 'Juan1'
    },
    {
      name: 'fede',
      email: 'Fede@fede.com',
      password: 'Fede'
    },
  ]

  constructor(
    public toastr: ToastrService,
  ) {
    this.administrators = this.rows.map((prop, key) => {
      return {
        name: prop.name,
        email: prop.email,
        password: prop.password,
        id: prop.id
      };
    });
  }

  entriesChange($event) {
    this.entries = $event.target.value;
  }

  filterTable($event) {
    let val = $event.target.value;
    this.administrators = this.rows.filter(function (d) {
      for (var key in d) {
        if (d[key].toLowerCase().indexOf(val) !== -1) {
          return true;
        }
      }
      return false;
    });
  }

  consoleButton(value) {
    console.log(value)
  }

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
