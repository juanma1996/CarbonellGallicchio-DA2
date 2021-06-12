import { Component, OnInit, ViewChild } from '@angular/core';
import { PsychologistFormComponent } from '../psychologist-form/psychologist-form.component';
import { ActivatedRoute, Router } from '@angular/router';
import { PsychologistService } from 'src/app/services/psychologist/psychologist.service';
import { FormBuilder, FormGroup, Validators, FormControl, FormArray } from '@angular/forms';
import { ToastService } from 'src/app/common/toast.service';
import { PsychologistBasicInfo } from 'src/app/models/psychologist/psychologist-basic-info';
import { catchError } from 'rxjs/operators';

@Component({
  selector: 'app-edit-psychologist',
  templateUrl: './edit-psychologist.component.html',
  styleUrls: ['./edit-psychologist.component.scss']
})
export class EditPsychologistComponent implements OnInit {
  @ViewChild(PsychologistFormComponent, { static: true }) public psychologistForm: PsychologistFormComponent;
  editPsychologistForm: FormGroup;
  editingPsychologist: PsychologistBasicInfo = {} as PsychologistBasicInfo;
  psychologistId;

  constructor(
    private psychologistService: PsychologistService,
    public route: ActivatedRoute,
    private fb: FormBuilder,
    private router: Router,
    public customToastr: ToastService,
  ) { }

  ngOnInit(): void {
    this.psychologistId = Number(this.route.snapshot.paramMap.get('psychologistId'));
    this.getPsychologistInfo(this.psychologistId);
    this.initializeForm();
  }

  initializeForm(): void {
    this.editPsychologistForm = this.fb.group({
      id: new FormControl(this.psychologistId),
      name: new FormControl(null, Validators.required),
      consultationMode: new FormControl(null, Validators.required),
      fee: new FormControl(null, Validators.required),
      direction: new FormControl(null, Validators.required),
      problematics: this.fb.array([], [Validators.required, Validators.minLength(3)])
    })
  }

  getPsychologistInfo(id: number) {
    this.psychologistService.getPsychologist(id)
      .subscribe(
        response => {
          this.editingPsychologist = response;
          this.updateForm();
          this.updateMultiSelects();
        },
        catchError => {
          this.customToastr.setError(catchError);
          this.router.navigateByUrl('psychologist/maintenance')
        }
      )
  }

  updateForm() {
    this.editPsychologistForm.get('name').setValue(this.editingPsychologist.name);
    this.editPsychologistForm.get('consultationMode').setValue(this.editingPsychologist.consultationMode);
    this.editPsychologistForm.get('direction').setValue(this.editingPsychologist.direction);
    this.editPsychologistForm.get('fee').setValue(this.editingPsychologist.fee);
  }

  get problematics() {
    return this.editPsychologistForm.get('problematics') as FormArray;
  }

  updateMultiSelects() {
    var problematicsFormatted = [];
    this.editingPsychologist.problematics.forEach(item => {
      problematicsFormatted.push({ id: item.id, itemName: item.name });
      var problematic = this.fb.group({
        id: item.id,
        name: item.name,
      })
      this.problematics.push(problematic);
    })
    this.psychologistForm.originalProblematics = problematicsFormatted;

    if (this.editingPsychologist.consultationMode == 'Presencial') {
      this.psychologistForm.originalConsultationMode = [{ id: '1', itemName: 'Presencial' }];
    } else {
      this.psychologistForm.originalConsultationMode = [{ id: '2', itemName: 'Virtual' }];
    }
    this.updateFee()
  }

  updateFee() {
    if (this.editingPsychologist.fee == 500) {
      this.psychologistForm.originalFee = [{ id: '1', itemName: 500 }]
    } else if (this.editingPsychologist.fee == 750) {
      this.psychologistForm.originalFee = [{ id: '1', itemName: 750 }]
    } else if (this.editingPsychologist.fee == 1000) {
      this.psychologistForm.originalFee = [{ id: '1', itemName: 1000 }]
    } else {
      this.psychologistForm.originalFee = [{ id: '1', itemName: 2000 }]
    }
  }

  editPsychologist() {
    this.psychologistForm.submited = true;
    if (!this.editPsychologistForm.invalid) {
      this.psychologistService.update(this.editPsychologistForm.value)
        .subscribe(
          response => {
            this.customToastr.setSuccess("The psychologist was successfully updated");
            this.psychologistForm.resetForm();
          }
        ),
        catchError => {
          this.customToastr.setError(catchError.error)
        }
    }
    else {
      this.customToastr.setError("Please verify the entered data.");
    }
  }

}
