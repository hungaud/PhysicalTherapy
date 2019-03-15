import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TherapistHomeScreenComponent } from './therapist-home-screen.component';

describe('TherapistHomeScreenComponent', () => {
  let component: TherapistHomeScreenComponent;
  let fixture: ComponentFixture<TherapistHomeScreenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TherapistHomeScreenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TherapistHomeScreenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
