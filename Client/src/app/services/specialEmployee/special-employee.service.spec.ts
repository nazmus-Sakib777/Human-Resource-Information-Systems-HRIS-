import { TestBed } from '@angular/core/testing';

import { SpecialEmployeeService } from './special-employee.service';

describe('SpecialEmployeeService', () => {
  let service: SpecialEmployeeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SpecialEmployeeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
