import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { GeneralService } from './general.service';
import { OrderModel } from './../shared/models/order.model';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  order;
  orders;
  products;
  constructor(
    public generalService: GeneralService,
    private http: HttpClient,
  ) { }

  getOrders(){
    return this.http.get(this.generalService.BaseURI + '/Orders/GetOrderByClient');
  }

  changeOrderState(order: OrderModel){
    var body = { 
      id: order.id,
      state: order.state
    };
    return this.http.put(this.generalService.BaseURI + '/Orders/ChangeOrderState', body);
  }

  deleteOrder(orderId: number){
    return this.http.delete(this.generalService.BaseURI + '/Orders/' + orderId)
  }

  // Work-Area
  getOrder(){
    return this.http.get(this.generalService.BaseURI + '/Orders/GetOrderByEmployee');
  }

  assignOrderToEmployee(){
    return this.http.get(this.generalService.BaseURI + '/Orders/AssignOrderToEmployee');
  }

  getOrderHistorialEmployee(){
    return this.http.get(this.generalService.BaseURI + '/Orders/GetOrderHistorialEmployee');
  }

  getOrdersByAdmin(){
    return this.http.get(this.generalService.BaseURI + '/Orders/GetOrdersByAdmin');
  }
}
