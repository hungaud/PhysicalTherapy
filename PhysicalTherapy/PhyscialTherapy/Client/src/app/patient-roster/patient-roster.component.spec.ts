import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PatientRosterComponent } from './patient-roster.component';

describe('PatientRosterComponent', () => {
  let component: PatientRosterComponent;
  let fixture: ComponentFixture<PatientRosterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PatientRosterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PatientRosterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
