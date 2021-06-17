import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContentImporterDashboardComponent } from './content-importer-dashboard.component';

describe('ContentImporterDashboardComponent', () => {
  let component: ContentImporterDashboardComponent;
  let fixture: ComponentFixture<ContentImporterDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ContentImporterDashboardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ContentImporterDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
