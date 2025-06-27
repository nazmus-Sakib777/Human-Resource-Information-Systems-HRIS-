import { TestBed } from '@angular/core/testing';

import { TaxAmountService } from './tax-amount.service';

describe('TaxAmountService', () => {
  let service: TaxAmountService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TaxAmountService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
