import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ShiftTimeService } from 'src/app/services/shiftTime/shift-time.service';
import { ShiftTime } from 'src/app/models/shiftTime/shift-time'; 

@Component({
  selector: 'app-shift-time',
  templateUrl: './shift-time.component.html'
})
export class ShiftTimeComponent implements OnInit {
  shiftForm!: FormGroup;
  shifts: ShiftTime[] = [];
  searchTerm: string = '';

  constructor(private fb: FormBuilder, private service: ShiftTimeService) {}

  ngOnInit(): void {
    this.shiftForm = this.fb.group({
      shiftID: ['', [Validators.required, Validators.maxLength(50)]],
      shiftName: ['', [Validators.required, Validators.maxLength(30)]],
      shiftStart: ['', Validators.required],
      shiftEnd: ['', Validators.required],
      startDate: ['', Validators.required],
      endDate: ['', Validators.required],
      consideredLunchHour: [''],
      breakDuration: ['', Validators.required],
      employeeID: ['', Validators.required]
    });

    this.loadData();
  }

  loadData() {
    this.service.getAll().subscribe(data => this.shifts = data);
  }

  onSubmit() {
    if (this.shiftForm.invalid) return;
    const data: ShiftTime = this.shiftForm.value;
    this.service.create(data).subscribe(() => {
      this.loadData();
      this.shiftForm.reset();
    });
  }

  edit(data: ShiftTime) {
    this.shiftForm.patchValue(data);
  }

  delete(id: string) {
    if (confirm("Delete this record?")) {
      this.service.delete(id).subscribe(() => this.loadData());
    }
  }

  filteredShifts(): ShiftTime[] {
    return this.shifts.filter(s =>
      s.shiftID.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
      s.shiftName.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
  }
}
