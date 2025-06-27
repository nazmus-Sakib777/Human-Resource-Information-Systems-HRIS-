import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

//For Nav Bar

import { MatToolbarModule } from '@angular/material/toolbar';
import { HomeComponent } from './pages/home/home.component';
import { AboutComponent } from './pages/about/about.component';
import { ContactComponent } from './pages/contact/contact.component';
//import { GradeModule } from './components/grade/grade.module'; // It’s a core feature (not lazily loaded)
import { MatMenuModule } from '@angular/material/menu';
import { EmployeeModule } from './components/employee/employee.module';


//For Jasmin Part

// ✅ Import these modules:
import { MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatDividerModule } from '@angular/material/divider';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatTabsModule } from '@angular/material/tabs';
import { MatIconModule } from '@angular/material/icon'; // For Icon
import { MatDialogModule } from '@angular/material/dialog'; // For Dialog
import { MaternityConfigurationComponent } from './components/maternity-configuration/maternity-configuration.component';
import { MaternityBillComponent } from './components/maternity-bill/maternity-bill.component';
import { LeaveRecordComponent } from './components/leave-record/leave-record.component';
import { LeaveApprovalComponent } from './components/leave-approval/leave-approval.component';
import { LeaveEncashmentComponent } from './components/leave-encashment/leave-encashment.component';
import { LeaveEncashmentRateComponent } from './components/leave-encashment-rate/leave-encashment-rate.component';


//Mofizul Part



//import { NavComponent } from './components/nav/nav/nav.component';
import { SalarygradeComponent } from './components/salarygrade/salarygrade/salarygrade.component';
import { SalarygradeService } from './services/salarygrade.service';
import { ToastrModule } from 'ngx-toastr';
import { SalaryDeductionComponent } from './components/salaryDeduction/salary-deduction/salary-deduction.component';
import { SalaryEntryComponent } from './components/salaryEntry/salary-entry/salary-entry.component';
import { SalaryProcessComponent } from './components/salaryProcess/salary-process/salary-process.component';

//for material

import { BonusRecordComponent } from './components/bonusRecord/bonus-record/bonus-record.component';
import { SalaryRecordComponent } from './components/salary-record/salary-record.component';
import { MAttendanceComponent } from './components/m-attendance/m-attendance.component';

// From Tofayel Part
// app.module.ts

import { RouterModule } from '@angular/router';
//import { NavMenuComponent } from './components/nav-menu/nav-menu.component';

import { DataService } from './services/item.service';

// Angular Material modules you need:

import { MatSelectModule } from '@angular/material/select';
import { MatTooltipModule } from '@angular/material/tooltip';


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




// Sakib 


import { EmploymentTypeComponent } from './components/employment-type/employment-type.component';
import { JobLeftComponent } from './components/job-left/job-left.component';
import { SuspendComponent } from './components/suspend/suspend.component';
import { SpecialEmployeeComponent } from './components/special-employee/special-employee.component';
import { ShiftTimeComponent } from './components/shift-time/shift-time.component';



@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AboutComponent,
    ContactComponent,
    
    // Jasmin Part declarations
    AppComponent,
    MaternityConfigurationComponent,
    MaternityBillComponent,
    LeaveRecordComponent,
    LeaveApprovalComponent,
    LeaveEncashmentComponent,
    LeaveEncashmentRateComponent,

    //Mofizul Part declarations
        AppComponent,
    //NavComponent,
    SalarygradeComponent,
    SalaryDeductionComponent,
    SalaryEntryComponent,
    SalaryProcessComponent,
    BonusRecordComponent,
    SalaryRecordComponent,
    MAttendanceComponent,

    //Tofayel Part

        // AttendanceRecord
    AttendanceViewComponent,
    AttendanceCreateComponent,
    AttendanceEditComponent,

    // TaxAmount
    TaxViewComponent,
    TaxCreateComponent,
    TaxEditComponent,
    //AttendanceConfiguration
    AttendanceConfigurationComponent,
    //TaxExempted
     TaxExemptedComponent,

     //Sakib
    AppComponent,
    EmploymentTypeComponent,
    JobLeftComponent,
    SuspendComponent,
    SpecialEmployeeComponent,
    ShiftTimeComponent


  ],
  imports: [
    
    BrowserModule,
    EmployeeModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatToolbarModule,
    MatMenuModule,
    // For It’s a core feature (not lazily loaded)
    //GradeModule

    // For Jasmin imports
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatInputModule,
    MatFormFieldModule,
    MatCheckboxModule,
    MatButtonModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatSnackBarModule,
    MatDividerModule,
    MatGridListModule,
    MatTabsModule,
    MatCardModule,
    MatToolbarModule,
    MatProgressSpinnerModule,
    MatIconModule,
    MatDialogModule,

    // Mofizul imports
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatButtonModule,
    MatIconModule,
    MatTableModule,
    MatGridListModule,
    MatDividerModule,

ToastrModule.forRoot({
  positionClass: 'toast-top-center',
  timeOut: 3000,
  progressBar: false,
  closeButton: false,
  tapToDismiss: true}),

  //Tofayel Part
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,

    // Angular Material
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatButtonModule,
    MatIconModule,
    MatTableModule,
    MatTooltipModule,
    MatCardModule,

    //Sakib
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule


  ],
  providers: [DataService],
  bootstrap: [AppComponent],
})
export class AppModule {}
