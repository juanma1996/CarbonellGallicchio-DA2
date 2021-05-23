import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PacientLayoutComponent } from './pacient-layout.component';

describe('PacientLayoutComponent', () => {
  let component: PacientLayoutComponent;
  let fixture: ComponentFixture<PacientLayoutComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PacientLayoutComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PacientLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
