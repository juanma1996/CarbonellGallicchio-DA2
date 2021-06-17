import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditPsychologistComponent } from './edit-psychologist.component';

describe('EditPsychologistComponent', () => {
  let component: EditPsychologistComponent;
  let fixture: ComponentFixture<EditPsychologistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditPsychologistComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditPsychologistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
