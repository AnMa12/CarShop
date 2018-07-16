import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http';
import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';
import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';

import { PaymentsService } from './services/payments.service';
import { CarsComponent } from './cars/cars.component';
import { CarsService } from './services/cars.service';
import { CartComponent } from './cart/cart.component';
import { AppRoutingModule } from './/app-routing.module';
import { MatMenuModule, MatButtonModule, MatIconModule, MatCardModule } from '@angular/material';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatRippleModule } from '@angular/material'
import { CommonModule } from '@angular/common';
import { CartsService } from './services/cart.service';
import { MatFormFieldModule } from '@angular/material/form-field';
import { UserService } from './shared/user.service';
import { UserComponent } from './user/user.component';
import { SignInComponent } from './user/sign-in/sign-in.component';
import { SignUpComponent } from './user/sign-up/sign-up.component';

@NgModule({
  declarations: [
    AppComponent,
    CarsComponent,
    CartComponent,
    SignUpComponent,
    UserComponent,
    SignInComponent
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
    MatFormFieldModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule
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
    CartsService,
    UserService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

