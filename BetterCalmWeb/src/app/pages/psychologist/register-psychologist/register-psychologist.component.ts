import { Component, OnInit } from '@angular/core';
import { PsychologistBasicInfo } from 'src/app/models/psychologist/psychologist-basic-info';
import { ProblematicBasicInfo } from 'src/app/models/problematic/problematic-basic-info';
import { ProblematicsService } from 'src/app/services/problematics/problematics.service';
import { PsychologistService } from 'src/app/services/psychologist/psychologist.service';
import { catchError } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';
import { FormGroup, FormBuilder, Validators, FormControl, FormArray } from '@angular/forms';

@Component({
  selector: 'app-register-psychologist',
  templateUrl: './register-psychologist.component.html',
  styleUrls: ['./register-psychologist.component.scss']
})
export class RegisterPsychologistComponent implements OnInit {

  psychologistForm: FormGroup;
  selectedProblematic: FormGroup;
  registered: boolean = false;

  public consultationModes = [
    { id: '1', itemName: 'Presencial' },
    { id: '2', itemName: 'Virtual' }
  ];
  public problematicsData = [];
  public problematics: ProblematicBasicInfo[] = [];

  constructor(
    private problematicsService: ProblematicsService,
    private psychologistService: PsychologistService,
    public toastr: ToastrService,
    private fb: FormBuilder
  ) { }

  ngOnInit(): void {
    this.initializePsychologistForm();
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

  initializePsychologistForm(): void {
    this.psychologistForm = this.fb.group({
      name: new FormControl(null, Validators.required),
      consultationMode: new FormControl(null, Validators.required),
      direction: new FormControl(null, Validators.required),
      problematics: this.fb.array([], [Validators.required, Validators.minLength(3)])
    })
  }

  registerPsychologist() {
    this.registered = true;
    if (!this.psychologistForm.invalid) {
      this.psychologistService.add(this.psychologistForm.value)
        .subscribe(
          response => {
            console.log(response);
            this.setSuccess();
          }
        ),
        catchError => {
          console.log(catchError.error);
          this.setError(catchError.error)
        }
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

  get psychologistProblematics(): FormArray {
    return this.psychologistForm.get('problematics') as FormArray;
  }

  problematicSelect(item: any) {
    this.selectedProblematic = this.fb.group({
      id: item.id,
      name: item.itemName,
    })
    this.psychologistProblematics.push(this.selectedProblematic);
  }

  problematicDeSelect(item: any) {
    let index = this.psychologistProblematics.value.findIndex(x => x.id === item.id);
    this.psychologistProblematics.removeAt(index);
  }

  get consultationMode(): FormControl {
    return this.psychologistForm.get('consultationMode') as FormControl;
  }

  consultationModeSelect(item: any) {
    this.consultationMode.setValue(item.itemName);
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
      "The psychologist was successfully registered",
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
