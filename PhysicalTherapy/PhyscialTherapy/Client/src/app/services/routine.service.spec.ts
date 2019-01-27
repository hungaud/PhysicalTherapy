import { TestBed } from '@angular/core/testing';

import { RoutineService } from './routine.service';

describe('RoutineService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: RoutineService = TestBed.get(RoutineService);
    expect(service).toBeTruthy();
  });
});
