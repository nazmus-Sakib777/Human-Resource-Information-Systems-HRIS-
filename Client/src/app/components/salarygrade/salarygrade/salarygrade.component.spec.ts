import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SalarygradeComponent } from './salarygrade.component';

describe('SalarygradeComponent', () => {
  let component: SalarygradeComponent;
  let fixture: ComponentFixture<SalarygradeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SalarygradeComponent]
    });
    fixture = TestBed.createComponent(SalarygradeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
