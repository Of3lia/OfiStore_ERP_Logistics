export class UserModel{
    id:string = '';
    userName: string = '';
    fullName?: string = '';
    email?:string = '';
    address: AddressModel = {
      id : '',
      street : '',
      streetNumber : undefined,
      door : '',
      city : '',
      country : '',
      postalCode : '',
    };
  }
  
export class AddressModel{
    id:string = '';
    street?: string = '';
    streetNumber?: number = undefined;
    door?:string = '';
    city?:string = '';
    country?:string = '';
    postalCode?:string = '';
  }