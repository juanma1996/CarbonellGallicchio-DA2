import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AudioContentTableComponent } from './audio-content-table.component';

describe('AudioContentTableComponent', () => {
  let component: AudioContentTableComponent;
  let fixture: ComponentFixture<AudioContentTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AudioContentTableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AudioContentTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
