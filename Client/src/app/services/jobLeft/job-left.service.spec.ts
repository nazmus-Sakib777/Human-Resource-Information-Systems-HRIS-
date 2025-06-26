import { TestBed } from '@angular/core/testing';

import { JobLeftService } from './job-left.service';

describe('JobLeftService', () => {
  let service: JobLeftService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(JobLeftService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
