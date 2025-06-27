//import { Component } from '@angular/core';

//@Component({
//  selector: 'app-create',
//  templateUrl: './create.component.html',
//  styleUrls: ['./create.component.css']
//})
//export class CreateComponent {

//}


import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { TaxAmount } from 'src/app/models/tax-amount';
import { TaxAmountService } from 'src/app/services/tax-amount.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent {
  model = new TaxAmount();

  constructor(private service: TaxAmountService, private router: Router) { }

  save() {
    this.service.create(this.model).subscribe(() => {
      this.router.navigate(['/tax/view']);
    });
  }

  onSubmit() {
    this.service.create(this.model).subscribe(() => {
      this.router.navigate(['/tax/view']);
    });
  }
}

