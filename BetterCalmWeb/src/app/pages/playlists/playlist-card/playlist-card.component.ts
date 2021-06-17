import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-playlist-card',
  templateUrl: './playlist-card.component.html',
  styleUrls: ['./playlist-card.component.scss']
})
export class PlaylistCardComponent implements OnInit {

  @Input() playlist
  @Input() categoryId
  @Input() audio: boolean;
  constructor() { }

  ngOnInit(): void {
  }

}
