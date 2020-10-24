import { AddressModel } from './address.model';

export class UserModel{
    id:string = '';
    userName: string = '';
    fullName?: string = '';
    email?:string = '';
    address:AddressModel;
  }