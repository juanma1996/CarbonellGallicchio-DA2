import { Component, OnInit } from '@angular/core';
import { PsychologistBasicInfo } from 'src/app/models/psychologist/psychologist-basic-info';
import { ConsultationService } from 'src/app/services/consultation/consultation.service';
import { catchError } from 'rxjs/operators';
import { ProblematicsService } from 'src/app/services/problematics/problematics.service';
import { ProblematicBasicInfo } from 'src/app/models/problematic/problematic-basic-info';
import { FormGroup, FormBuilder, FormControl, Validators, Form, FormArray } from '@angular/forms';
import { ToastService } from 'src/app/common/toast.service';
import { ConsultationBasicInfo } from 'src/app/models/consultation/consultation-basic-info';

@Component({
  selector: 'app-consultation-dashboard',
  templateUrl: './consultation-dashboard.component.html',
  styleUrls: ['./consultation-dashboard.component.scss']
})
export class ConsultationDashboardComponent implements OnInit {

  consultationForm: FormGroup;
  scheduled: boolean = false;

  public problematicsData = [];
  public problematics: ProblematicBasicInfo[] = [];
  public scheduledConsultation: ConsultationBasicInfo;
  public selectedDuration: [];
  public selectedProblematic: [];

  durationData = [
    { id: 1, itemName: 1 },
    { id: 2, itemName: 1.5 },
    { id: 3, itemName: 2 },
  ]

  constructor(
    private consultationService: ConsultationService,
    private problematicsService: ProblematicsService,
    public customToastr: ToastService,
    private fb: FormBuilder,
  ) { }

  ngOnInit(): void {
    this.initializeConsultationForm();
    this.problematicsService.get()
      .subscribe(
        response => {
          this.problematics = response;
          this.mapProblematics(this.problematics);
        },
        catchError => {
          this.customToastr.setError(catchError.error)
        }
      )
  }

  initializeConsultationForm(): void {
    this.consultationForm = this.fb.group({
      pacient: this.fb.group({
        name: new FormControl(null, Validators.required),
        email: new FormControl(null, [Validators.required, Validators.email]),
        birthDate: new FormControl(null, Validators.required),
        cellphone: new FormControl(null, [Validators.required, Validators.pattern("^[0-9]*$"), Validators.minLength(9)]),
        surname: new FormControl(null, Validators.required),
      }),
      problematicId: new FormControl(null, Validators.required),
      duration: new FormControl(null, Validators.required),
    })
  }

  scheduleConsultation = function () {
    this.scheduled = true;
    if (!this.consultationForm.invalid) {
      this.consultationService.add(this.consultationForm.value)
        .subscribe(
          response => {
            console.log(response)
            this.scheduledConsultation = response;
            this.customToastr.setSuccess("The consultation was successfully scheduled");
            this.resetForm();
          },
          catchError => {
            this.customToastr.setError(catchError);
          }
        )
    }
    else {
      this.customToastr.setError("Please verify the entered data.");
    }
  }

  mapProblematics(data) {
    this.problematics.forEach(problematic => {
      var data = {
        id: problematic.id,
        itemName: problematic.name
      }
      this.problematicsData.push(data);
    });
  }

  get problematicId(): FormControl {
    return this.consultationForm.get('problematicId') as FormControl;
  }

  problematicSelect(item: any) {
    this.problematicId.setValue(item.id);
  }

  problematicDeSelect() {
    this.problematicId.reset();
  }

  get duration(): FormControl {
    return this.consultationForm.get('duration') as FormControl;
  }

  durationSelect(item: any) {
    this.duration.setValue(item.itemName);
  }

  durationDeSelect() {
    this.duration.reset();
  }

  resetForm() {
    this.scheduled = false;
    this.consultationForm.reset();
    this.problematicId.reset();
    this.duration.reset();
    this.selectedProblematic = [];
    this.selectedDuration = [];
  }
}
