import { Component, OnInit } from '@angular/core';
import { SalaryEntry } from '../../../models/salary-entry';
import { SalaryEntryService } from 'src/app/services/salary-entry.service';

@Component({
  selector: 'app-salary-entry',
  templateUrl: './salary-entry.component.html',
  styleUrls: ['./salary-entry.component.css']
})
export class SalaryEntryComponent implements OnInit{

  salaryEntry:SalaryEntry[] = [];
    salaryEntryForm: SalaryEntry = { salaryEntryID: '', applyDate:'', salaryHeadName: '',amount:0,
      employeeID:''
     };
    isEdit: boolean = false;
  
     constructor(private svc: SalaryEntryService) {}
  
    ngOnInit(): void {
      this.getAllSalaryEntry();
    }
  
      getAllSalaryEntry(): void {
      this.svc.getAll().subscribe(data => {
        this.salaryEntry = data;
      });
    }
  
     onSubmit(): void {
      if (this.isEdit) {
        this.svc.update(this.salaryEntryForm.salaryEntryID!, this.salaryEntryForm).subscribe(() => {
          this.getAllSalaryEntry();
          this.resetForm();
        });
      } else {
        const newItem = { ...this.salaryEntryForm, id: crypto.randomUUID() }; // If you manually generate string id
        this.svc.create(newItem).subscribe(() => {
          this.getAllSalaryEntry();
          this.resetForm();
        });
      }
    }
  
      editItem(item: SalaryEntry): void {
      this.salaryEntryForm = { ...item };
      this.isEdit = true;
    }
  
    deleteItem(id: string): void {
      if (confirm('Are you sure to delete?')) {
        this.svc.delete(id).subscribe(() => this.getAllSalaryEntry());
      }
    }
  
    resetForm(): void {
      this.salaryEntryForm = { salaryEntryID: '', applyDate:'', salaryHeadName: '',amount:0,
      employeeID:''};
      this.isEdit = false;
    }
}
