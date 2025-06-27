
import { Component, OnInit } from '@angular/core';
import { TaxAmount } from 'src/app/models/tax-amount';
import { TaxAmountService } from 'src/app/services/tax-amount.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit {
  taxList: TaxAmount[] = [];

  displayedColumns: string[] = [
    'index',
    'taxYear',
    'taxAmountValue',
    'taxType',
    'status',
    'approvedDate',
    'remarks',
    'entryUser',
    'employeeID',
    'employeeName',
    'actions'
  ];


  constructor(private service: TaxAmountService, private router: Router) { }

  ngOnInit(): void {
    this.loadList();
  }

  loadList() {
    this.service.getAll().subscribe(data => this.taxList = data);
  }

  edit(id: string) {
    this.router.navigate(['/tax/edit', id]);
  }

  delete(id: string) {
    if (confirm('Are you sure you want to delete this record?')) {
      this.service.delete(id).subscribe(() => this.loadList());
    }
  }

}



//import { Component } from '@angular/core';

//@Component({
//  selector: 'app-view',
//  templateUrl: './view.component.html',
//  styleUrls: ['./view.component.css']
//})
//export class ViewComponent {

//}
