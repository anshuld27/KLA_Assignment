import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class BackendService {
  private apiUrl = 'https://localhost:7205/api/ConvertCurrency'; 
  
  constructor(private http: HttpClient) { }

  convertCurrency(amount: string) : Observable<any>{
    const requestOptions: Object = {
      responseType: 'text'
    }
    return this.http.get<any>(`${this.apiUrl}/${amount}`, requestOptions);
  }
}