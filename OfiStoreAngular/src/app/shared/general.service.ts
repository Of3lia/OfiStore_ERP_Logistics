import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GeneralService {

  public readonly BaseURI: string = 'https://localhost:44369/api';

  constructor() { }
}
