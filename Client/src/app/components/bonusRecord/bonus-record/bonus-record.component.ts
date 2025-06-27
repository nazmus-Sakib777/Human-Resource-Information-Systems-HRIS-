import { Component } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { BonusRecord } from 'src/app/models/bonus-record';
import { BonusRecordService } from '../../../services/bonus-record.service';

@Component({
  selector: 'app-bonus-record',
  templateUrl: './bonus-record.component.html',
  styleUrls: ['./bonus-record.component.css']
})
export class BonusRecordComponent {

  bonusRecord: MatTableDataSource<BonusRecord> = new MatTableDataSource<BonusRecord>();
        Form: BonusRecord = { bonusRecordID: '', bonusDate:'', joiningDate:'',basicSalary:0,
          houseRent:0,medicalAllowance:0,conveyanceAllowance:'',otherAllowance:'',grossSalary:0,bonusPercent:0,
          bonusAmount:0,festivalName:'',revenueStampAmount:0,netPayableAmount:0,employeeID:''
         };
        isEdit: boolean = false;
      
         constructor(private svc: BonusRecordService) {}
      
        ngOnInit(): void {
          this.getAll();
        }
      
  getAll(): void {
    this.svc.getAll().subscribe(data => {
      this.bonusRecord.data = data;
    });
  }
  
      
         onSubmit(): void {
          if (this.isEdit) {
            this.svc.update(this.Form.bonusRecordID!, this.Form).subscribe(() => {
              this.getAll();
              this.resetForm();
            });
          } else {
            const newItem = { ...this.Form, id: crypto.randomUUID() }; // If you manually generate string id
            console.log("Submitting data:", JSON.stringify(this.Form));
            this.svc.create(newItem).subscribe(() => {
              this.getAll();
              this.resetForm();
            });
          }
        }
      
          editItem(item: BonusRecord): void {
          this.Form = { ...item };
          this.isEdit = true;
        }
      
        deleteItem(id: string): void {
          if (confirm('Are you sure to delete?')) {
            this.svc.delete(id).subscribe(() => this.getAll());
          }
        }
      
        resetForm(): void {
          this.Form = { bonusRecordID: '', bonusDate:'', joiningDate:'',basicSalary:0,
          houseRent:0,medicalAllowance:0,conveyanceAllowance:'',otherAllowance:'',grossSalary:0,bonusPercent:0,
          bonusAmount:0,festivalName:'',revenueStampAmount:0,netPayableAmount:0,employeeID:''
         };
          this.isEdit = false;
        }
  
        displayedColumns: string[] = [
    'bonusRecordID', 'bonusDate', 'joiningDate','basicSalary',
          'houseRent','medicalAllowance','conveyanceAllowance','otherAllowance','grossSalary','bonusPercent',
          'bonusAmount','festivalName','revenueStampAmount','netPayableAmount','employeeID','actions'
  ];
}
