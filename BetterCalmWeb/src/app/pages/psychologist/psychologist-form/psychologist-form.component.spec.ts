import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PsychologistFormComponent } from './psychologist-form.component';

describe('PsychologistFormComponent', () => {
  let component: PsychologistFormComponent;
  let fixture: ComponentFixture<PsychologistFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PsychologistFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PsychologistFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
