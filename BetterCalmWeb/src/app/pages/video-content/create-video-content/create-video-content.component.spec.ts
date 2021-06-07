import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateVideoContentComponent } from './create-video-content.component';

describe('CreateVideoContentComponent', () => {
  let component: CreateVideoContentComponent;
  let fixture: ComponentFixture<CreateVideoContentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateVideoContentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateVideoContentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
