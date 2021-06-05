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
      name: new FormControl(null, Validators.required),
      consultationMode: new FormControl(null, Validators.required),
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
    this.editPsychologistForm.get('problematics').setValue(this.editingPsychologist.problematics);
  }

  get problematics() {
    return this.editPsychologistForm.get('problematics') as FormArray;
  }

  updateMultiSelects() {
    // this will be the real problematics
    var tempProblematics = [{
      "id": 1,
      "name": "Depresión"
    },
    {
      "id": 2,
      "name": "Estrés"
    },
    {
      "id": 3,
      "name": "Ansiedad"
    },
    ];

    var problematicsFormatted = [];
    this.editingPsychologist.problematics = tempProblematics;
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
  }

  editPsychologist() {
    this.psychologistForm.submited = true;
    if (!this.editPsychologistForm.invalid) {
      this.psychologistService.add(this.editPsychologistForm.value)
        .subscribe(
          response => {
            console.log(response);
            this.customToastr.setSuccess("The psychologist was successfully registered");
          }
        ),
        catchError => {
          console.log(catchError.error);
          this.customToastr.setError(catchError.error)
        }
    }
    else {
      this.customToastr.setError("Please verify the entered data.");
    }
  }

}
