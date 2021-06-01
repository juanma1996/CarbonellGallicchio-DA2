import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditAudioContentComponent } from './edit-audio-content.component';

describe('EditAudioContentComponent', () => {
  let component: EditAudioContentComponent;
  let fixture: ComponentFixture<EditAudioContentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditAudioContentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditAudioContentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
