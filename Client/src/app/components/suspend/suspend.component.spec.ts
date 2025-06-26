import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SuspendComponent } from './suspend.component';

describe('SuspendComponent', () => {
  let component: SuspendComponent;
  let fixture: ComponentFixture<SuspendComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SuspendComponent]
    });
    fixture = TestBed.createComponent(SuspendComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
