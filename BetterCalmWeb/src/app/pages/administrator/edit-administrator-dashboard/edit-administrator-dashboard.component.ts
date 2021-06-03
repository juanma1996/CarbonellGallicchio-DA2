import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AdministratorService } from 'src/app/services/administrator/administrator.service';
import { ToastService } from 'src/app/common/toast.service';

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
      id: 1,
      name: 'SuperAdmin',
      email: 'admin@gmail.com',
      password: '1234'
    },
    {
      id: 3,
      name: 'Fede',
      email: 'fede@hotmail.com',
      password: 'Fede1'
    },
    {
      id: 4,
      name: 'Juan',
      email: 'Juan@Juan.com',
      password: 'Juan1'
    },
    {
      id: 5,
      name: 'fede',
      email: 'Fede@fede.com',
      password: 'Fede'
    },
  ]

  constructor(
    private administratorService: AdministratorService,
    public customToast: ToastService,
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

  delete(id) {
    this.administratorService.delete(id)
      .subscribe(
        response => {
          this.customToast.setSuccess("The administrator was successfully deleted");
        },
        catchError => {
          this.customToast.setError(catchError);
        }
      )
  }

}
