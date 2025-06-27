export class BonusRecord {

    constructor(
    public bonusRecordID?: string,
    public bonusDate?: string,
    public joiningDate?: string,
    public basicSalary?: number,
    public houseRent?: number,
    public medicalAllowance?: number,
    public conveyanceAllowance?: string,
    public otherAllowance?: string,
    public grossSalary?: number,
    public bonusPercent?: number,
    public bonusAmount?: number,
    public festivalName?: string,
    public revenueStampAmount?: number,
    public netPayableAmount?: number,
    public employeeID?: string
  ) {}
}
