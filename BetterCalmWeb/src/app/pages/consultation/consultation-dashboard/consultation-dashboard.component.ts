import { Component, OnInit } from '@angular/core';
import { ConsultationBasicInfo } from 'src/app/models/consultation/consultation-basic-info';
import { PsychologistBasicInfo } from 'src/app/models/psychologist/psychologist-basic-info';
import { ConsultationService } from 'src/app/services/consultation/consultation.service';
import { catchError } from 'rxjs/operators';
import { PacientBasicInfo } from 'src/app/models/pacient/pacient-basic-info';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-consultation-dashboard',
  templateUrl: './consultation-dashboard.component.html',
  styleUrls: ['./consultation-dashboard.component.scss']
})
export class ConsultationDashboardComponent implements OnInit {

  public psychologist: PsychologistBasicInfo;
  // public consultation: ConsultationBasicInfo = {} as ConsultationBasicInfo;

  public consultation : ConsultationBasicInfo = {
    problematicId : 1,
    pacient : {
      name: "",
      birthDate: new Date(),
      cellphone: "",
      email: "",
      surname: ""
    },
  }

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
    public toastr: ToastrService
  ) { }

  

  ngOnInit(): void {
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
        },
        catchError => {
          this.setError(catchError);
        }
      )
  }

  private createModel(): ConsultationBasicInfo {
    const modelBase: ConsultationBasicInfo =  <ConsultationBasicInfo>{};
    modelBase.problematicId = 1; //Hardcode until angular multiselect fix.
    modelBase.pacient = <PacientBasicInfo>{};
    modelBase.pacient.name = this.consultation.pacient.name;
    modelBase.pacient.surname = this.consultation.pacient.name; // Change it when separate the input.
    modelBase.pacient.birthDate = this.birthDate;
    modelBase.pacient.email = this.consultation.pacient.email;
    modelBase.pacient.cellphone = this.consultation.pacient.cellphone;
    return modelBase;
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

}
