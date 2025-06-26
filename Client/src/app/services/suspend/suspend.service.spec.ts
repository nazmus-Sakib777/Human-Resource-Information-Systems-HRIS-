import { TestBed } from '@angular/core/testing';

import { SuspendService } from './suspend.service';

describe('SuspendService', () => {
  let service: SuspendService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SuspendService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
