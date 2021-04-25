import { Component, OnInit } from '@angular/core';
import { ProductService } from './../../shared/product.service';
import { ProductCategories } from './../../shared/enums/ProductCategories';
import { ProductModel } from 'src/app/shared/models/product.model';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styleUrls: ['./store.component.css']
})
export class StoreComponent implements OnInit {

  constructor(
    private router:Router,
    public productService: ProductService,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    console.log(this.productService.products);
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

    if(localStorage.getItem('token') == null){
      window.location.replace("/home/login");
    }
    else{
    // We convert quantity in negative numbers so the API knows that it was to add the quantity to the existing one instead of assign a new quantity
      quantity = -quantity;
      this.productService.addProductToCart(product, quantity).subscribe(
        res => { 
          this.toastr.success(Math.abs(quantity) + ' ' + product.name + " added to the cart", "Cart");
        },
        err => {
          console.log(err);
        }
      )
    }
  }

  navigateToLogin(){
    this.router.navigate(['/user/login']);
  }

  navigateToRegister(){
    this.router.navigate(['/user/registration']);
  }

  navigateToCart(){
    this.router.navigate(['/home/client-area']);
  }
}
