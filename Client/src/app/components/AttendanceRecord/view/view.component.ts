

import { Component, OnInit } from '@angular/core';
import { AttendanceRecordService } from 'src/app/services/attendance-record.service';
import { AttendanceRecord } from 'src/app/models/attendance-record';
import { Router } from '@angular/router';

@Component({
  selector: 'app- view', 
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit {
  attendanceRecords: AttendanceRecord[] = [];

  displayedColumns: string[] = [
    'sl',
    'date',
    'inTime',
    'outTime',
    'otStart',
    'otEnd',
    'regularHours',
    'overtime',
    'dayType',
    'actions'
  ];



  constructor(
    private service: AttendanceRecordService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.loadRecords();
  }

  loadRecords() {
    this.service.getAll().subscribe(data => this.attendanceRecords = data);
  }

  edit(id: string) {
    this.router.navigate(['/attendance/edit', id]);
  }


  delete(id: string) {
    if (confirm('Are you sure you want to delete this record?')) {
      this.service.delete(id).subscribe(() => this.loadRecords());
    }
  }
}



//import { Component } from '@angular/core';
//import { DataService } from '../../../services/item.service';
//import { AttendanceRecord } from '../../../models/attendance-record';

//@Component({
//  selector: 'app-view',
//  templateUrl: './view.component.html',
//  styleUrls: ['./view.component.css']
//})
//export class ViewComponent {

//  constructor(private service: DataService) { }
//  attendanceRecords: AttendanceRecord[] = [];
//  ngOnInit() {
//    this.service.getAttendanceRecords().subscribe(x => {
//      this.attendanceRecords = x;
//      console.log(x);
//    })
//  }
//}app-attendance-records..attendance-records.component.html.....attendance-records/edit

