import { Component, OnInit } from '@angular/core';
import { WorkAreaService } from 'src/app/shared/work-area.service';
import { CartService } from 'src/app/shared/cart.service';
import { OrderState } from 'src/app/shared/enums/OrderState';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styles: [
  ]
})
export class OrderComponent implements OnInit {

  constructor(
    public service: WorkAreaService,
    public cartService: CartService,
  ) { }

  ngOnInit(): void {
    this.service.getOrder().subscribe(
      res =>{
        this.service.order = res;
        try{
        this.service.products = this.service.order.orderProducts;
        } catch{}
        console.log(this.service.order);
        console.log(this.service.products);
        try{
          this.service.order.state = OrderState[this.service.order.state];
        } catch {}
      },
      err => {
        console.log(err);
      }
    )
   }

   assignOrderToEmployee(){
    this.service.assignOrderToEmplotee().subscribe(
      res =>{
        this.service.order = res;
        window.location.reload();
      },
      err => {
        console.log(err);
      }
    )
   }

   cancelOrder(){
    this.service.order.state = OrderState.Pending;
    this.storeService.sendOrder(order).subscribe(
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
