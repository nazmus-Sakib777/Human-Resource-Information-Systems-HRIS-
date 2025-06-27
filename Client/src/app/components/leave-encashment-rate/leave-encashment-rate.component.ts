import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-leave-encashment-rate',
  templateUrl: './leave-encashment-rate.component.html',
  styleUrls: ['./leave-encashment-rate.component.css']
})
export class LeaveEncashmentRateComponent {
  constructor(@Inject(MAT_DIALOG_DATA) public data: any) {}
}
