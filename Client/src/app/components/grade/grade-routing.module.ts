import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GradeListComponent } from './grade-list/grade-list.component';
import { GradeFormComponent } from './grade-form/grade-form.component';

const routes: Routes = [
  { path: '', component: GradeListComponent },
  { path: 'form', component: GradeFormComponent },
  // { path: '', component: GradeListComponent }, // Handles grades routing
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class GradeRoutingModule {}
