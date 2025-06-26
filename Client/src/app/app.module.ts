import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmploymentTypeComponent } from './components/employment-type/employment-type.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { JobLeftComponent } from './components/job-left/job-left.component';
import { SuspendComponent } from './components/suspend/suspend.component';
import { SpecialEmployeeComponent } from './components/special-employee/special-employee.component';
import { ShiftTimeComponent } from './components/shift-time/shift-time.component';

@NgModule({
  declarations: [
    AppComponent,
    EmploymentTypeComponent,
    JobLeftComponent,
    SuspendComponent,
    SpecialEmployeeComponent,
    ShiftTimeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }



