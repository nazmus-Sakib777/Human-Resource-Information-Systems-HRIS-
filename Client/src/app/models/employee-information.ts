import { TaxAmount } from './tax-amount';

export class EmployeeInformation {
  employeeID: string = '';
  taxAmounts: TaxAmount[] = [];

  constructor(init?: Partial<EmployeeInformation>) {
    Object.assign(this, init);
  }
}

