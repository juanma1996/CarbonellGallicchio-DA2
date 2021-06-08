import { Component, OnInit } from '@angular/core';
import { ConsultationBasicInfo } from 'src/app/models/consultation/consultation-basic-info';
import { PsychologistBasicInfo } from 'src/app/models/psychologist/psychologist-basic-info';
import { ConsultationService } from 'src/app/services/consultation/consultation.service';
import { catchError } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';
import { ProblematicsService } from 'src/app/services/problematics/problematics.service';
import { ProblematicBasicInfo } from 'src/app/models/problematic/problematic-basic-info';
import { FormGroup, FormBuilder, FormControl, Validators, Form, FormArray } from '@angular/forms';

@Component({
  selector: 'app-consultation-dashboard',
  templateUrl: './consultation-dashboard.component.html',
  styleUrls: ['./consultation-dashboard.component.scss']
})
export class ConsultationDashboardComponent implements OnInit {

  consultationForm: FormGroup;
  scheduled: boolean = false;

  public psychologist: PsychologistBasicInfo;
  public problematicsData = [];
  public problematics: ProblematicBasicInfo[] = [];
  selectedItems = [];

  constructor(
    private consultationService: ConsultationService,
    private problematicsService: ProblematicsService,
    public toastr: ToastrService,
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
          this.setError(catchError.error)
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
    })
  }

  scheduleConsultation = function () {
    this.scheduled = true;
    if (!this.consultationForm.invalid) {
      this.consultationService.add(this.consultationForm.value)
        .subscribe(
          response => {
            console.log(response)
            this.psychologist = response;
            this.setSuccess();
          },
          catchError => {
            this.setError(catchError);
          }
        )
    } 
    else {
      this.setError("Please verify the entered data.");
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

  problematicDeSelect(item: any) {
    this.problematicId.reset();
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
      "The consultation was successfully scheduled",
      {
        timeOut: 3000,
        closeButton: true,
        enableHtml: true,
        toastClass: "alert alert-success alert-with-icon",
        positionClass: "toast-top-right"
      }
    );
  }

}