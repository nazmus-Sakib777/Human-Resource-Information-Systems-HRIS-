export class SalaryProcess {

    constructor(
    public processID?: string,
    public monthNo?: number,
    public yearNo?: number,
    public fromDate?: string,  // Use string for date from API
    public toDate?: string,
    public salaryHeadName?: string,
    public amount?: number,
    public type?: string,
    public processDate?: string,
    public processedBy?: string,
    public employeeID?: string,
    public salaryEntryID?: string){}
}
