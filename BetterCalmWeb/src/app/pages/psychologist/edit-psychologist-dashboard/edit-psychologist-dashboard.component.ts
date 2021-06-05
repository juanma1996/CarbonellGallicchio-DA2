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
