import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import swal from "sweetalert2";
import { AlertService } from 'src/app/common/alert.service';
import { ToastService } from 'src/app/common/toast.service';
import { BonusService } from 'src/app/services/bonus/bonus.service';

@Component({
  selector: 'app-bonus-dashboard',
  templateUrl: './bonus-dashboard.component.html',
  styleUrls: ['./bonus-dashboard.component.scss']
})
export class BonusDashboardComponent implements OnInit {
  entries: number = 10;
  bonusForm: FormGroup;
  bonusData = [
    {
      id: 1, itemName: "15",
    },
    {
      id: 2, itemName: "25",
    },
    {
      id: 3, itemName: "50",
    }
  ]

  pacients = [];
  showBonus: boolean = false;
  bonusForPacient: string = "";

  constructor(
    private fb: FormBuilder,
    private alert: AlertService,
    private customToastr: ToastService,
    private bonusService: BonusService,
  ) { }

  ngOnInit(): void {
    this.initializebonusForm()
    this.bonusService.get()
      .subscribe(
        response => {
          this.pacients = response
        },
        catchError => {
          this.customToastr.setError(catchError);
        });
  }

  entriesChange($event) {
    this.entries = $event.target.value;
  }

  initializebonusForm() {
    this.bonusForm = this.fb.group({
      pacientId: new FormControl(null),
      approved: new FormControl(null),
      amount: new FormControl(null, Validators.required),
    });
  }

  selectForApproval(pacient: any) {
    this.showBonus = true;
    //this.bonusForPacient = pacient.name;
    this.bonusForm.get('pacientId').setValue(pacient.id);
    this.bonusForm.get('approved').setValue(true);
    console.log(pacient);
  }

  transformToDecimal(percentage: number) {
    return percentage / 100;
  }

  disapprove(pacient: any) {
    //this.alert.showAlert("This is a test", "Nice test", this.calback.bind(this));
    this.showBonus = false;
    this.bonusForm.get('pacientId').setValue(pacient.id);
    this.bonusForm.get('approved').setValue(false);
    this.bonusForm.get('amount').setValue(0);
    console.log(this.bonusForm.value);
  }

  approvesBonus() {
    this.bonusService.update(this.bonusForm.value)
      .subscribe(
        response => {
          this.customToastr.setSuccess("Nice work juan")
        },
        catchError => {
          this.customToastr.setError(catchError);
        });
  }

  bonificationPercentSelect(item: any) {
    this.bonusForm.get('amount').setValue(this.transformToDecimal(item.itemName));
  }

}
