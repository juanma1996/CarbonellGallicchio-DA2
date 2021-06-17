import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AudioContentCategoriesDashboardComponent } from './audio-content-categories-dashboard.component';

describe('AudioContentCategoriesDashboardComponent', () => {
  let component: AudioContentCategoriesDashboardComponent;
  let fixture: ComponentFixture<AudioContentCategoriesDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AudioContentCategoriesDashboardComponent]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AudioContentCategoriesDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
