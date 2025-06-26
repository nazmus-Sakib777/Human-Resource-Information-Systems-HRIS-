import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmploymentTypeService } from '../../services/EmploymentType/employment-type.service';
import { EmploymentType } from 'src/app/models/employment-type/employment-type';

@Component({
  selector: 'app-employment-type',
  templateUrl: './employment-type.component.html',
})
export class EmploymentTypeComponent implements OnInit {
  employmentForm: FormGroup;
  employmentTypes: EmploymentType[] = [];
  filteredTypes: EmploymentType[] = [];
  selectedId: string | null = null;
  searchTerm: string = '';
  currentPage: number = 1;
  pageSize: number = 5;

  constructor(private fb: FormBuilder, private service: EmploymentTypeService) {
    this.employmentForm = this.fb.group({
      employmentTypeID: ['', Validators.required],
      employmentTypeName: ['', Validators.required]
    });
  }

  ngOnInit() {
    this.loadEmploymentTypes();
  }

  loadEmploymentTypes() {
    this.service.getAll().subscribe(data => {
      this.employmentTypes = data;
      this.filter();
    });
  }

  onSubmit() {
    if (this.selectedId) {
      this.service.update(this.selectedId, this.employmentForm.value).subscribe(() => {
        this.resetForm();
        this.loadEmploymentTypes();
      });
    } else {
      this.service.create(this.employmentForm.value).subscribe(() => {
        this.resetForm();
        this.loadEmploymentTypes();
      });
    }
  }

  edit(item: EmploymentType) {
    this.selectedId = item.employmentTypeID;
    this.employmentForm.patchValue(item);
  }

  delete(id: string) {
    if (confirm('Are you sure you want to delete this record?')) {
      this.service.delete(id).subscribe(() => {
        this.loadEmploymentTypes();
      });
    }
  }

  resetForm() {
    this.selectedId = null;
    this.employmentForm.reset();
  }

  filter() {
    const term = this.searchTerm.toLowerCase();
    this.filteredTypes = this.employmentTypes.filter(
      x =>
        x.employmentTypeID.toLowerCase().includes(term) ||
        x.employmentTypeName.toLowerCase().includes(term)
    );
  }

  get paginatedEmploymentTypes(): EmploymentType[] {
    const start = (this.currentPage - 1) * this.pageSize;
    return this.filteredTypes.slice(start, start + this.pageSize);
  }

  get totalPages(): number {
    return Math.ceil(this.filteredTypes.length / this.pageSize);
  }

  changePage(direction: 'next' | 'prev') {
    if (direction === 'next' && this.currentPage < this.totalPages) {
      this.currentPage++;
    } else if (direction === 'prev' && this.currentPage > 1) {
      this.currentPage--;
    }
  }
}
