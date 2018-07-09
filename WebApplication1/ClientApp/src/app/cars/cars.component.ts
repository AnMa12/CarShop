import { Component, OnInit } from '@angular/core';
import { CarsService } from '../services/cars.service';

@Component({
  selector: 'app-cars',
  templateUrl: './cars.component.html',
  styleUrls: ['./cars.component.css']
})
export class CarsComponent implements OnInit {

  carsArray: any = [];

  addToCart(item): void {
    alert(item);
  }

  constructor(private carsService: CarsService) {
    carsService.query().subscribe(res => this.carsArray = res.json());
  }

  ngOnInit() {
  }

}
