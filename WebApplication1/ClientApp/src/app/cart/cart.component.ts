import { Component, OnInit } from '@angular/core';
import { CartsService } from '../services/cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  cartArray: any = [];

  constructor(private cartsService: CartsService) {
    cartsService.query().subscribe(res => this.cartArray = res.json());
  }

  ngOnInit() {
  }

}
