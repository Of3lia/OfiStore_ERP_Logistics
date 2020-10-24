import { Injectable } from '@angular/core';
import {GeneralService } from './general.service'
import { HttpClient} from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class AddressService {

  constructor(
    private service:GeneralService,
    private http:HttpClient
  ) { }

  getAddress(id: number){
    return this.http.get(this.service.BaseURI + '/addresses/' + id);
  }
}
