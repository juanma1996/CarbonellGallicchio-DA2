import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-audio-content-dashboard',
  templateUrl: './audio-content-dashboard.component.html',
  styleUrls: ['./audio-content-dashboard.component.scss']
})
export class AudioContentDashboardComponent implements OnInit {

  public categoryId;
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

  constructor(public route: ActivatedRoute,) { }

  ngOnInit(): void {
    this.categoryId = this.route.snapshot.paramMap.get('categoryId');
  }

}
