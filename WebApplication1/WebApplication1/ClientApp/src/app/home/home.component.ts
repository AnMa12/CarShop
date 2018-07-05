import { Component } from '@angular/core';
import { PlatiService } from '../services/plati.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent {

  listaPlati: any = [];

  constructor(private platiService: PlatiService) {
    platiService.query().subscribe(res => this.listaPlati = res.json());
  }




}
