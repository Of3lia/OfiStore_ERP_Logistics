import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { GeneralService } from './general.service';
import { ProductModel } from './models/product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  products; 
  
  constructor(
    public generalService: GeneralService,
    private http: HttpClient,
  ) { }

  removeProduct(orderProductId: number){
    return this.http.delete(this.generalService.BaseURI + '/OrderProducts/' + orderProductId)
  }

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
