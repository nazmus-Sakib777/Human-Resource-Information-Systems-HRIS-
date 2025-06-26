import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JobLeftComponent } from './job-left.component';

describe('JobLeftComponent', () => {
  let component: JobLeftComponent;
  let fixture: ComponentFixture<JobLeftComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [JobLeftComponent]
    });
    fixture = TestBed.createComponent(JobLeftComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
