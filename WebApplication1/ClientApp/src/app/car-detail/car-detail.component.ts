import { Component, OnInit } from '@angular/core';

import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { CarsService } from '../services/cars.service';

@Component({
  selector: 'app-car-detail',
  templateUrl: './car-detail.component.html',
  styleUrls: ['./car-detail.component.css']
})
export class CarDetailComponent implements OnInit {

  car: any;

  constructor(
    private route: ActivatedRoute,
    private carsService: CarsService,
    private location: Location
  ) { }

  ngOnInit() {
    this.getCar();
  }

  getCar(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.carsService.getCar(id)
      .subscribe(car => this.car = car)
  }

}
