import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { ToastService } from 'src/app/common/toast.service';
import { AdministratorService } from 'src/app/services/administrator/administrator.service';
import { catchError } from 'rxjs/operators';
import { Router, ActivatedRoute } from '@angular/router';
import { AdministratorModel } from 'src/app/models/administrator/administrator-basic-info';
import { AdministratorFormComponent } from '../administrator-form/administrator-form.component';

@Component({
  selector: 'app-edit-administrator',
  templateUrl: './edit-administrator.component.html',
  styleUrls: ['./edit-administrator.component.scss']
})
export class EditAdministratorComponent implements OnInit {
  @ViewChild(AdministratorFormComponent, { static: true }) public administratorForm: AdministratorFormComponent;
  editAdministratorForm: FormGroup;
  editingAdministrator: AdministratorModel = {} as AdministratorModel;
  submited: boolean = false;
  administratorId;
  constructor(
    private administratorService: AdministratorService,
    public customToastr: ToastService,
    private fb: FormBuilder,
    private router: Router,
    public route: ActivatedRoute,
  ) { }

  ngOnInit(): void {
    this.administratorId = Number(this.route.snapshot.paramMap.get('administratorId'));
    this.getAdministratorInfo(this.administratorId);
    this.initializeForm();
  }

  getAdministratorInfo(id: number) {
    this.administratorService.getAdministrator(id)
      .subscribe(
        response => {
          this.editingAdministrator = response;
          this.updateForm();
        },
        catchError => {
          this.customToastr.setError(catchError);
          this.router.navigateByUrl('administrator/maintenance')
        }
      )
  }

  initializeForm(): void {
    this.editAdministratorForm = this.fb.group({
      id: new FormControl(this.administratorId, Validators.required),
      name: new FormControl(null, Validators.required),
      email: new FormControl(null, [Validators.required, Validators.email]),
      password: new FormControl(null, Validators.required),
    })
  }

  updateForm() {
    this.editAdministratorForm.get('name').setValue(this.editingAdministrator.name);
    this.editAdministratorForm.get('email').setValue(this.editingAdministrator.email);
    this.editAdministratorForm.get('password').setValue(this.editingAdministrator.password);
  }

  updateAdministrator = function () {
    this.administratorForm.submited = true;
    if (!this.editAdministratorForm.invalid) {
      this.administratorService.update(this.editAdministratorForm.value)
        .subscribe(
          response => {
            this.customToastr.setSuccess("The administrator was successfully updated");
            this.administratorForm.resetForm();
          },
          catchError => {
            this.customToastr.setError(catchError);
          }
        )
    }
    else {
      this.customToastr.setError("Please verify the entered data.")
    }
  }

}
