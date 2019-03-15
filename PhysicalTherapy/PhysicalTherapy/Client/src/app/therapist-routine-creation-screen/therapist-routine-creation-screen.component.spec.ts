import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TherapistRoutineCreationScreenComponent } from './therapist-routine-creation-screen.component';

describe('TherapistRoutineCreationScreenComponent', () => {
  let component: TherapistRoutineCreationScreenComponent;
  let fixture: ComponentFixture<TherapistRoutineCreationScreenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TherapistRoutineCreationScreenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TherapistRoutineCreationScreenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
