import { Component, OnInit } from '@angular/core';
import { CarsService } from '../services/cars.service';
import { CartsService } from '../services/cart.service';

@Component({
  selector: 'app-cars',
  templateUrl: './cars.component.html',
  styleUrls: ['./cars.component.css']
})
export class CarsComponent implements OnInit {

  carsArray: any = [];
  cart: any = {};

  constructor(private carsService: CarsService, private cartsService: CartsService) {
    carsService.query().subscribe(res => this.carsArray = res.json());
  }

  addToCart(car): void {
    //we need to have one cart per customer add the car object into Carts TABLE
    this.cartsService.create(this.cart).subscribe(req => alert("Added in cart!"));
  }

  ngOnInit() {
  }

}
