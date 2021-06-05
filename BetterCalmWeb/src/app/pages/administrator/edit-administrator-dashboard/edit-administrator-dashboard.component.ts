import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AdministratorService } from 'src/app/services/administrator/administrator.service';
import { ToastService } from 'src/app/common/toast.service';
import { catchError } from 'rxjs/operators';

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

  constructor(
    private administratorService: AdministratorService,
    public customToast: ToastService,
  ) {
    this.getAdministrators();
  }

  getAdministrators() {
    this.administratorService.get()
      .subscribe(
        response => {
          console.log(response);
          this.administrators = response;
        },
        catchError => {
          this.customToast.setError(catchError);
        }
      )
  }

  entriesChange($event) {
    this.entries = $event.target.value;
  }

  filterTable($event) {
    let val = $event.target.value;
    this.administrators = this.administrators.filter(function (d) {
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
          this.getAdministrators();
        },
        catchError => {
          this.customToast.setError(catchError);
        }
      )
  }

}
