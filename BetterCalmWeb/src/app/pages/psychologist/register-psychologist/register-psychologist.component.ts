import { Component, OnInit } from '@angular/core';
import { PsychologistBasicInfo } from 'src/app/models/psychologist/psychologist-basic-info';
import { ProblematicBasicInfo } from 'src/app/models/problematic/problematic-basic-info';
import { ProblematicsService } from 'src/app/services/problematics/problematics.service';
import { PsychologistService } from 'src/app/services/psychologist/psychologist.service';
import { catchError } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register-psychologist',
  templateUrl: './register-psychologist.component.html',
  styleUrls: ['./register-psychologist.component.scss']
})
export class RegisterPsychologistComponent implements OnInit {

  public consultationModes = [
    { id: '1', itemName: 'Presencial' },
    { id: '2', itemName: 'Virtual' }
  ];
  public problematicsData = [];
  public problematics: ProblematicBasicInfo[] = [];

  public selectedProblematics: ProblematicBasicInfo = {} as ProblematicBasicInfo;
  public psychologist: PsychologistBasicInfo = {
    consultationMode: "",
    problematics: [],
  } as PsychologistBasicInfo;


  constructor(
    private problematicsService: ProblematicsService,
    private psychologistService: PsychologistService,
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

  registerPsychologist() {
    this.psychologistService.add(this.psychologist)
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
    var problematic: ProblematicBasicInfo = {
      id: item.id,
      name: item.itemName
    };
    this.psychologist.problematics.push(problematic);
    console.log(this.psychologist.problematics);
  }

  problematicDeSelect(item: any) {
    this.psychologist.problematics = this.psychologist.problematics.filter(problematic => problematic.id != item.id);
    console.log(this.psychologist.problematics);
  }

  consultationModeSelect(item: any) {
    console.log(item);
    this.psychologist.consultationMode = item.itemName;
    console.log(this.psychologist.consultationMode);
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
      "The register was successful",
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
