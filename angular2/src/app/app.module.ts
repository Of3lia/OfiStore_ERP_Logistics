import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms'
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

import {ToastrModule } from 'ngx-toastr';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { UserService } from './shared/user.service';
import { LoginComponent } from './user/login/login.component';
import { HomeComponent } from './home/home.component';
import { AuthInterceptor } from './auth/auth.interceptor';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { ClientAreaComponent } from './areas/client-area/client-area.component';
import { WorkAreaComponent } from './areas/work-area/work-area.component';
import { AdminAreaComponent } from './areas/admin-area/admin-area.component';
import { CartComponent } from './areas/client-area/cart/cart.component';
import { ProfileComponent } from './areas/profile/profile.component';
import { AddressComponent } from './areas/profile/address/address.component';
import { StoreComponent } from './areas/store/store.component';
import { HistorialComponent } from './areas/work-area/historial/historial.component';
import { OrderComponent } from './areas/work-area/order/order.component';
import { AllUsersComponent } from './areas/admin-area/all-users/all-users.component';
import { LineChartComponent } from './areas/admin-area/line-chart/line-chart.component';
import { ChartsModule } from 'ng2-charts';

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    RegistrationComponent,
    LoginComponent,
    HomeComponent,
    ForbiddenComponent,
    ClientAreaComponent,
    WorkAreaComponent,
    AdminAreaComponent,
    CartComponent,
    ProfileComponent,
    AddressComponent,
    StoreComponent,
    HistorialComponent,
    OrderComponent,
    AllUsersComponent,
    LineChartComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    ChartsModule,
  ],
  providers: [
    UserService, {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
    }],
  bootstrap: [AppComponent]
})
export class AppModule { }
