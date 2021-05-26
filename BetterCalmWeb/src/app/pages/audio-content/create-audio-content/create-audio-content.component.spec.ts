import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateAudioContentComponent } from './create-audio-content.component';

describe('CreateAudioContentComponent', () => {
  let component: CreateAudioContentComponent;
  let fixture: ComponentFixture<CreateAudioContentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateAudioContentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateAudioContentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
