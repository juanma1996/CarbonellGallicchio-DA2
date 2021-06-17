import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import swal from "sweetalert2";
import { AlertService } from 'src/app/common/alert.service';
import { ToastService } from 'src/app/common/toast.service';
import { BonusesService } from 'src/app/services/bonus/bonus.service';

@Component({
  selector: 'app-bonus-dashboard',
  templateUrl: './bonus-dashboard.component.html',
  styleUrls: ['./bonus-dashboard.component.scss']
})
export class BonusDashboardComponent implements OnInit {
  entries: number = 10;
  bonusForm: FormGroup;
  selectedBonus;
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
    private bonusesService: BonusesService,
  ) { }

  ngOnInit(): void {
    this.initializeBonusForm()
    this.getPacients();
  }

  getPacients() {
    this.bonusesService.get()
      .subscribe(
        response => {
          this.pacients = response;
        },
        catchError => {
          this.customToastr.setError(catchError);
        });
  }

  entriesChange($event) {
    this.entries = $event.target.value;
  }

  initializeBonusForm() {
    this.bonusForm = this.fb.group({
      pacientId: new FormControl(null),
      approved: new FormControl(null),
      amount: new FormControl(null, Validators.required),
    });
  }

  selectForApproval(pacient: any) {
    this.showBonus = true;
    this.bonusForPacient = pacient.pacientEmail;
    this.bonusForm.get('pacientId').setValue(pacient.pacientId);
    this.bonusForm.get('approved').setValue(true);
  }

  transformToDecimal(percentage: number) {
    return percentage / 100;
  }

  disapprove(pacient: any) {
    this.showBonus = false;
    this.bonusForm.get('pacientId').setValue(pacient.pacientId);
    this.bonusForm.get('approved').setValue(false);
    this.bonusForm.get('amount').setValue(0);
    this.alert.showAlert("Are you sure you want to deny the bonus?", "Yes, deny!", this.disaprovesBonus.bind(this));
  }

  approvesBonus() {
    if (!this.bonusForm.invalid) {
      this.bonusesService.update(this.bonusForm.value)
        .subscribe(
          response => {
            this.customToastr.setSuccess("The bonus has been aproved successfully")
            this.getPacients();
            this.resetForm();
          },
          catchError => {
            this.customToastr.setError(catchError);
          });
    } else {
      this.customToastr.setError("Please verify the entered data.")
    }
  }

  disaprovesBonus() {
    this.bonusesService.update(this.bonusForm.value)
      .subscribe(
        response => {
          this.customToastr.setSuccess("The bonus has been deny successfully");
          this.getPacients();
        },
        catchError => {
          this.customToastr.setError(catchError);
        });
  }

  bonusPercentSelect(item: any) {
    this.bonusForm.get('amount').setValue(this.transformToDecimal(item.itemName));
  }

  resetForm() {
    this.showBonus = false;
    this.bonusForm.reset();
    this.selectedBonus = [];
  }

}