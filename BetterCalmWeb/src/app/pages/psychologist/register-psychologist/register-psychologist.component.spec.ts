import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterPsychologistComponent } from './register-psychologist.component';

describe('CreatePsychologistComponent', () => {
  let component: RegisterPsychologistComponent;
  let fixture: ComponentFixture<RegisterPsychologistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegisterPsychologistComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterPsychologistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
