import { OrderState } from '../enums/OrderState';
import { ProductModel } from './product.model';

export class OrderModel{
    id:number;
    products: ProductModel[];
    state: OrderState;
}