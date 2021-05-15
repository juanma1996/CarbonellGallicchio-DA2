import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlaylistsDashboardComponent } from './playlists-dashboard.component';

describe('PlaylistsDashboardComponent', () => {
  let component: PlaylistsDashboardComponent;
  let fixture: ComponentFixture<PlaylistsDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PlaylistsDashboardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PlaylistsDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
