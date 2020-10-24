import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GeneralService } from './general.service';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(
    private http: HttpClient,
    private generalService:GeneralService
  ) { }

  getProducts(){
    return this.http.get( this.generalService.BaseURI + '/products');
  }
}
