import { Component, OnInit, ViewChild } from '@angular/core';
import { AdministratorModel } from 'src/app/models/administrator/administrator-basic-info';
import { AdministratorService } from 'src/app/services/administrator/administrator.service';
import { ToastrService } from 'ngx-toastr';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { AdministratorFormComponent } from '../administrator-form/administrator-form.component';

@Component({
  selector: 'app-create-administrator',
  templateUrl: './create-administrator.component.html',
  styleUrls: ['./create-administrator.component.scss']
})
export class CreateAdministratorComponent implements OnInit {
  @ViewChild(AdministratorFormComponent, { static: true }) public administratorForm: AdministratorFormComponent;
  createAdministratorForm: FormGroup;
  create: boolean = false;

  constructor(
    private administratorService: AdministratorService,
    public toastr: ToastrService,
    private fb: FormBuilder
  ) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm(): void {
    this.createAdministratorForm = this.fb.group({
      name: new FormControl(null, Validators.required),
      email: new FormControl(null, [Validators.required, Validators.email]),
      password: new FormControl(null, Validators.required),
    })
  }

  onSubmit(): void {
    console.log(this.administratorForm);
  }

  registerAdministrator = function () {
    this.administratorForm.submited = true;
    if (!this.createAdministratorForm.invalid) {
      this.administratorService.add(this.createAdministratorForm.value)
        .subscribe(
          response => {
            this.setSuccess()
          },
          catchError => {
            this.setError(catchError);
          }
        )
    }
    else {
      this.setError("Please verify the entered data.")
    }
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
