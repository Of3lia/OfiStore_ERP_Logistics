import { Component, OnInit } from '@angular/core';
import { ProductService } from './../../shared/product.service';
import { ProductCategories } from './../../shared/enums/ProductCategories';
import { ProductModel } from 'src/app/shared/models/product.model';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styleUrls: ['./store.component.css']
})
export class StoreComponent implements OnInit {

  constructor(
    public productService: ProductService
  ) { }

  ngOnInit(): void {
    this.productService.getProducts().subscribe(
      res => { 
        // Product Data:
        this.productService.products = res;

        // Enum Category
        this.productService.products.forEach(element => {
          element.categoryString = ProductCategories[element.category];
        });
      },
      err => {
        console.log(err);
      }
    )
  }

  addProductToCart(product:ProductModel, quantity: number){
    // We convert quantity in negative numbers so the API knows that it was to add the quantity to the existing one instead of assign a new quantity
    quantity = -quantity;
    this.productService.addProductToCart(product, quantity).subscribe(
      res => { 
        window.alert("Added product to the cart");
      },
      err => {
        console.log(err);
      }
    )
  }
}
