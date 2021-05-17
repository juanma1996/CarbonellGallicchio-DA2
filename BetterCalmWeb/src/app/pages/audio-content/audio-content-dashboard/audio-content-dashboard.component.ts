import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-audio-content-dashboard',
  templateUrl: './audio-content-dashboard.component.html',
  styleUrls: ['./audio-content-dashboard.component.scss']
})
export class AudioContentDashboardComponent implements OnInit {

  public audioContent = [
    {
      Id: 1,
      Name: 'Colgando en tus manos',
      Creator: 'Carlos Baute',
      Duration: '3:43'
    },
    {
      Id: 2,
      Name: 'Malbec',
      Creator: 'Duki',
      Duration: '3:43'
    },
    {
      Id: 3,
      Name: 'Cual es tu plan?',
      Creator: 'Bad Bunny',
      Duration: '3:43'
    },
    {
      Id: 4,
      Name: 'Dum Dum',
      Creator: 'Patrice Baumel',
      Duration: '3:43'
    },

  ]

  constructor() { }

  ngOnInit(): void {
  }

}
