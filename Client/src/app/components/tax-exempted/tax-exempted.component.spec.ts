import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TaxExemptedComponent } from './tax-exempted.component';

describe('TaxExemptedComponent', () => {
  let component: TaxExemptedComponent;
  let fixture: ComponentFixture<TaxExemptedComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TaxExemptedComponent]
    });
    fixture = TestBed.createComponent(TaxExemptedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
