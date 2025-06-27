import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { LeaveEncashment } from 'src/app/models/leave-encashment';
import { LeaveEncashmentService } from 'src/app/services/leave-encashment.service';
import { LeaveEncashmentRateComponent } from '../leave-encashment-rate/leave-encashment-rate.component';
import { Subject, takeUntil } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-leave-encashment',
  templateUrl: './leave-encashment.component.html',
  styleUrls: ['./leave-encashment.component.css']
})
export class LeaveEncashmentComponent implements OnInit, OnDestroy {
  constructor(private service: LeaveEncashmentService, private route: Router, private dialog: MatDialog, private snackBar: MatSnackBar) { }

  dataList: LeaveEncashment[] = [];

  private unsubscribe$ = new Subject<void>();

  newConfig: LeaveEncashment = {
    leaveEncashmentID: '',
    encashMonth: '',
    encashYear: '',
    basicSalary: 0,
    actualDays: '',
    computedDays: '',
    leaveEncashAmount: 0,
    otherDeductions: 0,
    actualEncashAmount: 0,
    computedEncashAmount: 0,
    localAreaClerance: '',
    localAreaRemarks: '',
    approvedDate: '',
    lastMonthWorkingDays: 0,
    employeeID: '',
    leaveEncashmentRates: [
      {
        leaveEncashmentRateID: '',
        toGrossSalary: 0,
        rateInPercent: 0,
        leaveEncashmentID: ''
      }
    ]
  }

  displayedColumns: string[] = [
    'leaveEncashmentID',
    'encashMonth',
    'encashYear',
    'basicSalary',
    'actualDays',
    'computedDays',
    'leaveEncashAmount',
    'otherDeductions',
    'actualEncashAmount',
    'computedEncashAmount',
    'localAreaClerance',
    'localAreaRemarks',
    'approvedDate',
    'lastMonthWorkingDays',
    'employeeID',
    'details'
    
    
  ]

  ngOnInit(): void {
    this.getLeaveEncashment();
  }

  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }
  getLeaveEncashment() {
    this.service.getAll().subscribe(
      (data) => {
        this.dataList = data;
      },
      (error) => {
        console.error('Error Fetching LeaveEncashment:', error);
      }
    );
  }


  openDetailsDialog(element: any): void {
    this.dialog.open(LeaveEncashmentRateComponent, {
      data: element,
      width: '500px'
    });
  }


  addRate() {
    this.newConfig.leaveEncashmentRates.push({
      leaveEncashmentRateID: '',
      toGrossSalary: 0,
      rateInPercent: 0,
      leaveEncashmentID: ''
    });
  }

  removeRate(index: number) {
    this.newConfig.leaveEncashmentRates.splice(index, 1);
  }


  addLeaveEncashment(): void {
    debugger
    this.service.create(this.newConfig).pipe(takeUntil(this.unsubscribe$)).subscribe({
      next: (config) => {
        this.getLeaveEncashment();
        this.newConfig = {
          leaveEncashmentID: '',
          encashMonth: '',
          encashYear: '',
          basicSalary: 0,
          actualDays: '',
          computedDays: '',
          leaveEncashAmount: 0,
          otherDeductions: 0,
          actualEncashAmount: 0,
          computedEncashAmount: 0,
          localAreaClerance: '',
          localAreaRemarks: '',
          approvedDate: '',
          lastMonthWorkingDays: 0,
          employeeID: '',
          leaveEncashmentRates: []
        };
        this.snackBar.open('Saved successfully!!', 'Close', {
          duration: 3000,
          panelClass: ['snackbar-success']
        });
      },
      error: (err) => {
        console.error(err);
        this.snackBar.open('Error adding!!.', 'Close', {
          duration: 3000,
          panelClass: ['snackbar-error']
        });
      }
    });
  }




}
