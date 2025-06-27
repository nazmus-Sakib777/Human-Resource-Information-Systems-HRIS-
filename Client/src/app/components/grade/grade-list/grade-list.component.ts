import { Component, OnInit } from '@angular/core';
//import { GradeService, Grade } from '../../../services/grade.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { GradeService } from '../../../services/grade.service';
import { Grade } from '../../../models/grade.model';


@Component({
  selector: 'app-grade-list',
  templateUrl: './grade-list.component.html',
})
export class GradeListComponent implements OnInit {
  grades: Grade[] = [];

  selectedGrade: Grade | null = null;
  isEditing = false;
  showForm = false;

  constructor(
    private readonly gradeService: GradeService,
    private readonly snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.loadGrades();
  }

  loadGrades() {
    this.gradeService.getGrades().subscribe({
      next: (data) => (this.grades = data),
      error: (err) => console.error('Error loading grades', err),
    });
  }

  onAddNew() {
    this.selectedGrade = this.getEmptyGrade();
    this.isEditing = false;
    this.showForm = true;
  }

  onEdit(grade: Grade) {
    this.selectedGrade = { ...grade };
    this.isEditing = true;
    this.showForm = true;
  }

  onDelete(id: string) {
    if (confirm('Are you sure to delete this grade?')) {
      this.gradeService.deleteGrade(id).subscribe({
        next: () => {
          this.snackBar.open('Grade deleted successfully!', 'Close', {
            duration: 3000,
          });
          this.loadGrades();
        },
        error: () => {
          this.snackBar.open('Failed to delete grade.', 'Close', {
            duration: 3000,
          });
        },
      });
    }
  }

  onFormSubmitted() {
    this.showForm = false;
    this.loadGrades();
  }

  getEmptyGrade(): Grade {
    return {
      gradeID: '',
      gradeShortID: '',
      gradeName: '',
      fromGrossSalary: 0,
      toGrossSalary: 0,
      gross: 0,
      basic: 0,
      houseRent: 0,
      medical: 0,
      conveyanceAllowance: 0,
      lunchAllowance: 0,
    };
  }
  displayedColumns: string[] = [
    'gradeID',
    'gradeName',
    'gross',
    'basic',
    'actions',
  ];
}
