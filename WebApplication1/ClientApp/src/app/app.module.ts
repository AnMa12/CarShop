import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http';
import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';

import { AppComponent } from './app.component';

import { PaymentsService } from './services/payments.service';
import { CarsComponent } from './cars/cars.component';
import { CarsService } from './services/cars.service';
import { UserComponent } from './user/user.component';
import { CartComponent } from './cart/cart.component';
import { AppRoutingModule } from './/app-routing.module';
import { MatMenuModule, MatButtonModule, MatIconModule, MatCardModule } from '@angular/material';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatRippleModule } from '@angular/material'
import { CommonModule } from '@angular/common';
import { CartsService } from './services/cart.service';
import { LoginComponent } from './login/login.component';
import { MatFormFieldModule } from '@angular/material/form-field';

@NgModule({
  declarations: [
    AppComponent,
    CarsComponent,
    UserComponent,
    CartComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    FormsModule,
    HttpClientModule,  
    HttpModule, AppRoutingModule,
    RouterModule,
    MatMenuModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule,
    BrowserAnimationsModule,
    CommonModule,
    MatFormFieldModule
  ],
  exports: [
    MatMenuModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule,
    MatFormFieldModule
  ],
  providers: [
    PaymentsService,
    CarsService,
    CartsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

