import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditPsychologistDashboardComponent } from './edit-psychologist-dashboard.component';

describe('EditPsychologistDashboardComponent', () => {
  let component: EditPsychologistDashboardComponent;
  let fixture: ComponentFixture<EditPsychologistDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditPsychologistDashboardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditPsychologistDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
