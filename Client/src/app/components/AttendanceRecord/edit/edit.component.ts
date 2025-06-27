

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AttendanceRecordService } from 'src/app/services/attendance-record.service';
import { AttendanceRecord } from 'src/app/models/attendance-record';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  model: AttendanceRecord = new AttendanceRecord();

  constructor(
    private route: ActivatedRoute,
    private service: AttendanceRecordService,
    private router: Router
  ) { }

  ngOnInit(): void {
    //const id = this.route.snapshot.paramMap.get('id')!;
    //this.service.getById(id).subscribe(data => this.model = data);


    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.service.getById(id).subscribe(data => {
        // data.attendanceDate Check and change the format
        if (data.attendanceDate) {
          data.attendanceDate = data.attendanceDate.substring(0, 10); // YYYY-MM-DD
        }
        this.model = data;
      });
    }
  }

  update() {
    console.log('Update called', this.model);
    this.service.update(this.model.attendanceRecordID, this.model).subscribe(() => {
      this.router.navigate(['/attendance/view']);
    });


  }
}



//import { Component } from '@angular/core';

//@Component({
//  selector: 'app-edit',
//  templateUrl: './edit.component.html',
//  styleUrls: ['./edit.component.css']
//})
//export class EditComponent {

//}app-attendance-record-edit..attendance-record-edit.component.html..AttendanceRecordEditComponent..attendance-records

