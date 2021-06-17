import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VideoContentDashboardComponent } from './video-content-dashboard.component';

describe('VideoContentDashboardComponent', () => {
  let component: VideoContentDashboardComponent;
  let fixture: ComponentFixture<VideoContentDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VideoContentDashboardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VideoContentDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
