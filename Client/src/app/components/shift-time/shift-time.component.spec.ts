import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShiftTimeComponent } from './shift-time.component';

describe('ShiftTimeComponent', () => {
  let component: ShiftTimeComponent;
  let fixture: ComponentFixture<ShiftTimeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ShiftTimeComponent]
    });
    fixture = TestBed.createComponent(ShiftTimeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
