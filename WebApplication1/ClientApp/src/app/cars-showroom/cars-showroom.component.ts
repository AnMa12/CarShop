import { Component, OnInit } from '@angular/core';
import { CarService } from '../services/car.service';

@Component({
  selector: 'app-cars-showroom',
  templateUrl: './cars-showroom.component.html',
  styleUrls: ['./cars-showroom.component.css']
})
export class CarsShowroomComponent implements OnInit {

  carsArray: any = [];

  constructor(private carsService: CarService) {
    carsService.query().subscribe(res => this.carsArray = res.json());
  }

  ngOnInit() {
  }

}
