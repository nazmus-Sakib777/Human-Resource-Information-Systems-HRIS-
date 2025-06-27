import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';
import { MaternityConfiguration } from 'src/app/models/maternity-configuration';
import { MaternityConfigurationService } from 'src/app/services/maternity-configuration.service';

@Component({
  selector: 'app-maternity-configuration',
  templateUrl: './maternity-configuration.component.html',
  styleUrls: ['./maternity-configuration.component.css']
})
export class MaternityConfigurationComponent implements OnInit, OnDestroy {

  constructor(private service: MaternityConfigurationService, private route: Router, private snackBar: MatSnackBar) { }
  dataList: MaternityConfiguration[] = [];

  private unsubscribe$ = new Subject<void>();
  newConfig: MaternityConfiguration = {
    maternityConfigurationID: '',
    joiningDate: '',
    isEligible: false,
    lastWithdrawalDate: '',
    installmentType: '',
    nextWithdrawableTime: 0,
    currentWithdrawalDate: '',
    gapInMonths: 0,
    status: '',
    employeeID: ''
  };


  // Only for using angular materials table
  displayedColumns: string[] = [
    'maternityConfigurationID',
    'joiningDate',
    'isEligible',
    'lastWithdrawalDate',
    'installmentType',
    'nextWithdrawableTime',
    'currentWithdrawalDate',
    'gapInMonths',
    'status',
    'employeeID'
    // 'action'
  ];

  // editMode: boolean = false;
  // editIndex: number | null = null;

  ngOnInit(): void {
    this.getAllMaternityConfig();
  }

  getAllMaternityConfig() {
    this.service.getAll().subscribe(
      (data) => {
        this.dataList = data;
      },
      (error) => {
        console.error('Error fetching maternity configurations:', error);
      }
    );
  }



  addMaternityConfig(): void {
    this.service.create(this.newConfig).pipe(takeUntil(this.unsubscribe$)).subscribe({
      next: (config) => {
        this.getAllMaternityConfig();
        this.newConfig = {
          maternityConfigurationID: '',
          joiningDate: '',
          isEligible: false,
          lastWithdrawalDate: '',
          installmentType: '',
          nextWithdrawableTime: 0,
          currentWithdrawalDate: '',
          gapInMonths: 0,
          status: '',
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


  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }

  // editMaternityConfig(record: any) {
  //   this.editMode = true;

  //   this.newConfig = {
  //     ...record
  //   };
  // }


}



