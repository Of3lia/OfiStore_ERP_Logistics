import { Component, OnInit } from '@angular/core';
import { CartService } from './../../../shared/cart.service'
import { OrderState } from './../../../shared/enums/OrderState'
import { StoreService } from './../../../shared/store.service';
import { ProductModel } from 'src/app/shared/models/product.model';
import { ProductCategories } from 'src/app/shared/enums/ProductCategories';
import { OrderModel } from 'src/app/shared/models/order.model';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  constructor(
    public service: CartService,
    public storeService: StoreService
  ) { }

  ngOnInit(): void {
    this.service.getOrders().subscribe(
      res =>{
        this.service.orders = res;
        try{
        this.service.products = this.service.orders[0].orderProducts;
        } catch{}
       
        this.service.orders.forEach(element => {
          element.state = OrderState[element.state];
        });
      },
      err => {
        console.log(err);
      }
    )
  }

  updateCart(product:ProductModel, quantity: number){
    this.storeService.addProductToCart(product, quantity).subscribe(
      res => { 
        window.alert("Cart Updated");
        this.service.products = res;
      },
      err => {
        console.log(err);
      }
    )
  }

  sendOrder(order:OrderModel){
    order.state = OrderState.Pending;
    this.service.sendOrder(order).subscribe(
      res => { 
        window.alert("Order Sended successfully!");
        window.location.reload();
      },
      err => {
        console.log(err);
      }
    )
  }

  cancelOrder(order:OrderModel){
    order.state = OrderState.Unrealized;
    this.service.sendOrder(order).subscribe(
      res => { 
        window.alert("Order Sended successfully!");
        window.location.reload();
      },
      err => {
        console.log(err);
      }
    )
  }

  deleteOrder(orderId: number){
    this.service.deleteOrder(orderId).subscribe(
      res => {
        window.alert("Order Deleted");
        window.location.reload();
      },
      err =>{
        console.log(err);
      }
    )
  }

  removeProduct(id: number){
    this.service.removeProduct(id).subscribe(
      res => {
        window.alert("Order Deleted");
        window.location.reload();
      },
      err =>{
        console.log(err);
      }
    )
  }
}
