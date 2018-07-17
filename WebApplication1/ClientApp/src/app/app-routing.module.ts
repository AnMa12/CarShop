import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CarsComponent } from './cars/cars.component';
import { CartComponent } from './cart/cart.component';
import { UserComponent } from './user/user.component';
import { SignUpComponent } from './user/sign-up/sign-up.component';
import { SignInComponent } from './user/sign-in/sign-in.component';
import { CarDetailComponent } from './car-detail/car-detail.component';

const routes: Routes = [
  { path: '', redirectTo: '/cars', pathMatch: 'full' },
  { path: 'cars', component: CarsComponent },
  { path: 'cart', component: CartComponent },
  { path: 'detail/:id', component: CarDetailComponent },
  { path: 'user', component: UserComponent },
  {
    path: 'signup', component: UserComponent,
    children: [{ path: '', component: SignUpComponent }]
  },
  {
    path: 'login', component: UserComponent,
    children: [{ path: '', component: SignInComponent }]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})

export class AppRoutingModule {

}
