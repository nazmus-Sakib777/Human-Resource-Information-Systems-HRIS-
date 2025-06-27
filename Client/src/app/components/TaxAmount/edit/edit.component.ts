//import { Component } from '@angular/core';

//@Component({
//  selector: 'app-edit',
//  templateUrl: './edit.component.html',
//  styleUrls: ['./edit.component.css']
//})
//export class EditComponent {

//}


import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TaxAmount } from 'src/app/models/tax-amount';
import { TaxAmountService } from 'src/app/services/tax-amount.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  model = new TaxAmount();

  constructor(
    private route: ActivatedRoute,
    private service: TaxAmountService,
    private router: Router
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.service.getById(id).subscribe(data => {
        this.model = data;
      });
    }
  }

  update() {
    this.service.update(this.model.taxAmountID, this.model).subscribe(() => {
      this.router.navigate(['/tax/view']);
    });
  }

  onSubmit() {
    this.service.update(this.model.taxAmountID, this.model).subscribe(() => {
      this.router.navigate(['/tax/view']);
    });
  }
}

