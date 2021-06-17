import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayableContentFormComponent } from './playable-content-form.component';

describe('PlayableContentFormComponent', () => {
  let component: PlayableContentFormComponent;
  let fixture: ComponentFixture<PlayableContentFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PlayableContentFormComponent]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PlayableContentFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
