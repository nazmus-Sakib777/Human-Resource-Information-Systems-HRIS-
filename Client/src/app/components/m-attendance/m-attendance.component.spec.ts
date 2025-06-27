import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MAttendanceComponent } from './m-attendance.component';

describe('MAttendanceComponent', () => {
  let component: MAttendanceComponent;
  let fixture: ComponentFixture<MAttendanceComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MAttendanceComponent]
    });
    fixture = TestBed.createComponent(MAttendanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
