import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsultationDashboardComponent } from './consultation-dashboard.component';

describe('ConsultationDashboardComponent', () => {
  let component: ConsultationDashboardComponent;
  let fixture: ComponentFixture<ConsultationDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConsultationDashboardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsultationDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
