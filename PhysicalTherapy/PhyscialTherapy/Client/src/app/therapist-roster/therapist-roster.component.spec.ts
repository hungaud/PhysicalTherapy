import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TherapistRosterComponent } from './therapist-roster.component';

describe('TherapistRosterComponent', () => {
  let component: TherapistRosterComponent;
  let fixture: ComponentFixture<TherapistRosterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TherapistRosterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TherapistRosterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
