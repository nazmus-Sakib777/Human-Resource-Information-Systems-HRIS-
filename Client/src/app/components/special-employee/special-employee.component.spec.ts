import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SpecialEmployeeComponent } from './special-employee.component';

describe('SpecialEmployeeComponent', () => {
  let component: SpecialEmployeeComponent;
  let fixture: ComponentFixture<SpecialEmployeeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SpecialEmployeeComponent]
    });
    fixture = TestBed.createComponent(SpecialEmployeeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
