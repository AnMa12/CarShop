import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CarsComponent } from './cars/cars.component';
import { CartComponent } from './cart/cart.component';
import { UserComponent } from './user/user.component';

const routes: Routes = [
  { path: 'cars', component: CarsComponent },
  { path: 'cart', component: CartComponent },
  { path: 'user', component: UserComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})

export class AppRoutingModule { }
