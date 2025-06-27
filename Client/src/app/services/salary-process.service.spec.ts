import { TestBed } from '@angular/core/testing';

import { SalaryProcessService } from './salary-process.service';

describe('SalaryProcessService', () => {
  let service: SalaryProcessService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SalaryProcessService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
