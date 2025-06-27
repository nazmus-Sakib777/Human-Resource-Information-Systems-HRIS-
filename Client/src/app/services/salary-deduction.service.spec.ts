import { TestBed } from '@angular/core/testing';

import { SalaryDeductionService } from './salary-deduction.service';

describe('SalaryDeductionService', () => {
  let service: SalaryDeductionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SalaryDeductionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
