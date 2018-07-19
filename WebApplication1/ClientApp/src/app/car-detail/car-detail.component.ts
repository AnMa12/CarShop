import { Component, OnInit } from '@angular/core';

import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { CarService } from '../services/car.service';
import { CartsService } from '../services/cart.service';
import { Cart } from '../models/cart.model';
import { Car } from '../models/car.model';

@Component({
  selector: 'app-car-detail',
  templateUrl: './car-detail.component.html',
  styleUrls: ['./car-detail.component.css']
})
export class CarDetailComponent implements OnInit {

  car: Car;
  cart: Cart;

  constructor(
    /*The ActivatedRoute holds information about the route to this instance of
     * the HeroDetailComponent. This component is interested in the route's bag
     * of parameters extracted from the URL. The "id" parameter is the id of the hero to display.*/
    private route: ActivatedRoute,
    private carsService: CarService,
    /*The location is an Angular service for interacting with the browser.
     * You'll use it later to navigate back to the view that navigated here.*/
    private location: Location,
    private cartsService: CartsService
  ) { }

  ngOnInit() {
    this.getCar();
  }

  getCar(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.carsService.find(id).subscribe(res => this.car = res.json());
  }

  getCart(id): void {
    this.cartsService.find(id).subscribe(res => this.cart = res.json());
  }

  addToCart(carAdded): void {
    //get the cart in cart object
    this.getCart('08d5ed4c-1a62-f1aa-8683-5c7918d4b615');

    //alert test 1
    alert(JSON.stringify(this.car));
    //alert test 2
    alert(this.cart.IdCart);

    //append the new car
    this.cart.Car.push(carAdded);
    debugger;

    //update the cart
    this.cartsService.update(this.cart).subscribe(req => alert("Added in cart!"));
  }
}
