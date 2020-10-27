import { Component, OnInit } from '@angular/core';
import { OrderState } from './../../../shared/enums/OrderState'
import { OrderService } from './../../../shared/order.service';
import { ProductService } from './../../../shared/product.service';
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
    public orderService: OrderService,
    public productService: ProductService,
  ) { }

  ngOnInit(): void {
    this.orderService.getOrders().subscribe(
      res =>{
        this.orderService.orders = res;
        try{
        this.orderService.products = this.orderService.orders[0].orderProducts;
        } catch{}
       
        this.orderService.orders.forEach(element => {
          element.state = OrderState[element.state];
        });
      },
      err => {
        console.log(err);
      }
    )
  }

  updateCart(product:ProductModel, quantity: number){
    this.productService.addProductToCart(product, quantity).subscribe(
      res => { 
        window.alert("Cart Updated");
        this.orderService.products = res;
      },
      err => {
        console.log(err);
      }
    )
  }

  sendOrder(order:OrderModel){
    order.state = OrderState.Pending;
    this.orderService.changeOrderState(order).subscribe(
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
    this.orderService.changeOrderState(order).subscribe(
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
    this.orderService.deleteOrder(orderId).subscribe(
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
    this.productService.removeProduct(id).subscribe(
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
