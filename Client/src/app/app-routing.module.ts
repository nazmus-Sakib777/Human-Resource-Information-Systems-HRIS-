//Nokib Components

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { AboutComponent } from './pages/about/about.component';
import { ContactComponent } from './pages/contact/contact.component';

//From Jasmin Components

import { MaternityConfigurationComponent } from './components/maternity-configuration/maternity-configuration.component';
import { MaternityBillComponent } from './components/maternity-bill/maternity-bill.component';
import { LeaveRecordComponent } from './components/leave-record/leave-record.component';
import { LeaveApprovalComponent } from './components/leave-approval/leave-approval.component';
import { LeaveEncashmentComponent } from './components/leave-encashment/leave-encashment.component';


// From Mofizul Components

import { SalarygradeComponent } from './components/salarygrade/salarygrade/salarygrade.component';
import { SalaryDeductionComponent } from './components/salaryDeduction/salary-deduction/salary-deduction.component';
import { SalaryEntryComponent } from './components/salaryEntry/salary-entry/salary-entry.component';
import { SalaryProcessComponent } from './components/salaryProcess/salary-process/salary-process.component';
import { BonusRecordComponent } from './components/bonusRecord/bonus-record/bonus-record.component';
import { SalaryRecordComponent } from './components/salary-record/salary-record.component';
import { MAttendanceComponent } from './components/m-attendance/m-attendance.component';


//From Tofayel Components

import { CommonModule } from '@angular/common';
// AttendanceRecord 
import { ViewComponent as AttendanceViewComponent } from './components/AttendanceRecord/view/view.component';
import { CreateComponent as AttendanceCreateComponent } from './components/AttendanceRecord/create/create.component';
import { EditComponent as AttendanceEditComponent } from './components/AttendanceRecord/edit/edit.component';
// TaxAmount
import { ViewComponent as TaxViewComponent } from './components/TaxAmount/view/view.component';
import { CreateComponent as TaxCreateComponent } from './components/TaxAmount/create/create.component';
import { EditComponent as TaxEditComponent } from './components/TaxAmount/edit/edit.component';
//AttendanceConfiguration
import { AttendanceConfigurationComponent } from './components/attendance-configuration/attendance-configuration.component';
//TaxExempted
import { TaxExemptedComponent } from './components/tax-exempted/tax-exempted.component';

//Sakib


import { EmploymentTypeComponent } from './components/employment-type/employment-type.component';
import { JobLeftComponent } from './components/job-left/job-left.component';
import { SuspendComponent } from './components/suspend/suspend.component';
import { SpecialEmployeeComponent } from './components/special-employee/special-employee.component';
import { ShiftTimeComponent } from './components/shift-time/shift-time.component';




const routes: Routes = [

  //Nokib Part Routes
  
  { path: '', component: HomeComponent },
  //{ path: 'about', component: AboutComponent },
  //{ path: 'contact', component: ContactComponent },
  //added for lazy loading example
  {
    path: 'grades',
    loadChildren: () =>
      import('./components/grade/grade.module').then((m) => m.GradeModule),
  },

  {
  path: 'employees',
  loadChildren: () =>
    import('./components/employee/employee.module').then(
      (m) => m.EmployeeModule
    ),
},

//   {
//   path: 'employees',
//   loadChildren: () =>
//     import('./components/employee/employee.module').then(
//       (m) => m.EmployeeModule
//     ),
// },

  // {
  //   path: 'employees',
  //   loadChildren: () =>
  //     import('./components/employee/employee.module').then(
  //       (m) => m.EmployeeModule
  //     ),
  // },

  //Jasmin Part Routes
  {
    path: 'MaternityConfiguration',
    component: MaternityConfigurationComponent,
  },
  { path: 'MaternityBill', component: MaternityBillComponent },
  { path: 'LeaveRecord', component: LeaveRecordComponent },
  { path: 'LeaveApproval', component: LeaveApprovalComponent },
  { path: 'LeaveEncashment', component: LeaveEncashmentComponent },

  // Mofizul Part Routes
  
  {path:'salarygrade',component:SalarygradeComponent},
  {path:'salaryDeduction',component:SalaryDeductionComponent},
  {path:'salaryEntry',component:SalaryEntryComponent},
  {path:'salaryProcess',component:SalaryProcessComponent},
  {path:'bonusRecord',component:BonusRecordComponent},
  {path:'salaryRecord',component:SalaryRecordComponent},
  {path:'multipleAtt',component:MAttendanceComponent},

  // Tofayel Routes
  
  { path: 'attendance/view', component: AttendanceViewComponent },
  { path: 'attendance/create', component: AttendanceCreateComponent },
  { path: 'attendance/edit/:id', component: AttendanceEditComponent },

  { path: 'tax/view', component: TaxViewComponent },
  { path: 'tax/create', component: TaxCreateComponent },
  { path: 'tax/edit/:id', component: TaxEditComponent },

  { path: 'attendance-configurations', component: AttendanceConfigurationComponent },

  { path: 'tax-exempted', component: TaxExemptedComponent },

//Sakib Routes

  { path: 'employment-type', component: EmploymentTypeComponent },
  { path: 'job-left', component: JobLeftComponent },
  { path: 'suspend', component: SuspendComponent },
  { path: 'special-employee', component: SpecialEmployeeComponent },
  { path: 'shift-time', component: ShiftTimeComponent },
];

@NgModule({
  declarations: [],
  
  imports: [CommonModule,RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}

