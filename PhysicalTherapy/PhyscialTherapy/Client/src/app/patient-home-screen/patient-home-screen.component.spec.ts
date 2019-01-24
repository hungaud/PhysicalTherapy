import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PatientHomeScreenComponent } from './patient-home-screen.component';

describe('PatientHomeScreenComponent', () => {
  let component: PatientHomeScreenComponent;
  let fixture: ComponentFixture<PatientHomeScreenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PatientHomeScreenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PatientHomeScreenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
