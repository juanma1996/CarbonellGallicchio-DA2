import { Component, OnInit } from '@angular/core';
import { ConsultationBasicInfo } from 'src/app/models/consultation/consultation-basic-info';
import { PsychologistBasicInfo } from 'src/app/models/psychologist/psychologist-basic-info';
import { ConsultationService } from 'src/app/services/consultation/consultation.service';
import { catchError } from 'rxjs/operators';
import { PacientBasicInfo } from 'src/app/models/pacient/pacient-basic-info';
import { ToastrService } from 'ngx-toastr';
import { ProblematicsService } from 'src/app/services/problematics/problematics.service';
import { ProblematicBasicInfo } from 'src/app/models/problematic/problematic-basic-info';

@Component({
  selector: 'app-consultation-dashboard',
  templateUrl: './consultation-dashboard.component.html',
  styleUrls: ['./consultation-dashboard.component.scss']
})
export class ConsultationDashboardComponent implements OnInit {

  public psychologist: PsychologistBasicInfo;
  public problematicsData = [];
  public problematics: ProblematicBasicInfo[] = [];
  public consultation : ConsultationBasicInfo = {
    pacient : {
      name: "",
      birthDate: new Date(),
      cellphone: "",
      email: "",
      surname: ""
    },
  } as ConsultationBasicInfo;

  public birthDate: Date = new Date(); // I think its unnecesary.
  public errorBackend: string = '';

  settings1 = {
    singleSelection: true,
    text: 'Single Select',
    enableSearchFilter: false,
    classes: 'selectpicker btn-primary'
  };
  selectedItems = [];

  constructor(
    private consultationService: ConsultationService,
    private problematicsService: ProblematicsService,
    public toastr: ToastrService
  ) { }

  

  ngOnInit(): void {
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
  scheduleConsultation = function() {
    console.log("Enter schedule")
    delete(this.psychologist);
    const basicInfo = this.createModel();
    console.log(basicInfo);
    this.consultationService.add(basicInfo)
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

  private createModel(): ConsultationBasicInfo {
    const modelBase: ConsultationBasicInfo =  <ConsultationBasicInfo>{};
    modelBase.problematicId = this.consultation.problematicId;
    modelBase.pacient = <PacientBasicInfo>{};
    modelBase.pacient.name = this.consultation.pacient.name;
    modelBase.pacient.surname = this.consultation.pacient.name; // Change it when separate the input.
    modelBase.pacient.birthDate = this.birthDate;
    modelBase.pacient.email = this.consultation.pacient.email;
    modelBase.pacient.cellphone = this.consultation.pacient.cellphone;
    return modelBase;
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
  
  problematicSelect(item: any) {
    console.log(item);
    this.consultation.problematicId = item.id;
    console.log(this.consultation.problematicId);
  }
  
  private setError(message){
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

  private setSuccess(){
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
