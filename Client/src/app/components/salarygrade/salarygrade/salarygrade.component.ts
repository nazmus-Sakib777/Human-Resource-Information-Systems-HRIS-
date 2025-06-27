import { Component, OnInit } from '@angular/core';
import { Salarygrade } from 'src/app/models/salarygrade';
import { SalarygradeService } from 'src/app/services/salarygrade.service';

@Component({
  selector: 'app-salarygrade',
  templateUrl: './salarygrade.component.html',
  styleUrls: ['./salarygrade.component.css']
})
export class SalarygradeComponent implements OnInit {
  salarygrade: Salarygrade[] = [];

  // Form model
  newSalaryGrade: Salarygrade = {
    salaryGradeID: '',
    gradeName: '',
    gradeStatus: '',
    ruleName: '',
    effectiveDate: '',
    gradeID: ''
  };

  isEditing = false; // Flag to track edit mode

  constructor(private svc: SalarygradeService) {}

  ngOnInit(): void {
    this.loadSalaryGrades();
  }

  loadSalaryGrades(): void {
    this.svc.getSalarygrade().subscribe({
      next: (data) => {
        this.salarygrade = data;
        this.sortSalaryGradeDescending();
      },
      error: (err) => console.error('Failed to load salary grades', err)
    });
  }

  sortSalaryGradeDescending(): void {
    this.salarygrade.sort((a, b) => {
      const numA = parseInt((a.salaryGradeID ?? '').replace(/\D/g, '')) || 0;
      const numB = parseInt((b.salaryGradeID ?? '').replace(/\D/g, '')) || 0;
      return numB - numA;
    });
  }

  addSalaryGrade(): void {
    if (!this.newSalaryGrade.gradeName || !this.newSalaryGrade.gradeStatus || !this.newSalaryGrade.gradeID) {
      alert('Please fill in all required fields.');
      return;
    }

    if (this.isEditing) {
      this.updateSalaryGrade();
    } else {
      this.svc.addSalaryGrade(this.newSalaryGrade).subscribe({
        next: () => {
          alert('Salary Grade added successfully!');
          this.resetForm();
          this.loadSalaryGrades();
        },
        error: (err) => {
          console.error('Failed to add salary grade', err);
          alert('Failed to add salary grade');
        }
      });
    }
  }

  editSalaryGrade(item: Salarygrade): void {
    this.isEditing = true;
    this.newSalaryGrade = { ...item }; // Clone the item into form
  }

  updateSalaryGrade(): void {
    if (!this.newSalaryGrade.salaryGradeID) {
      alert('Invalid Salary Grade ID');
      return;
    }

this.svc.updateSalaryGrade(this.newSalaryGrade).subscribe({
  next: () => {
    alert('Salary Grade updated successfully!');
    this.resetForm();
    this.loadSalaryGrades();
  },
  error: (err) => {
    console.error('Failed to update salary grade', err);
    alert('Failed to update salary grade');
  }
});
  }

  resetForm(): void {
    this.isEditing = false;
    this.newSalaryGrade = {
      salaryGradeID: '',
      gradeName: '',
      gradeStatus: '',
      ruleName: '',
      effectiveDate: '',
      gradeID: ''
    };
  }

  deleteSalarygrade(id: string): void {
    if (confirm('Are you sure you want to delete this Salary Grade?')) {
      this.svc.deleteSalaryGrade(id).subscribe({
        next: () => {
          alert('Deleted successfully!');
          this.loadSalaryGrades();
        },
        error: (err) => console.error('Delete failed', err)
      });
    }
  }
}