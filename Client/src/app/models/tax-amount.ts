import { EmployeeInformation } from './employee-information';

export class TaxAmount {
  taxAmountID: string = '';
  taxYear: number = 0;
  taxAmountValue: number = 0;
  taxType: string = 'Income';
  status: string = 'Pending';
  approvedDate: string = ''; // Format: 'YYYY-MM-DD'
  remarks: string = '';
  entryUser: string = '';
  employeeID: string = '';
  employeeInformations?: EmployeeInformation;

  constructor(init?: Partial<TaxAmount>) {
    Object.assign(this, init);
  }
}
