import { TestBed } from '@angular/core/testing';

import { PostRoutineSurveyService } from './post-routine-survey.service';

describe('PostRoutineSurveyService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PostRoutineSurveyService = TestBed.get(PostRoutineSurveyService);
    expect(service).toBeTruthy();
  });
});
