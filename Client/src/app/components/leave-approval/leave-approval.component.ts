import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';
import { LeaveApproval } from 'src/app/models/leave-approval';
import { LeaveApprovalService } from 'src/app/services/leave-approval.service';

@Component({
  selector: 'app-leave-approval',
  templateUrl: './leave-approval.component.html',
  styleUrls: ['./leave-approval.component.css']
})
export class LeaveApprovalComponent implements OnInit, OnDestroy {

  constructor(private service: LeaveApprovalService, private route: Router, private snackBar: MatSnackBar) { }

  dataList: LeaveApproval[] = [];

  private unsubscribe$ = new Subject<void>();

  newConfig: LeaveApproval = {
    leaveApprovalID: '',
    leaveName: '',
    leaveFromDate: new Date(),
    leaveToDate: new Date(),
    remarks: '',
    localAreaClerance: '',
    localAreaRemarks: '',
    approvedDate: new Date(),
    entryUser: '',
    leaveEnjoyed: '',
    totalLeave: '',
    leaveYear: '',
    providedLeave: '',
    employeeID: ''
  }

  displayedColumns: string[] = [
    'leaveApprovalID',
    'leaveName',
    'leaveFromDate',
    'leaveToDate',
    'remarks',
    'localAreaClerance',
    'localAreaRemarks',
    'approvedDate',
    'entryUser',
    'leaveEnjoyed',
    'totalLeave',
    'leaveYear',
    'providedLeave',
    'employeeID'
    
  ]
  ngOnInit(): void {
    this.getAllLeaveApproval();
  }

  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }
  getAllLeaveApproval() {
    this.service.getAll().subscribe(
      (data) => {
        this.dataList = data;
      },
      (error) => {
        console.error('Error fetching LeaveApproval:', error);
      }
    );
  }

  addLeaveApproval(): void {
    this.service.create(this.newConfig).pipe(takeUntil(this.unsubscribe$)).subscribe({
      next: (config) => {
        this.getAllLeaveApproval();
        this.newConfig = {
          leaveApprovalID: '',
          leaveName: '',
          leaveFromDate: new Date(),
          leaveToDate: new Date(),
          remarks: '',
          localAreaClerance: '',
          localAreaRemarks: '',
          approvedDate: new Date(),
          entryUser: '',
          leaveEnjoyed: '',
          totalLeave: '',
          leaveYear: '',
          providedLeave: '',
          employeeID: ''
        };
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
