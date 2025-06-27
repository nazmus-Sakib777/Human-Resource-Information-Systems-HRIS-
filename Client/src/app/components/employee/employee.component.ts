import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { EmployeeService } from '../../services/employee.service';
import { EmployeeInformation } from '../../models/employee.model';
import { HttpClient } from '@angular/common/http';



@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss']
})
export class EmployeeComponent implements OnInit {
  employeeForm: FormGroup;  
  employees: EmployeeInformation[] = [];
  isEdit = false;

  constructor(
    private fb: FormBuilder,
    private employeeService: EmployeeService,
    private snackBar: MatSnackBar,
    private http: HttpClient,

  ) {
    this.employeeForm = this.fb.group({
      employeeID: [''],
      isLineSelected: [''],
      lineID: [''],
      employeeName: ['', Validators.required],
      employeeNameLocal: [''],
      companyID: [''],
      unitID: [''],
      divisionID: [''],
      departmentID: [''],
      sectionID: [''],
      designationID: [''],
      gradeID: [''],
      shiftEmployeeID: [null],
      attendanceRecordID: [null],
      isOTAllowed: [false],
      gender: [''],
      iDentificationMark: [''],
      employmentTypeID: [''],
      presentAddress: [''],
      permanentAddress: [''],
      telephone: [''],
      mobileNumber: [''],
      email: ['', Validators.email],
      nationalIDNumber: ['', Validators.required],
      isMobileBanking: [false],
      accountNumber: [''],
      bankName: [''],
      fatherName: [''],
      fatherNameLocal: [''],
      fatherOccupation: [''],
      motherName: [''],
      motherNameLocal: [''],
      motherOccupation: [''],
      dateOfBirth: [null],
      placeOfBirth: [''],
      districtOfBirth: [''],
      nationality: [''],
      religion: [''],
      bloodGroup: [''],
      age: [null],
      maritalStatus: [''],
      dateOfMarriage: [null],
      appointmentType: [''],
      joiningDate: [null],
      postingDate: [null],
      confirmationDate: [null],
      retirementDate: [null],
      serviceLength: [''],
      spouseName: [''],
      spouseOccupation: [''],
      spouseDateOfBirth: [null],
      spouseBloodGroup: [''],
      salaryRecordID: [''],
      currentSalary: [''],
      salaryAtJoining: [''],
      salaryGradeID: [''],
      salaryStepID: [''],
      passportNumber: [''],
      passportIssueDate: [null],
      passportExpiryDate: [null],
      passportIssuePlace: [''],
      passportIssueAuthority: [''],
      licenseNumber: [''],
      licenseIssueDate: [null],
      licenseExpiryDate: [null],
      licenseIssuePlace: [''],
      licenseIssueAuthority: [''],
      membershipCardNumber: [''],
      association: [''],
      membershipType: [''],
      membershipValIDityDate: [null],
      referenceName1: [''],
      referenceAddress1: [''],
      referencePhone1: [''],
      referenceOccupation1: [''],
      referenceRelation1: [''],
      referenceName2: [''],
      referenceAddress2: [''],
      referencePhone2: [''],
      referenceOccupation2: [''],
      referenceRelation2: [''],
      localAreaClerance: [''],
      localAreaRemarks: [''],
      employeePhoto: [''],
      employeeSignature: [''],
      oldEmployeeID: [''],
      previousEmployeeID: [''],
      weeklyHoliDay: [''],
      approvedDate: [null],
      employeeStatus: ['']
    });
  }

  ngOnInit() {
    this.loadEmployees();
  }

  loadEmployees() {
    this.employeeService.getEmployees().subscribe(data => {
       console.log('Employees loaded:', data); 
      this.employees = data;
    });
  }

 
  onSubmit() {
    
    console.log('Form Value:', this.employeeForm.value);
    console.log('Is Form Valid:', this.employeeForm.valid);

    
    if (!this.employeeForm.valid) {
      this.snackBar.open('Please fill out all required fields.', 'Close', { duration: 3000 });
      return; 
    }

    const employee = {
      ...this.employeeForm.value,
      EmployeeID: this.employeeForm.value.employeeID
    };
    delete employee.employeeID;

    
    if (this.isEdit) {
      this.employeeService.updateEmployee(employee).subscribe({
        next: () => {
          this.snackBar.open('Updated successfully!', 'Close', { duration: 3000 });
          this.resetForm();
          this.loadEmployees();
        },
        error: (err) => {
          console.error('Update failed', err);
          this.snackBar.open('Update failed. Please try again.', 'Close', { duration: 3000 });
        }
      });
    } else {
      this.employeeService.addEmployee(employee).subscribe({
        next: () => {
          this.snackBar.open('Saved successfully!', 'Close', { duration: 3000 });
          this.resetForm();
          this.loadEmployees();
        },
        error: (err) => {
          console.error('Save failed', err);
          this.snackBar.open('Save failed. Please try again.', 'Close', { duration: 3000 });
        }
      });
    }
  }


  editEmployee(emp: EmployeeInformation) {
    this.employeeForm.patchValue(emp);
    this.isEdit = true;
  }


  deleteEmployee(id: string) {
    if (confirm('Are you sure to delete?')) {
      this.http.delete(`/api/EmployeeInformations/${id}`).subscribe({
        next: () => {
          this.snackBar.open('Deleted successfully!', 'Close', { duration: 3000 });
          this.loadEmployees(); // Refresh the list after deletion
        },
        error: (err) => {
          console.error("Delete failed", err);
          alert("Something went wrong: " + err.message);
        }
      });
    }
  }



  resetForm() {
    this.employeeForm.reset();
    this.isEdit = false;
  }

  displayedColumns = ['employeeID', 'employeeName', 'actions'];
}
