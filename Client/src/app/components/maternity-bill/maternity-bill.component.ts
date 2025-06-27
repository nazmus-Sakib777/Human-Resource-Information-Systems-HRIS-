import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';
import { MaternityBill } from 'src/app/models/maternity-bill';
import { MaternityBillService } from 'src/app/services/maternity-bill.service';

@Component({
  selector: 'app-maternity-bill',
  templateUrl: './maternity-bill.component.html',
  styleUrls: ['./maternity-bill.component.css']
})
export class MaternityBillComponent implements OnInit, OnDestroy {

  constructor(private service: MaternityBillService, private route: Router, private snackBar: MatSnackBar) { }

  dataList: MaternityBill[] = [];
  private unsubscribe$ = new Subject<void>();

  newConfig: MaternityBill = {
    maternityBillID: '',
    maternityConfigurationID: '',
    currentMonth: '',
    fromMonth: '',
    toMonth: '',
    numberOfMonths: '',
    basicSalary: 0,
    workingDays: 0,
    actualCurrentSalary: 0,
    earnedLeaveDays: 0,
    earnedLeaveAmount: 0,
    computed3MonthNetPayable: 0,
    computed3MonthWorkingDays: 0,
    actualPay: 0,
    computedPay: 0,
    actualNetPayable: 0,
    computedNetPayable: 0,
    localAreaClerance: '',
    localAreaRemarks: '',
    approvedDate: '',
    entryDate: '',
    employeeID: ''
  }

  displayedColumns: string[] = [
    'maternityBillID',
    'maternityConfigurationID',
    'currentMonth',
    'fromMonth',
    'toMonth',
    'numberOfMonths',
    'basicSalary',
    'employeeID'
    
  ]


  ngOnInit(): void {
    this.getAllMaternityBill();
  }

  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }

  getAllMaternityBill() {
    this.service.getAll().subscribe(
      (data) => {
        this.dataList = data;
      },
      (error) => {
        console.error('Error fetching maternity configurations:', error);
      }
    );

  }

  addMaternityBill(): void {
    this.service.create(this.newConfig).pipe(takeUntil(this.unsubscribe$)).subscribe({
      next: (config) => {
        this.getAllMaternityBill();
        this.newConfig = {
          maternityBillID: '',
          maternityConfigurationID: '',
          currentMonth: '',
          fromMonth: '',
          toMonth: '',
          numberOfMonths: '',
          basicSalary: 0,
          workingDays: 0,
          actualCurrentSalary: 0,
          earnedLeaveDays: 0,
          earnedLeaveAmount: 0,
          computed3MonthNetPayable: 0,
          computed3MonthWorkingDays: 0,
          actualPay: 0,
          computedPay: 0,
          actualNetPayable: 0,
          computedNetPayable: 0,
          localAreaClerance: '',
          localAreaRemarks: '',
          approvedDate: '',
          entryDate: '',
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
