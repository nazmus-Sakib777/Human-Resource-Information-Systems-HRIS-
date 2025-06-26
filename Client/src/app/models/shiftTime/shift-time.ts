export interface ShiftTime {
  shiftID: string;
  shiftName: string;
  shiftStart: string;
  shiftEnd: string;
  startDate: string;
  endDate: string;
  consideredLunchHour?: number;
  breakDuration: number;
  employeeID: string;
}