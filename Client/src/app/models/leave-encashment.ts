import { LeaveEncashmentRate } from "./leave-encashment-rate";

export interface LeaveEncashment {
    leaveEncashmentID: string,
    encashMonth: string,
    encashYear: string,
    basicSalary: number,
    actualDays: string,
    computedDays: string,
    leaveEncashAmount: number,
    otherDeductions: number,
    actualEncashAmount: number,
    computedEncashAmount: number,
    localAreaClerance: string,
    localAreaRemarks: string,
    approvedDate: string, // date
    lastMonthWorkingDays: number,
    employeeID: string,
    leaveEncashmentRates: LeaveEncashmentRate [];
}
