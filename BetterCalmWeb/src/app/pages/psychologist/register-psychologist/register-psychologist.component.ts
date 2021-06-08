import { Component, OnInit, ViewChild } from '@angular/core';
import { PsychologistBasicInfo } from 'src/app/models/psychologist/psychologist-basic-info';
import { ProblematicBasicInfo } from 'src/app/models/problematic/problematic-basic-info';
import { ProblematicsService } from 'src/app/services/problematics/problematics.service';
import { PsychologistService } from 'src/app/services/psychologist/psychologist.service';
import { catchError } from 'rxjs/operators';
import { FormGroup, FormBuilder, Validators, FormControl, FormArray } from '@angular/forms';
import { PsychologistFormComponent } from '../psychologist-form/psychologist-form.component';
import { ToastService } from 'src/app/common/toast.service';

@Component({
  selector: 'app-register-psychologist',
  templateUrl: './register-psychologist.component.html',
  styleUrls: ['./register-psychologist.component.scss']
})
export class RegisterPsychologistComponent implements OnInit {
  @ViewChild(PsychologistFormComponent, { static: true }) public psychologistForm: PsychologistFormComponent;
  registerPsychologistForm: FormGroup;
  selectedProblematic: FormGroup;

  public problematicsData = [];
  public problematics: ProblematicBasicInfo[] = [];

  constructor(
    private problematicsService: ProblematicsService,
    private psychologistService: PsychologistService,
    public customToastr: ToastService,
    private fb: FormBuilder
  ) { }

  ngOnInit(): void {
    this.initializePsychologistForm();
  }

  initializePsychologistForm(): void {
    this.registerPsychologistForm = this.fb.group({
      name: new FormControl(null, Validators.required),
      consultationMode: new FormControl(null, Validators.required),
      fee: new FormControl(null, Validators.required),
      direction: new FormControl(null, Validators.required),
      problematics: this.fb.array([], [Validators.required, Validators.minLength(3)])
    })
  }

  registerPsychologist() {
    this.psychologistForm.submited = true;
    if (!this.registerPsychologistForm.invalid) {
      this.psychologistService.add(this.registerPsychologistForm.value)
        .subscribe(
          response => {
            this.customToastr.setSuccess("The psychologist was successfully registered");
          }
        ),
        catchError => {
          this.customToastr.setError(catchError)
        }
    }
    else {
      this.customToastr.setError("Please verify the entered data.");
    }
  }

}
