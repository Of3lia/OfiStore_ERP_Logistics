import { Injectable } from '@angular/core';
import { GeneralService } from './general.service';
import { HttpClient } from "@angular/common/http";
import { ProductModel } from './models/product.model';
import { ProductCategories } from './../shared/enums/ProductCategories';

@Injectable({
  providedIn: 'root'
})
export class StoreService {

  products;

  constructor(
    private http:HttpClient,
    private generalService:GeneralService,
  ) { }

  addProductToCart(product:ProductModel, quantity:number){
    var body = {
      quantity : quantity,
      Product: {
        id : product.id
      }
    }
    return this.http.post(this.generalService.BaseURI + '/OrderProducts/PostProductInOrder', body);
  }

  getProducts(){
    return this.http.get(this.generalService.BaseURI + '/products');
  }
}