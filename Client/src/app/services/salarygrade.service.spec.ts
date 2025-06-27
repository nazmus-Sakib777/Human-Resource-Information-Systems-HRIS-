import { TestBed } from '@angular/core/testing';

import { SalarygradeService } from './salarygrade.service';

describe('SalarygradeService', () => {
  let service: SalarygradeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SalarygradeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
