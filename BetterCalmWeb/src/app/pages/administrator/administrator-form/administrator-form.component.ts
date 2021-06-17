import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { AdministratorService } from 'src/app/services/administrator/administrator.service';
import { ToastrService } from 'ngx-toastr';
import { ToastService } from 'src/app/common/toast.service';

@Component({
  selector: 'app-administrator-form',
  templateUrl: './administrator-form.component.html',
  styleUrls: ['./administrator-form.component.scss']
})
export class AdministratorFormComponent implements OnInit {
  @Input() parentForm: FormGroup;
  administratorForm: FormGroup;
  submited: boolean = false;

  constructor(
    private administratorService: AdministratorService,
    private fb: FormBuilder
  ) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm(): void {
    this.administratorForm = this.parentForm;
  }

  resetForm() {
    this.submited = false;
    this.administratorForm.reset();
  }

}
