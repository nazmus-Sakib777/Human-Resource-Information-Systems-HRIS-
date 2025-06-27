export interface MaternityConfiguration {
    maternityConfigurationID: string;
    joiningDate?: string; // ISO date string (e.g., '2025-06-05')
    isEligible: boolean;
    lastWithdrawalDate?: string;
    installmentType?: string;
    nextWithdrawableTime?: number;
    currentWithdrawalDate?: string;
    gapInMonths?: number;
    status?: string;
    employeeID?: string;
    // employeeInformation?: EmployeeInformation;
    // maternityBills?: MaternityBill[];
}
