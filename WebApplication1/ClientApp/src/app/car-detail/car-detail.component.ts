import { Component, OnInit } from '@angular/core';

import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { CarService } from '../services/car.service';

@Component({
  selector: 'app-car-detail',
  templateUrl: './car-detail.component.html',
  styleUrls: ['./car-detail.component.css']
})
export class CarDetailComponent implements OnInit {

  car: any;

  constructor(
    /*The ActivatedRoute holds information about the route to this instance of
   * the HeroDetailComponent. This component is interested in the route's bag
   * of parameters extracted from the URL. The "id" parameter is the id of the hero to display.*/
    private route: ActivatedRoute,
    /*The HeroService gets hero data from the remote server and this
     * component will use it to get the hero-to-display.*/
    private carsService: CarService,
    /*The location is an Angular service for interacting with the browser.
     * You'll use it later to navigate back to the view that navigated here.*/
    private location: Location
  ) { }

  ngOnInit() {
    this.getCar();
  }

  getCar(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.carsService.find(id).subscribe(res => this.car = res.json());
  }

}
