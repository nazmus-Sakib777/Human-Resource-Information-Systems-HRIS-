import { TestBed } from '@angular/core/testing';

import { TaxExemptedService } from './tax-exempted.service';

describe('TaxExemptedService', () => {
  let service: TaxExemptedService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TaxExemptedService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
