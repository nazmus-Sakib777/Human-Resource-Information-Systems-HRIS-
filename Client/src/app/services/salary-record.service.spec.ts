import { TestBed } from '@angular/core/testing';

import { SalaryRecordService } from './salary-record.service';

describe('SalaryRecordService', () => {
  let service: SalaryRecordService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SalaryRecordService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
