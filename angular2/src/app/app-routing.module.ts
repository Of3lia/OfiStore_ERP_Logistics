import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './user/login/login.component';
import { UserComponent } from './user/user.component';
import { AuthGuard } from './auth/auth.guard';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { HomeComponent } from './home/home.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { WorkAreaComponent } from './areas/work-area/work-area.component';
import { AdminAreaComponent } from './areas/admin-area/admin-area.component';
import { ClientAreaComponent } from './areas/client-area/client-area.component';
import { CartComponent } from './areas/client-area/cart/cart.component';
import { ProfileComponent } from './areas/profile/profile.component';
import { StoreComponent } from './areas/store/store.component';
import { OrderComponent } from './areas/work-area/order/order.component';
import { HistorialComponent } from './areas/work-area/historial/historial.component';

const routes: Routes = [
  {path:'',redirectTo:'/home/store', pathMatch:'full'},
 
   {path:'home',component:HomeComponent, children:[
     {path:'registration',component:RegistrationComponent}, //registration
     {path:'login',component:LoginComponent}, //user/login 
     {path:'store',component:StoreComponent},
     {path:'profile',component:ProfileComponent, canActivate:[AuthGuard]},
     {path:'client-area',component:ClientAreaComponent, canActivate:[AuthGuard], children:[
       {path:'cart', component:CartComponent}
     ]},
     {path:'work-area',component:WorkAreaComponent, canActivate:[AuthGuard], children:[
       {path:'order', component:OrderComponent},
       {path:'historial', component:HistorialComponent}
     ]},
     {path:'admin-area',component:AdminAreaComponent, canActivate:[AuthGuard], data : {permittedRoles: ['Admin']}}
   ]},
  {path:'forbidden',component:ForbiddenComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
