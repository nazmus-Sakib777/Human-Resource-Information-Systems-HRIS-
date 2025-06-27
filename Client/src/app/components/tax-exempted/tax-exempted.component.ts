//import { Component } from '@angular/core';

//@Component({
//  selector: 'app-tax-exempted',
//  templateUrl: './tax-exempted.component.html',
//  styleUrls: ['./tax-exempted.component.css']
//})
//export class TaxExemptedComponent {

//}
import { Component, OnInit } from '@angular/core';
import { TaxExempted } from '../../models/tax-exempted';
import { TaxExemptedService } from '../../services/tax-exempted.service';

@Component({
  selector: 'app-tax-exempted',
  templateUrl: './tax-exempted.component.html',
  styleUrls: ['./tax-exempted.component.css']
})
export class TaxExemptedComponent implements OnInit {
  taxList: TaxExempted[] = [];
  model: TaxExempted = new TaxExempted();
  isEditing: boolean = false;

  displayedColumns: string[] = [
    'taxExemptedID',
    'taxYear',
    'houseRent',
    'medical',
    'conveyance',
    'yearlyExemptedTaxAmount',
    'yearlySpecialExemptedTaxAmount',
    'approvalStatus',
    'approvedBy',
    'approvedDate',
    'employeeID',
    'actions'
  ];


  constructor(private taxService: TaxExemptedService) { }

  ngOnInit(): void {
    this.load();
  }

  load() {
    this.taxService.getAll().subscribe(data => this.taxList = data);
  }

  save() {
    if (!this.model.taxExemptedID?.trim()) {
      alert('ID must be provided');
      return;
    }

    if (this.isEditing) {
      this.taxService.update(this.model.taxExemptedID, this.model).subscribe(() => {
        this.load();
        this.reset();
      });
    } else {
      this.taxService.create(this.model).subscribe(() => {
        this.load();
        this.reset();
      });
    }
  }

  //edit(tax: TaxExempted) {
  //  this.model = { ...tax };
  //  this.isEditing = true;
  //}
  edit(t: any) {
    this.model = { ...t };

    if (this.model.approvedDate) {
      // Ensure the date is in 'yyyy-MM-dd' format
      const d = new Date(this.model.approvedDate);
      this.model.approvedDate = d.toISOString().substring(0, 10);
    }
  }

  delete(id: string) {
    if (confirm('Want to delete?')) {
      this.taxService.delete(id).subscribe(() => this.load());
    }
  }

  reset() {
    this.model = new TaxExempted();
    this.isEditing = false;
  }

  isUpdate(): boolean {
    return this.isEditing;
  }
}















//export class TaxExemptedComponent implements OnInit {

//  taxList: TaxExempted[] = [];
//  model: TaxExempted = new TaxExempted();

//  constructor(private taxService: TaxExemptedService) { }

//  ngOnInit(): void {
//    this.load();
//  }

//  load() {
//    this.taxService.getAll().subscribe(data => this.taxList = data);
//  }

//  save() {
//    if (!this.model.taxExemptedID?.trim()) {
//      alert('ID must be provided');
//      return;
//    }

//    const exists = this.taxList.find(x => x.taxExemptedID === this.model.taxExemptedID);
//    if (exists) {
//      this.taxService.update(this.model.taxExemptedID, this.model).subscribe(() => {
//        this.load();
//        this.reset();
//      });
//    } else {
//      this.taxService.create(this.model).subscribe(() => {
//        this.load();
//        this.reset();
//      });
//    }
//  }

//  edit(tax: TaxExempted) {
//    this.model = { ...tax };
//  }

//  delete(id: string) {
//    if (confirm('Want to delete?')) {
//      this.taxService.delete(id).subscribe(() => this.load());
//    }
//  }

//  reset() {
//    this.model = new TaxExempted();
//  }

//  isUpdate(): boolean {
//    return this.model.taxExemptedID?.trim() !== '' &&
//      this.taxList.some(x => x.taxExemptedID === this.model.taxExemptedID);
//  }
//}
