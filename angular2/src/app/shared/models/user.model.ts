import { AddressModel } from './address.model';
import { UserRoles } from './../enums/UserRoles';
export class UserModel{
    id:string = '';
    userName: string = '';
    fullName?: string = '';
    email?:string = '';
    address:AddressModel;
    role: UserRoles;
  }