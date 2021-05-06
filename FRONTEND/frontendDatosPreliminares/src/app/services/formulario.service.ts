import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class FormularioService {

  private miAppUrl = 'https://localhost:44323/';
  private miApiUrl = 'api/FniSolicitudInicial/';

  constructor(private http: HttpClient) 
  { }

  getValidacionCorreoElectronico(correo: string)
  {
    return this.http.get(this.miAppUrl + this.miApiUrl + correo);
  }
}
