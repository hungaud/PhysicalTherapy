import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SharedBackgroundComponent } from './shared-background.component';

describe('SharedBackgroundComponent', () => {
  let component: SharedBackgroundComponent;
  let fixture: ComponentFixture<SharedBackgroundComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SharedBackgroundComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SharedBackgroundComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
