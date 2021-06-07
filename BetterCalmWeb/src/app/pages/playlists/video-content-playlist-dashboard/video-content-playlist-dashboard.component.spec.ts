import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VideoContentPlaylistDashboardComponent } from './video-content-playlist-dashboard.component';

describe('VideoContentPlaylistDashboardComponent', () => {
  let component: VideoContentPlaylistDashboardComponent;
  let fixture: ComponentFixture<VideoContentPlaylistDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VideoContentPlaylistDashboardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VideoContentPlaylistDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
