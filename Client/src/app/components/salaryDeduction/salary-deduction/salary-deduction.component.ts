import { Component,OnInit } from '@angular/core';
import { SalaryDeduction } from 'src/app/models/salary-deduction';
import { SalaryDeductionService } from 'src/app/services/salary-deduction.service';
import { SalarygradeService } from 'src/app/services/salarygrade.service';


@Component({
  selector: 'app-salary-deduction',
  templateUrl: './salary-deduction.component.html',
  styleUrls: ['./salary-deduction.component.css']
})
export class SalaryDeductionComponent implements OnInit {

   salaryDeduction:SalaryDeduction[] = [];
  salaryDeductionForm: SalaryDeduction = { salaryDeductionID: '', amount: 0, deductionDate: '',activationDate:'',
    reason:'',localAreaClerance:'',localAreaRemarks:'',approvedDate:'',entryUser:'',entryDate:'',employeeID:''
   };
  isEdit: boolean = false;

   constructor(private svc: SalaryDeductionService) {}

  ngOnInit(): void {
    this.getAllSalaryGrade();
  }

    getAllSalaryGrade(): void {
    this.svc.getAll().subscribe(data => {
      this.salaryDeduction = data;
    });
  }

   onSubmit(): void {
    if (this.isEdit) {
      this.svc.update(this.salaryDeductionForm.salaryDeductionID!, this.salaryDeductionForm).subscribe(() => {
        this.getAllSalaryGrade();
        this.resetForm();
      });
    } else {
      const newItem = { ...this.salaryDeductionForm, id: crypto.randomUUID() }; // If you manually generate string id
      this.svc.create(newItem).subscribe(() => {
        this.getAllSalaryGrade();
        this.resetForm();
      });
    }
  }

    editItem(item: SalaryDeduction): void {
    this.salaryDeductionForm = { ...item };
    this.isEdit = true;
  }

  deleteItem(id: string): void {
    if (confirm('Are you sure to delete?')) {
      this.svc.delete(id).subscribe(() => this.getAllSalaryGrade());
    }
  }

  resetForm(): void {
    this.salaryDeductionForm = { salaryDeductionID: '', amount:0, deductionDate: '',activationDate:'',
    reason:'',localAreaClerance:'',localAreaRemarks:'',approvedDate:'',entryUser:'',entryDate:'',employeeID:''};
    this.isEdit = false;
  }
  }
