import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input'; // often needed with form fields
import { MatButtonModule } from '@angular/material/button'; // for buttons if used
import { FormsModule } from '@angular/forms'; // for ngForm
import { GradeListComponent } from './grade-list/grade-list.component';
import { GradeFormComponent } from './grade-form/grade-form.component';
import { MatSnackBarModule } from '@angular/material/snack-bar';

//For Routing
import { GradeRoutingModule } from './grade-routing.module';
@NgModule({
  declarations: [GradeListComponent, GradeFormComponent],
  imports: [
    CommonModule,
    FormsModule,
    MatIconModule,
    MatTableModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    GradeRoutingModule,
    MatSnackBarModule
  ],
  exports: [GradeListComponent, GradeFormComponent],
})
export class GradeModule {}
