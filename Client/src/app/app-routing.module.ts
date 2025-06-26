import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmploymentTypeComponent } from './components/employment-type/employment-type.component';
import { JobLeftComponent } from './components/job-left/job-left.component';
import { SuspendComponent } from './components/suspend/suspend.component';
import { SpecialEmployeeComponent } from './components/special-employee/special-employee.component';
import { ShiftTimeComponent } from './components/shift-time/shift-time.component';

const routes: Routes = [
  {
    path: 'employment-type',
    component: EmploymentTypeComponent
  },
  {
    path: 'job-left',
    component: JobLeftComponent
  },
  {
    path: 'suspend',
    component: SuspendComponent
  },
  {
    path: 'special-employee',
    component: SpecialEmployeeComponent
  },
  {
    path: 'shift-time',
    component: ShiftTimeComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
