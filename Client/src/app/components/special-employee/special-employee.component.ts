import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SpecialEmployeeService } from 'src/app/services/specialEmployee/special-employee.service';
import { SpecialEmployee } from 'src/app/models/specialEmployee/special-employee'; 

@Component({
  selector: 'app-special-employee',
  templateUrl: './special-employee.component.html'
})
export class SpecialEmployeeComponent implements OnInit {
  specialForm!: FormGroup;
  specialEmployees: SpecialEmployee[] = [];
  searchTerm: string = '';

  constructor(private fb: FormBuilder, private service: SpecialEmployeeService) {}

  ngOnInit(): void {
    this.specialForm = this.fb.group({
      specialEmployeeID: ['', [Validators.required, Validators.maxLength(50)]],
      fromDate: [''],
      toDate: [''],
      attendanceType: ['', [Validators.required, Validators.maxLength(30)]],
      employeeID: ['', Validators.required]
    });

    this.loadData();
  }

  loadData() {
    this.service.getAll().subscribe(data => this.specialEmployees = data);
  }

  onSubmit() {
    if (this.specialForm.invalid) return;
    const data: SpecialEmployee = this.specialForm.value;
    this.service.create(data).subscribe(() => {
      this.loadData();
      this.specialForm.reset();
    });
  }

  edit(data: SpecialEmployee) {
    this.specialForm.patchValue(data);
  }

  delete(id: string) {
    if (confirm("Delete this record?")) {
      this.service.delete(id).subscribe(() => this.loadData());
    }
  }

  filteredEmployees(): SpecialEmployee[] {
    return this.specialEmployees.filter(e =>
      e.specialEmployeeID.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
      e.attendanceType.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
  }
}
