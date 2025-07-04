import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AttendanceConfigurationComponent } from './attendance-configuration.component';

describe('AttendanceConfigurationComponent', () => {
  let component: AttendanceConfigurationComponent;
  let fixture: ComponentFixture<AttendanceConfigurationComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AttendanceConfigurationComponent]
    });
    fixture = TestBed.createComponent(AttendanceConfigurationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
