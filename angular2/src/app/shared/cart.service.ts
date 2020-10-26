import { Injectable } from '@angular/core';
import { GeneralService } from './general.service';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { OrderModel } from 'src/app/shared/models/order.model';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  orders;
  products;

  constructor(
    public generalService: GeneralService,
    private http: HttpClient,
  ) { }

  getOrders(){
    return this.http.get(this.generalService.BaseURI + '/Orders/GetOrderByClient');
  }

  sendOrder(order: OrderModel){
    var body = { 
      id: order.id,
      state: order.state
    };
    return this.http.put(this.generalService.BaseURI + '/Orders/ChangeOrderState', body);
  }

  deleteOrder(orderId: number){
    var body = { id: orderId}
    return this.http.post(this.generalService.BaseURI + '/Orders/DeleteOrder', body)
  }

   removeProduct(productId: number){
    var body = { id: productId}
    return this.http.post(this.generalService.BaseURI + '/OrderProducts/RemoveProduct', body)
  }
}
