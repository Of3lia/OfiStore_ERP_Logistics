import { Component, OnInit } from '@angular/core';
import { OrderService } from './../../../shared/order.service'
import { OrderModel } from 'src/app/shared/models/order.model';
import { OrderState } from 'src/app/shared/enums/OrderState';

@Component({
  selector: 'app-historial',
  templateUrl: './historial.component.html',
  styles: [
  ]
})
export class HistorialComponent implements OnInit {

  orders;

  constructor(
    public orderService: OrderService,

  ) { }

  ngOnInit(): void {
    this.getOrderHistorial();
  }

  getOrderHistorial(){
    this.orderService.getOrderHistorialEmployee().subscribe(
      res =>{
        this.orders = res;
        console.log(this.orders);
      },
      err => {
        console.log(err);
      }
    )
  }
}
