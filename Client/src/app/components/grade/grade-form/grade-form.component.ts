import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Grade } from '../../../models/grade.model'; // Adjust based on your folder structure
import { MatSnackBar } from '@angular/material/snack-bar';
//import { GradeService } from 'src/app/services/grade.service';
import { GradeService } from '../../../services/grade.service';

@Component({
  selector: 'app-grade-form',
  templateUrl: './grade-form.component.html',
})
export class GradeFormComponent {
  @Input() grade: Grade = this.getEmptyGrade();
  @Input() isEdit: boolean = false;
  @Output() formSubmitted = new EventEmitter<void>();

  //constructor(private gradeService: GradeService) { }
  constructor(
    private readonly gradeService: GradeService,
    private readonly snackBar: MatSnackBar
  ) {}

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
  onSubmit() {
    if (this.isEdit) {
      this.gradeService.updateGrade(this.grade.gradeID, this.grade).subscribe({
        next: () => {
          this.snackBar.open('Grade updated successfully!', 'Close', {
            duration: 3000,
          });
          this.formSubmitted.emit();
        },
        error: () => {
          this.snackBar.open('Failed to update grade.', 'Close', {
            duration: 3000,
          });
        },
      });
    } else {
      this.gradeService.addGrade(this.grade).subscribe({
        next: () => {
          this.snackBar.open('Grade added successfully!', 'Close', {
            duration: 3000,
          });
          this.formSubmitted.emit();
        },
        error: () => {
          this.snackBar.open('Failed to add grade.', 'Close', {
            duration: 3000,
          });
        },
      });
    }
  }
}
