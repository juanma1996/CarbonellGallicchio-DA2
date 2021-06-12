import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, FormArray, FormControl, Validators } from '@angular/forms';
import { ProblematicsService } from 'src/app/services/problematics/problematics.service';
import { PsychologistService } from 'src/app/services/psychologist/psychologist.service';
import { ToastService } from '../../../common/toast.service'
import { ProblematicBasicInfo } from 'src/app/models/problematic/problematic-basic-info';

@Component({
  selector: 'app-psychologist-form',
  templateUrl: './psychologist-form.component.html',
  styleUrls: ['./psychologist-form.component.scss']
})
export class PsychologistFormComponent implements OnInit {
  @Input() parentForm: FormGroup;

  psychologistForm: FormGroup;
  selectedProblematic: FormGroup;
  submited: boolean = false;
  originalConsultationMode = [];
  originalProblematics = [];
  originalFee = [];

  public consultationModes = [
    { id: '1', itemName: 'Presencial' },
    { id: '2', itemName: 'Virtual' }
  ];

  public fees = [
    { id: '1', itemName: 500 },
    { id: '2', itemName: 750 },
    { id: '3', itemName: 1000 },
    { id: '4', itemName: 2000 },
  ];

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

  initializePsychologistForm(): void {
    this.psychologistForm = this.parentForm;
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

  consultationModeDeSelect() {
    this.consultationMode.reset();
  }

  get fee(): FormControl {
    return this.psychologistForm.get('fee') as FormControl;
  }

  feeSelect(item: any) {
    this.fee.setValue(item.itemName);
  }

  feeDeSelect() {
    this.fee.reset();
  }

  resetForm() {
    this.submited = false;
    this.psychologistForm.reset();
    this.originalConsultationMode = [];
    this.originalFee = [];
    this.originalProblematics = [];
    while (this.psychologistProblematics.value.length) {
      this.psychologistProblematics.removeAt(0);
    }
  }

}