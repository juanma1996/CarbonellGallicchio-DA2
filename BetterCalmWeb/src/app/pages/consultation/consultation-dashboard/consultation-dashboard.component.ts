import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-consultation-dashboard',
  templateUrl: './consultation-dashboard.component.html',
  styleUrls: ['./consultation-dashboard.component.scss']
})
export class ConsultationDashboardComponent implements OnInit {

  psychologist = null;

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
