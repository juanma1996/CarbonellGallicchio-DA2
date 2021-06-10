import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import swal from "sweetalert2";
import { AlertService } from 'src/app/common/alert.service';
import { ToastService } from 'src/app/common/toast.service';

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

  pacients = [
    {
      id: 1,
      name: "Juan",
      email: "Juan@gmail.com",
      consultations: 7
    },
    {
      id: 2,
      name: "Fede",
      email: "Juan@gmail.com",
      consultations: 7
    },
    {
      id: 3,
      name: "Jorge",
      email: "Juan@gmail.com",
      consultations: 7
    },
    {
      id: 4,
      name: "Miguel",
      email: "Juan@gmail.com",
      consultations: 7
    },
    {
      id: 5,
      name: "Cristian",
      email: "Juan@gmail.com",
      consultations: 7
    },
    {
      id: 6,
      name: "Juan",
      email: "Juan@gmail.com",
      consultations: 7
    },
    {
      id: 7,
      name: "Juan",
      email: "Juan@gmail.com",
      consultations: 7
    },
    {
      id: 8,
      name: "Juan",
      email: "Juan@gmail.com",
      consultations: 7
    },
    {
      id: 9,
      name: "Juan",
      email: "Juan@gmail.com",
      consultations: 7
    },
    {
      id: 10,
      name: "Juan",
      email: "Juan@gmail.com",
      consultations: 7
    },
    {
      id: 11,
      name: "Juan",
      email: "Juan@gmail.com",
      consultations: 7
    },
    {
      id: 12,
      name: "Juan",
      email: "Juan@gmail.com",
      consultations: 7
    },
  ]
  showBonus: boolean = false;
  bonusForPacient: string = "";

  constructor(
    private fb: FormBuilder,
    private alert: AlertService,
    private customToastr: ToastService,
  ) { }

  ngOnInit(): void {
    this.initializebonusForm()
  }

  entriesChange($event) {
    this.entries = $event.target.value;
  }

  initializebonusForm() {
    this.bonusForm = this.fb.group({
      id: new FormControl(null),
      approves: new FormControl(null),
      amount: new FormControl(null, Validators.required),
    });
  }

  selectForApproval(pacient: any) {
    this.showBonus = true;
    this.bonusForPacient = pacient.name;
    this.bonusForm.get('id').setValue(pacient.id);
    this.bonusForm.get('approves').setValue(true);
    console.log(pacient);
  }

  transformToDecimal(percentage: number) {
    return percentage / 100;
  }

  calback() {

  }

  disapprove(pacient: any) {
    this.alert.showAlert("This is a test", "Nice test", this.calback.bind(this));
    this.showBonus = false;
    this.bonusForm.get('id').setValue(pacient.id);
    this.bonusForm.get('approves').setValue(false);
    this.bonusForm.get('amount').setValue(0);
    console.log(this.bonusForm.value);
  }

  approvesBonus() {
    console.log(this.bonusForm.value);
  }

  bonificationPercentSelect(item: any) {
    this.bonusForm.get('amount').setValue(this.transformToDecimal(item.itemName));
  }

}
