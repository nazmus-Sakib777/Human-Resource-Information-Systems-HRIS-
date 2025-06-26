import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { JobLeftService } from 'src/app/services/jobLeft/job-left.service'; 
import { JobLeft } from 'src/app/models/jobLeft/job-left'; 

@Component({
  selector: 'app-jobleft',
  templateUrl: './job-left.component.html',
  styleUrls: ['./job-left.component.css']
})
export class JobLeftComponent implements OnInit {
  jobForm!: FormGroup;
  jobLefts: JobLeft[] = [];
  searchTerm: string = '';

  constructor(private fb: FormBuilder, private service: JobLeftService) {}

  ngOnInit(): void {
    this.jobForm = this.fb.group({
      jobLeftID: ['', [Validators.required, Validators.maxLength(50)]],
      jobLeftDate: [''],
      jobLeftType: ['', [Validators.required, Validators.maxLength(50)]],
      localAreaClerance: ['', [Validators.maxLength(50)]],
      localAreaRemarks: ['', [Validators.maxLength(50)]],
      approvedDate: [''],
      entryUser: ['', [Validators.required, Validators.maxLength(50)]],
      employeeID: ['', Validators.required]
    });

    this.loadData();
  }

  loadData() {
    this.service.getAll().subscribe(data => this.jobLefts = data);
  }

  onSubmit() {
    if (this.jobForm.invalid) return;
    const data: JobLeft = this.jobForm.value;
    this.service.create(data).subscribe(() => {
      this.loadData();
      this.jobForm.reset();
    });
  }

  edit(data: JobLeft) {
    this.jobForm.patchValue(data);
  }

  delete(id: string) {
    if (confirm("Delete this record?")) {
      this.service.delete(id).subscribe(() => this.loadData());
    }
  }

  filteredJobLefts(): JobLeft[] {
    return this.jobLefts.filter(j =>
      j.jobLeftID.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
      j.jobLeftType.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
  }
}