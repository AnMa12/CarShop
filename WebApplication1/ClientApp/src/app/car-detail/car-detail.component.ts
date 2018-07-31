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

  car: any;
  cart: any;

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
    this.getCart('08d5ed6f-c488-48e0-5261-92a16ed4c53f');
  }

  getCar(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.carsService.find(id).subscribe(res => this.car = res.json());
  }

  getCart(id): void {
    this.cartsService.find(id).subscribe(res => this.cart = res.json());
  }

  addToCart(): void {
      var carJSON = JSON.stringify(this.car);
      var carObj = JSON.parse(carJSON);
      
      var cartJSON = JSON.stringify(this.cart);
      var cartObj = JSON.parse(cartJSON);

      //append the new car
      cartObj.carIds.push(carObj.idCar);
      console.log(cartObj);
      cartObj.cars = JSON.stringify(cartObj.carIds);

      //update cart
      this.cartsService.update(cartObj, cartObj.idCart).subscribe(req => alert("Added in cart!"));
  }
}
