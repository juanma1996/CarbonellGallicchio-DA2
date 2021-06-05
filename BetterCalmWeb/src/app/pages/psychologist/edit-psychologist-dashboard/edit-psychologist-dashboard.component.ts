import { Component, OnInit } from '@angular/core';
import { PsychologistBasicInfo } from 'src/app/models/psychologist/psychologist-basic-info';
import { ToastService } from 'src/app/common/toast.service';
import { AdministratorService } from 'src/app/services/administrator/administrator.service';
import { PsychologistService } from 'src/app/services/psychologist/psychologist.service';
import { catchError } from 'rxjs/operators';

@Component({
  selector: 'app-edit-psychologist-dashboard',
  templateUrl: './edit-psychologist-dashboard.component.html',
  styleUrls: ['./edit-psychologist-dashboard.component.scss']
})
export class EditPsychologistDashboardComponent implements OnInit {
  entries: number = 10;
  selected: any[] = [];
  psychologists: PsychologistBasicInfo[] = [];
  //   {
  //     id: 2,
  //     name: "Javier Virtual",
  //     consultationMode: "Virtual",
  //     direction: "18 de Julio 2034",
  //     creationDate: new Date("2021-05-06T17:17:24.735141"),
  //     problematics: []
  //   },
  //   {
  //     id: 4,
  //     name: "Juan",
  //     consultationMode: "Presencial",
  //     direction: "Rio negro",
  //     creationDate: new Date("2021-05-06T17:17:24.735141"),
  //     problematics: []
  //   },
  //   {
  //     id: 5,
  //     name: "Juana",
  //     consultationMode: "Virtual",
  //     direction: "Rio negro",
  //     creationDate: new Date("2021-05-06T17:17:24.735141"),
  //     problematics: []
  //   },
  //   {
  //     id: 8,
  //     name: "Juan",
  //     consultationMode: "Virtual",
  //     direction: "Rio negro",
  //     creationDate: new Date("2021-05-06T17:17:24.735141"),
  //     problematics: []
  //   },
  //   {
  //     id: 23,
  //     name: "Josesito",
  //     consultationMode: "Presencial",
  //     direction: "Parque Miramar",
  //     creationDate: new Date("2021-05-06T17:17:24.735141"),
  //     problematics: []
  //   },
  //   {
  //     id: 25,
  //     name: "Macarena",
  //     consultationMode: "Presencial",
  //     direction: "Malvin",
  //     creationDate: new Date("2021-05-06T17:17:24.735141"),
  //     problematics: []
  //   },
  // ];

  constructor(
    private psychologistService: PsychologistService,
    public customToastr: ToastService,
  ) { }

  ngOnInit(): void {
    this.getPsychologists();
  }

  getPsychologists() {
    this.psychologistService.get()
      .subscribe(
        response => {
          this.psychologists = response;
        },
        catchError => {
          this.customToastr.setError(catchError);
        }
      )
  }

  entriesChange($event) {
    this.entries = $event.target.value;
  }

  delete(id) {
    this.psychologistService.delete(id)
      .subscribe(
        response => {
          this.customToastr.setSuccess("The psychologist was successfully deleted");
          this.getPsychologists();
        },
        catchError => {
          this.customToastr.setError(catchError);
        }
      )
  }

}
