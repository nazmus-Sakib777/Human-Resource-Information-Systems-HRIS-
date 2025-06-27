
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AttendanceRecordService } from 'src/app/services/attendance-record.service';
import { AttendanceRecord } from 'src/app/models/attendance-record';

@Component({
  selector: 'app- create', 
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent {
  model: AttendanceRecord = new AttendanceRecord();

  constructor(private service: AttendanceRecordService, private router: Router) { }

  //save() {
  //  this.service.create(this.model).subscribe(() => {
  //    this.router.navigate(['/view']);
  //  });
  //}

  save() {
    const fixTime = (t: string): string =>
      t.length === 5 ? t + ':00' : t;

    this.model.inTime = fixTime(this.model.inTime);
    this.model.outTime = fixTime(this.model.outTime);
    this.model.otStart = fixTime(this.model.otStart);
    this.model.otEnd = fixTime(this.model.otEnd);

    this.service.create(this.model).subscribe({
      next: () => {
        alert('Saved successfully!');
        this.router.navigate(['/']);
      },
      error: err => {
        console.error('Insert failed', err);
        alert('Insert failed!');
      }
    });
  }

}


//import { Component } from '@angular/core';

//@Component({
//  selector: 'app-create',
//  templateUrl: './create.component.html',
//  styleUrls: ['./create.component.css']
//})
//export class CreateComponent {

//}app-attendance-record-create..attendance-record-create.component.html..AttendanceRecordCreateComponent..attendance-records

