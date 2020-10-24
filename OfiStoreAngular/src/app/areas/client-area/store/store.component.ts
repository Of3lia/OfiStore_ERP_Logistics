import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/shared/product.service';
import { ProductModel, ProductCategories } from './../../../shared/product.model';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styles: [
  ]
})
export class StoreComponent implements OnInit {

  listOfProducts;

  constructor(
    private service: ProductService,
  ) { }

  ngOnInit(): void {
    this.service.getProducts().subscribe(
     res => {
      this.listOfProducts = res;
      this.listOfProducts.forEach(element => {
        switch(element.category){
          case 0:
            element.category = "Toys"
            break;
          case 1:
            element.category = "Food"
            break;
          case 2:
            element.category = "Electronic"
            break;
          case 3:
            element.category = "Instruments"

            break;
          case 4:
            element.category = "Sport"
            break;
        }
      });
     },
     err =>{
       console.log(err);
     }
   ) 
  }
}
