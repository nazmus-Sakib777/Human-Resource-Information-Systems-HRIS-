import { AttendanceRecord } from './attendance-record';

export class AttendanceStatus {
  attendanceStatusID: string = '';
  statusName: string = '';
  statusShortName: string = '';
  attendanceRecords?: AttendanceRecord[];

  constructor(init?: Partial<AttendanceStatus>) {
    Object.assign(this, init);
  }
}
