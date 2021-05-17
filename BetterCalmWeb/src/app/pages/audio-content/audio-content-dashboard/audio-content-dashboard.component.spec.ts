import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AudioContentDashboardComponent } from './audio-content-dashboard.component';

describe('AudioContentDashboardComponent', () => {
  let component: AudioContentDashboardComponent;
  let fixture: ComponentFixture<AudioContentDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AudioContentDashboardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AudioContentDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
