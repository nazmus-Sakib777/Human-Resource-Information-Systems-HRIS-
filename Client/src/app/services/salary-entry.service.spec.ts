import { TestBed } from '@angular/core/testing';

import { SalaryEntryService } from './salary-entry.service';

describe('SalaryEntryService', () => {
  let service: SalaryEntryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SalaryEntryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
