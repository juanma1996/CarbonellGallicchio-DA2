import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BonusDashboardComponent } from './bonus-dashboard.component';

describe('BonusDashboardComponent', () => {
  let component: BonusDashboardComponent;
  let fixture: ComponentFixture<BonusDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [BonusDashboardComponent]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BonusDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
