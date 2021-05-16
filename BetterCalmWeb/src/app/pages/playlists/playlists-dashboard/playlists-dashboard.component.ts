import { Component, OnInit } from '@angular/core';
import {Location} from '@angular/common';
import { ActivatedRoute } from '@angular/router'

@Component({
  selector: 'app-playlists-dashboard',
  templateUrl: './playlists-dashboard.component.html',
  styleUrls: ['./playlists-dashboard.component.scss']
})
export class PlaylistsDashboardComponent implements OnInit {

  playlists = [
    {
      Id: 1,
      name: 'Enganchados cumbia',
      imageUrl: 'https://i.ytimg.com/vi/rqvz9e3uC2A/maxresdefault.jpg',
    },
    {
      Id: 2,
      name: 'Hip hop',
      imageUrl: 'https://image.freepik.com/vector-gratis/diseno-camiseta-estilo-hip-hop_9645-1054.jpg'
    },
    {
      Id: 3,
      name: 'Rock',
      imageUrl: 'http://www.eltiempo.com/files/image_640_428/uploads/2018/08/04/5b6663cad93ff.jpeg'
    },
    {
      Id: 4,
      name: 'Reggae',
      imageUrl: 'https://image.freepik.com/vector-gratis/fondo-estilo-reggae-leon_23-2147972596.jpg'
    },
  ]

  constructor(private _location: Location, public route: ActivatedRoute) { }

  backClicked() {
    this._location.back();
  }

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('categoryId');
    console.log(id);
   }

}
