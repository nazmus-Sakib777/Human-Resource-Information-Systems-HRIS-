import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BonusRecordComponent } from './bonus-record.component';

describe('BonusRecordComponent', () => {
  let component: BonusRecordComponent;
  let fixture: ComponentFixture<BonusRecordComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BonusRecordComponent]
    });
    fixture = TestBed.createComponent(BonusRecordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
