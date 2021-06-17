import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditAdministratorDashboardComponent } from './edit-administrator-dashboard.component';

describe('EditAdministratorDashboardComponent', () => {
  let component: EditAdministratorDashboardComponent;
  let fixture: ComponentFixture<EditAdministratorDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditAdministratorDashboardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditAdministratorDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
