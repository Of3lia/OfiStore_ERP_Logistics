import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { GeneralService } from './general.service';
import { OrderModel } from './models/order.model';

@Injectable({
  providedIn: 'root'
})
export class WorkAreaService {
  order;
  products;

  constructor(
    private generalService: GeneralService,
    private http: HttpClient,
  ) { }

  getOrder(){
    return this.http.get(this.generalService.BaseURI + '/Orders/GetOrderByEmployee');
  }

  assignOrderToEmplotee(){
    return this.http.get(this.generalService.BaseURI + '/Orders/AssignOrderToEmployee');
  }
}
