import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VideoContentCategoriesDashboardComponent } from './video-content-categories-dashboard.component';

describe('VideoContentCategoriesDashboardComponent', () => {
  let component: VideoContentCategoriesDashboardComponent;
  let fixture: ComponentFixture<VideoContentCategoriesDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VideoContentCategoriesDashboardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VideoContentCategoriesDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
