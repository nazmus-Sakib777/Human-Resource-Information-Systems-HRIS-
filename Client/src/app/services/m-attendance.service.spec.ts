import { TestBed } from '@angular/core/testing';

import { MAttendanceService } from './m-attendance.service';

describe('MAttendanceService', () => {
  let service: MAttendanceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MAttendanceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
