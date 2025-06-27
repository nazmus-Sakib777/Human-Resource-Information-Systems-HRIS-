export class SalaryDeduction {
 constructor(
 public  salaryDeductionID?: string,
 public amount?: Number,
 public deductionDate?: string,        // Use ISO string for dates
 public activationDate?: string,
 public reason?: string,
 public localAreaClerance?: string,
 public localAreaRemarks?: string,
 public approvedDate?: string,
 public entryUser?: string,
 public entryDate?: string,
 public employeeID?: string,
    ){}
}
