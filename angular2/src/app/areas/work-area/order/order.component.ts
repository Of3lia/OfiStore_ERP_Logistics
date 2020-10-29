import { Component, OnInit } from '@angular/core';
import { OrderService } from 'src/app/shared/order.service';
import { OrderState } from 'src/app/shared/enums/OrderState';
import { OrderModel } from 'src/app/shared/models/order.model';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styles: [
  ]
})
export class OrderComponent implements OnInit {

  constructor(
    public orderService: OrderService,
  ) { }

  ngOnInit(): void {
    this.orderService.getOrder().subscribe(
      res =>{
        this.orderService.order = res;
        try{
        this.orderService.products = this.orderService.order.orderProducts;
        } catch{}
        // console.log(this.orderService.order);
        // console.log(this.orderService.products);
        try{
          this.orderService.order.state = OrderState[this.orderService.order.state];
        } catch {}
      },
      err => {
        console.log(err);
      }
    )
   }

   assignOrderToEmployee(){
    this.orderService.assignOrderToEmployee().subscribe(
      res =>{
        this.orderService.order = res;
        window.location.reload();
      },
      err => {
        console.log(err);
        if(err.status == 404){
          window.alert("There is no orders! Wait a few minutes")
        }
      }
    )
   }

   deliverOrder(order:OrderModel){
    order.state = OrderState.Delivering;
    this.orderService.changeOrderState(order).subscribe(
      res => { 
        window.alert("Order Sended successfully!");
        window.location.reload();
      },
      err => {
        console.log(err);
      }, 
    )
  }

  finishOrder(order:OrderModel){
   order.state = OrderState.Finished;
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
}
