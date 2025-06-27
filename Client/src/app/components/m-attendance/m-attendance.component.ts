import { Component, OnInit } from '@angular/core';
import { mAttendanceRecord, MAttendanceService } from 'src/app/services/m-attendance.service';

@Component({
  selector: 'app-m-attendance',
  templateUrl: './m-attendance.component.html',
  styleUrls: ['./m-attendance.component.css']
})
export class MAttendanceComponent implements OnInit {

  attendanceList: mAttendanceRecord[] = [];
  loading = false;
  error = '';

  // Filters bound to form inputs
  startDate?: string;
  endDate?: string;
  specificDate?: string;
  divisionId?: string;
  departmentId?: string;
  unitId?: string;
  sectionId?: string;
  lineId?: string;
  employeeId?: string;

  // Summary object to hold present and absent counts per employee
  attendanceSummary: { 
    [employeeId: string]: { 
      employeeName: string; 
      present: number; 
      absent: number;
    } 
  } = {};

  constructor(private attendanceService: MAttendanceService) { }

  ngOnInit(): void {
    this.loadAttendance();
  }

  loadAttendance(): void {
    this.loading = true;
    this.error = '';

    this.attendanceService.getAttendance(
      this.startDate,
      this.endDate,
      this.specificDate,
      this.divisionId,
      this.departmentId,
      this.unitId,
      this.sectionId,
      this.lineId,
      this.employeeId
    ).subscribe({
      next: (data) => {
        this.attendanceList = data;
        this.calculateSummary();
        this.loading = false;
      },
      error: (err) => {
        this.error = 'Failed to load attendance data';
        this.loading = false;
        console.error(err);
      }
    });
  }

  // Calculate present and absent counts per employee based on attendanceList
  calculateSummary(): void {
    this.attendanceSummary = {};

    this.attendanceList.forEach(record => {
      const empId = record.employeeId;
      if (!this.attendanceSummary[empId]) {
        this.attendanceSummary[empId] = {
          employeeName: record.employeeName,
          present: 0,
          absent: 0
        };
      }
      // Adjust this condition based on how your API returns present/absent statuses
      if (record.presentStatus?.toLowerCase() === 'present') {
        this.attendanceSummary[empId].present++;
      } else {
        this.attendanceSummary[empId].absent++;
      }
    });
  }

  resetFilters(): void {
    this.startDate = undefined;
    this.endDate = undefined;
    this.specificDate = undefined;
    this.employeeId = undefined;
    this.divisionId = undefined;
    this.departmentId = undefined;
    this.unitId = undefined;
    this.sectionId = undefined;
    this.lineId = undefined;
    this.loadAttendance();
  }
  get attendanceSummaryKeys(): string[] {
  return Object.keys(this.attendanceSummary || {});
}
}
