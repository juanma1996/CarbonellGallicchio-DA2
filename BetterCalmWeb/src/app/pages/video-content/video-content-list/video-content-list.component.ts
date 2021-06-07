import { Component, OnInit, Input } from '@angular/core';
import { VideoContentBasicInfo } from 'src/app/models/videoContent/video-content-basic-info';
import { DomSanitizer, SafeResourceUrl, } from '@angular/platform-browser';

@Component({
  selector: 'app-video-content-list',
  templateUrl: './video-content-list.component.html',
  styleUrls: ['./video-content-list.component.scss']
})
export class VideoContentListComponent implements OnInit {
  @Input() videos: VideoContentBasicInfo[];

  constructor(
    private sanitizer: DomSanitizer
  ) { }

  ngOnInit(): void {
    console.log(this.videos);
  }

  sanitize(vid) {
    return this.sanitizer.bypassSecurityTrustResourceUrl(vid);
  }


}
