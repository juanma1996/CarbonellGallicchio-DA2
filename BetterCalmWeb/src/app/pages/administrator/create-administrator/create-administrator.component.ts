import { Component, OnInit } from '@angular/core';
import { AdministratorModel } from 'src/app/models/administrator/administrator-basic-info';
import { AdministratorService } from 'src/app/services/administrator/administrator.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-create-administrator',
  templateUrl: './create-administrator.component.html',
  styleUrls: ['./create-administrator.component.scss']
})
export class CreateAdministratorComponent implements OnInit {
  
  public administrator: AdministratorModel = new AdministratorModel();

  constructor(
    private administratorService: AdministratorService,
    public toastr: ToastrService
    ) { }

  ngOnInit(): void {
  }

  registerAdministrator = function() {
    this.administratorService.add(this.administrator)
    .subscribe(
      response => {
        this.setSuccess()
      },
      catchError => {
        this.setError(catchError.error);
      }
      )
    }

    private setError(message){
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

    private setSuccess(){
      this.toastr.show(
        '<span data-notify="icon" class="tim-icons icon-bell-55"></span>',
        "The administrator registration was successful",
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
