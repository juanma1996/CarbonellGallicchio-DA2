import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-audio-content-table',
  templateUrl: './audio-content-table.component.html',
  styleUrls: ['./audio-content-table.component.scss']
})
export class AudioContentTableComponent implements OnInit {
  @Input() audios: [];
  constructor() { }

  ngOnInit(): void {
  }

}
