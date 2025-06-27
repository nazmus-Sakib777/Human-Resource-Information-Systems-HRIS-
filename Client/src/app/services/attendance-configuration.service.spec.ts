import { TestBed } from '@angular/core/testing';

import { AttendanceConfigurationService } from './attendance-configuration.service';

describe('AttendanceConfigurationService', () => {
  let service: AttendanceConfigurationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AttendanceConfigurationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
