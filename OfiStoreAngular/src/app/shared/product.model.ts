export class ProductModel{
    id: number;
    name: Text;
    description: Text;
    price: number;
    category: ProductCategories;
}

export enum ProductCategories{
    Toys, Food, Electronic, Instruments, Sports
}