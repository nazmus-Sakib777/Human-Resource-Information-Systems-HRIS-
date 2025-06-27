export class TaxExempted {
  taxExemptedID: string = '';
  taxYear: number = new Date().getFullYear();
  houseRent: number = 0;
  medical: number = 0;
  conveyance: number = 0;
  yearlyExemptedTaxAmount: number = 0;
  yearlySpecialExemptedTaxAmount: number = 0;
  approvalStatus: string = 'Pending';
  approvedBy: string = '';
  approvedDate: string = new Date().toISOString().substring(0, 10);
  employeeID: string = '';

  // Navigation props (optional)
  employeeInformations?: any;
  taxRules?: any[];
}
