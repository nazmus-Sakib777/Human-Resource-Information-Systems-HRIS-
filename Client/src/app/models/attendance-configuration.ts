import { AttendanceRecord } from './attendance-record';

export class AttendanceConfiguration {
  attendanceConfigurationID: string = '';
  graceTime: string = '';
  lunchBreakStartTime: string = '';
  lunchBreakEndTime: string = '';
  eveningSnacksBreakStartTime: string = '';
  eveningSnacksBreakEndTime: string = '';
  attendanceRecords?: AttendanceRecord[];

  constructor(init?: Partial<AttendanceConfiguration>) {
    Object.assign(this, init);
  }
}
