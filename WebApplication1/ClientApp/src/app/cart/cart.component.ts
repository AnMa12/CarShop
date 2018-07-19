import { Component, OnInit } from '@angular/core';
import { CartsService } from '../services/cart.service';
import { Cart } from '../models/cart.model';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  cart: Cart;

  constructor(private cartsService: CartsService) {
    cartsService.query().subscribe(res => this.cart = res.json());
  }

  ngOnInit() {
  }

}
