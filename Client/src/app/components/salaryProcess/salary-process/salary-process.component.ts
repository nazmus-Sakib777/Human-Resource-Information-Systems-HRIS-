import { Component, OnInit } from '@angular/core';
import { SalaryProcess } from 'src/app/models/salary-process';
import { SalaryProcessService } from 'src/app/services/salary-process.service';
import { MatTableDataSource } from '@angular/material/table';
@Component({
  selector: 'app-salary-process',
  templateUrl: './salary-process.component.html',
  styleUrls: ['./salary-process.component.css']
})
export class SalaryProcessComponent implements OnInit{

 salaryProcess: MatTableDataSource<SalaryProcess> = new MatTableDataSource<SalaryProcess>();
      salaryProcessForm: SalaryProcess = { processID: '', monthNo:1, yearNo:2025,fromDate:'',
        toDate:'',salaryHeadName:'',amount:0,type:'',processDate:'',processedBy:'',employeeID:'',salaryEntryID:''
       };
      isEdit: boolean = false;
    
       constructor(private svc: SalaryProcessService) {}
    
      ngOnInit(): void {
        this.getAll();
      }
    
getAll(): void {
  this.svc.getAll().subscribe(data => {
    this.salaryProcess.data = data;
  });
}

    
       onSubmit(): void {
        if (this.isEdit) {
          this.svc.update(this.salaryProcessForm.processID!, this.salaryProcessForm).subscribe(() => {
            this.getAll();
            this.resetForm();
          });
        } else {
          const newItem = { ...this.salaryProcessForm, id: crypto.randomUUID() }; // If you manually generate string id
          this.svc.create(newItem).subscribe(() => {
            this.getAll();
            this.resetForm();
          });
        }
      }
    
        editItem(item: SalaryProcess): void {
        this.salaryProcessForm = { ...item };
        this.isEdit = true;
      }
    
      deleteItem(id: string): void {
        if (confirm('Are you sure to delete?')) {
          this.svc.delete(id).subscribe(() => this.getAll());
        }
      }
    
      resetForm(): void {
        this.salaryProcessForm = { processID: '', monthNo:1, yearNo:2025,fromDate:'',
        toDate:'',salaryHeadName:'',amount:0,type:'',processDate:'',processedBy:'',employeeID:'',salaryEntryID:''
       };
        this.isEdit = false;
      }

      displayedColumns: string[] = [
  'processID', 'monthNo', 'yearNo', 'fromDate', 'toDate',
  'salaryHeadName', 'amount', 'type', 'processDate',
  'processedBy', 'employeeID', 'salaryEntryID', 'actions'
];
}
