import { Component, OnInit } from '@angular/core';
import { PaymentsService } from '../services/payments.service';

@Component({
  selector: 'app-cars',
  templateUrl: './cars.component.html',
  styleUrls: ['./cars.component.css']
})
export class CarsComponent implements OnInit {

  paymentsArray: any = [];

  constructor(private paymentsService: PaymentsService) {
    paymentsService.query().subscribe(res => this.paymentsArray = res.json());
  }

  ngOnInit() {
  }

}
