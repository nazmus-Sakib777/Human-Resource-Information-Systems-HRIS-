import { TestBed } from '@angular/core/testing';

import { BonusRecordService } from './bonus-record.service';

describe('BonusRecordService', () => {
  let service: BonusRecordService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BonusRecordService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
