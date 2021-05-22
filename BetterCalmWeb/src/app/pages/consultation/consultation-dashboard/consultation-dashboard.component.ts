import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-consultation-dashboard',
  templateUrl: './consultation-dashboard.component.html',
  styleUrls: ['./consultation-dashboard.component.scss']
})
export class ConsultationDashboardComponent implements OnInit {

  psychologist = null;
  date: Date = new Date();
  data1 = [
    { id: '2', itemName: 'Foobar' },
    { id: '3', itemName: 'Is great' }
  ];
  settings1 = {
    singleSelection: true,
    text: 'Single Select',
    enableSearchFilter: false,
    classes: 'selectpicker btn-primary'
  };
  selectedItems1 = [];
  
  constructor() { }

  addConsultation(){
    this.psychologist = {
      Name: 'Jorge Sere',
      ConsultationMode: 'Presencial',
      Direction: 'Rio Negro 8156'
    }
  }

  ngOnInit(): void {
  }

}
