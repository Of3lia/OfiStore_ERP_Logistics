import { ProductCategories } from "../enums/ProductCategories";

export class ProductModel{
    id:number;
    name:string;
    description:string;
    price:number;
    category:ProductCategories;
}