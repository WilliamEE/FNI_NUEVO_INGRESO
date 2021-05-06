import { HttpClientModule } from '@angular/common/http';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CarreraService {

  private miAppUrl = 'https://localhost:44323/';
  private miApiUrl = 'api/Niveles';
  constructor( private http: HttpClient) 
  { 

  }

  getNiveles()
  {
    return this.http.get(this.miAppUrl + this.miApiUrl);
  }


}
