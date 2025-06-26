import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SuspendService } from 'src/app/services/suspend/suspend.service';
import { Suspend } from 'src/app/models/suspend/suspend';
@Component({
  selector: 'app-suspend',
  templateUrl: './suspend.component.html'
})
export class SuspendComponent implements OnInit {
  suspendForm!: FormGroup;
  suspends: Suspend[] = [];
  searchTerm: string = '';

  constructor(private fb: FormBuilder, private service: SuspendService) {}

  ngOnInit(): void {
    this.suspendForm = this.fb.group({
      suspendID: ['', [Validators.required, Validators.maxLength(50)]],
      employeeID: ['', Validators.required],
      employeeName: ['', [Validators.required, Validators.maxLength(50)]],
      entryDate: ['', Validators.required],
      suspendDate: [''],
      localAreaClerance: ['', Validators.maxLength(50)],
      release: ['', Validators.maxLength(50)],
      remarks: ['', Validators.maxLength(50)],
      approvedDate: [''],
      releasedDate: [''],
      entryUser: ['', [Validators.required, Validators.maxLength(50)]]
    });

    this.loadData();
  }

  loadData() {
    this.service.getAll().subscribe(data => this.suspends = data);
  }

  onSubmit() {
    if (this.suspendForm.invalid) return;
    const data: Suspend = this.suspendForm.value;
    this.service.create(data).subscribe(() => {
      this.loadData();
      this.suspendForm.reset();
    });
  }

  edit(data: Suspend) {
    this.suspendForm.patchValue(data);
  }

  delete(id: string) {
    if (confirm("Delete this record?")) {
      this.service.delete(id).subscribe(() => this.loadData());
    }
  }

  filteredSuspends(): Suspend[] {
    return this.suspends.filter(s =>
      s.suspendID.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
      s.employeeName.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
  }
}
