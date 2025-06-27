import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';
import { LeaveRecord } from 'src/app/models/leave-record';
import { LeaveRecordService } from 'src/app/services/leave-record.service';

@Component({
  selector: 'app-leave-record',
  templateUrl: './leave-record.component.html',
  styleUrls: ['./leave-record.component.css']
})
export class LeaveRecordComponent implements OnInit, OnDestroy {

  constructor(private service: LeaveRecordService, private route: Router, private snackBar: MatSnackBar) { }

  dataList: LeaveRecord[] = [];

  private unsubscribe$ = new Subject<void>();
  newConfig: LeaveRecord = {
    leaveRecordID: '',
    leaveYear: '',
    leaveDate: '',
    leaveTime: '',
    entryDate: '',
    reason: '',
    deliveryDate: '',
    leaveType: '',
    totalLeave: '',
    leaveEnjoyed: '',
    approvedDate: '',
    entryUser: '',
    employeeID: ''
  }

  displayedColumns: string[] = [
    'leaveRecordID',
    'leaveYear',
    'leaveDate',
    'leaveTime',
    'entryDate',
    'reason',
    'deliveryDate',
    'leaveType',
    'totalLeave',
    'leaveEnjoyed',
    'approvedDate',
    'entryUser',
    'employeeID',
    'action'
  ]

  editMode: boolean = false; // Controls if we're editing
  editIndex: number | null = null;

  ngOnInit(): void {
    this.getAllLeaveRecord();
  }

  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }
  getAllLeaveRecord() {
    this.service.getAll().subscribe(
      (data) => {
        this.dataList = data;
      },
      (error) => {
        console.error('Error fetching leave record:', error);
      }
    );
  }

  addLeaveRecord(): void {
    if (this.editMode) {
      this.service.update(this.newConfig.leaveRecordID, this.newConfig).pipe(takeUntil(this.unsubscribe$)).subscribe({
        next: (config) => {
          this.getAllLeaveRecord();
          this.reset();
          this.snackBar.open('Updated successfully!!', 'Close', {
            duration: 3000,
            panelClass: ['snackbar-success']
          });
        },
        error: (err) => {
          console.error(err);
          this.snackBar.open('Error updating!!', 'Close', {
            duration: 3000,
            panelClass: ['snackbar-error']
          });
        }
      });
    } else {
      this.service.create(this.newConfig).pipe(takeUntil(this.unsubscribe$)).subscribe({
        next: (config) => {
          this.getAllLeaveRecord();
          this.reset();
          this.snackBar.open('Saved successfully!!', 'Close', {
            duration: 3000,
            panelClass: ['snackbar-success']
          });
        },
        error: (err) => {
          console.error(err);
          this.snackBar.open('Error adding!!', 'Close', {
            duration: 3000,
            panelClass: ['snackbar-error']
          });
        }
      });
    }
  }


  editLeaveRecord(record: any) {
    this.editMode = true;

    // Format dates to YYYY-MM-DD string
    const formatDate = (dateStr: string) => {
      const d = new Date(dateStr);
      return d.toISOString().substring(0, 10); // Extract YYYY-MM-DD
    };

    this.newConfig = {
      ...record,
      leaveDate: record.leaveDate ? formatDate(record.leaveDate) : '',
      entryDate: record.entryDate ? formatDate(record.entryDate) : '',
      deliveryDate: record.deliveryDate ? formatDate(record.deliveryDate) : '',
      approvedDate: record.approvedDate ? formatDate(record.approvedDate) : ''
    };
  }


  reset(): void {
    this.newConfig = {
      leaveRecordID: '',
      leaveYear: '',
      leaveDate: '',
      leaveTime: '',
      entryDate: '',
      reason: '',
      deliveryDate: '',
      leaveType: '',
      totalLeave: '',
      leaveEnjoyed: '',
      approvedDate: '',
      entryUser: '',
      employeeID: ''
    };
    this.editMode = false;
  }




}
