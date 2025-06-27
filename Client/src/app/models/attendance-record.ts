import { AttendanceConfiguration } from './attendance-configuration';
import { AttendanceStatus } from './attendance-status';

export class AttendanceRecord {
  attendanceRecordID: string = '';
  attendanceDate: string = ''; // Format: YYYY-MM-DD
  inTime: string = '';         // Format: HH:mm:ss
  outTime: string = '';
  otStart: string = '';
  otEnd: string = '';
  totalRegularHours: string = '';   // TimeSpan as string (e.g., "08:30:00")
  totalOvertimeHours: string = '';
  dayType: string = '';
  attendanceConfigurationID: string = '';
  attendanceConfiguration?: AttendanceConfiguration;
  attendanceStatusID: string = '';
  attendanceStatus?: AttendanceStatus;

  constructor(init?: Partial<AttendanceRecord>) {
    Object.assign(this, init);
  }
}
