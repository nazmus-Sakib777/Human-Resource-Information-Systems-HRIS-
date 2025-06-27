import { Component, OnInit } from '@angular/core';
import { SalaryRecord } from 'src/app/models/salary-record';
import { SalaryRecordService } from 'src/app/services/salary-record.service';

@Component({
  selector: 'app-salary-record',
  templateUrl: './salary-record.component.html',
  styleUrls: ['./salary-record.component.css']
})
export class SalaryRecordComponent implements OnInit{

  salaryRecord:SalaryRecord[] = [];
     Form: SalaryRecord = new SalaryRecord(
  '',       // salaryRecordID
  '',       // salaryStartDate
  '',       // salaryEndDate
  '',       // joiningDate
  0,        // monthDays
  0,        // punchDays
  0,        // totalHoliDay
  0,        // totalLeave
  0,        // workingDays
  0,        // absenteeism
  0,        // gross
  0,        // actualGross
  0,        // basic
  0,        // houseRent
  0,        // medicalAllowance
  0,        // mobileAllowance
  0,        // otherAllowances
  0,        // lunchAllowance
  0,        // tax
  0,        // otherDeduction
  0,        // otHours
  0,        // otAmount
  0,        // byBankAmount
  0,        // byCashAmount
  0,        // netPayable
  0,        // conveyanceAllowance
  0,        // attendanceBonus
  0,        // specialAllowance
  0,        // salaryAdvance
  0,        // foodCharge
  0,        // otRate
  0,        // tiffinAllowance
  0,        // arrear
  0,        // specialBonus
  '',       // leaveStatus
  0,        // holiDayBillAmount
  0,        // nightBillAmount
  0,        // salaryID
  0,        // lunchBillAmount
  false,    // mobileBanking
  '',       // accountNumber
  '',       // bankName
  '',       // processDate
  '',       // unitID
  '',       // sectionID
  '',       // employmentTypeID
  '',       // salaryGradeID
  '',       // companyID
  '',       // departmentID
  '',       // designationID
  ''        // gradeID
);
      isEdit: boolean = false;
    
       constructor(private svc:SalaryRecordService) {}
    
      ngOnInit(): void {
        this.getAll();
      }
    
        getAll(): void {
        this.svc.getAll().subscribe(data => {
          this.salaryRecord = data;
        });
      }
    
       onSubmit(): void {
        if (this.isEdit) {
          this.svc.update(this.Form.salaryRecordID!, this.Form).subscribe(() => {
            this.getAll();
            this.resetForm();
          });
        } else {
          const newItem = { ...this.Form, id: crypto.randomUUID() }; // If you manually generate string id
          this.svc.create(newItem).subscribe(() => {
            this.getAll();
            this.resetForm();
          });
        }
      }
    
        editItem(item: SalaryRecord): void {
        this.Form = { ...item };
        this.isEdit = true;
      }
    
      deleteItem(id: string): void {
        if (confirm('Are you sure to delete?')) {
          this.svc.delete(id).subscribe(() => this.getAll());
        }
      }
    
      resetForm(): void {
        this.Form = new SalaryRecord(
  '',       // salaryRecordID
  '',       // salaryStartDate
  '',       // salaryEndDate
  '',       // joiningDate
  0,        // monthDays
  0,        // punchDays
  0,        // totalHoliDay
  0,        // totalLeave
  0,        // workingDays
  0,        // absenteeism
  0,        // gross
  0,        // actualGross
  0,        // basic
  0,        // houseRent
  0,        // medicalAllowance
  0,        // mobileAllowance
  0,        // otherAllowances
  0,        // lunchAllowance
  0,        // tax
  0,        // otherDeduction
  0,        // otHours
  0,        // otAmount
  0,        // byBankAmount
  0,        // byCashAmount
  0,        // netPayable
  0,        // conveyanceAllowance
  0,        // attendanceBonus
  0,        // specialAllowance
  0,        // salaryAdvance
  0,        // foodCharge
  0,        // otRate
  0,        // tiffinAllowance
  0,        // arrear
  0,        // specialBonus
  '',       // leaveStatus
  0,        // holiDayBillAmount
  0,        // nightBillAmount
  0,        // salaryID
  0,        // lunchBillAmount
  false,    // mobileBanking
  '',       // accountNumber
  '',       // bankName
  '',       // processDate
  '',       // unitID
  '',       // sectionID
  '',       // employmentTypeID
  '',       // salaryGradeID
  '',       // companyID
  '',       // departmentID
  '',       // designationID
  ''        // gradeID
);
        this.isEdit = false;
      }
}
