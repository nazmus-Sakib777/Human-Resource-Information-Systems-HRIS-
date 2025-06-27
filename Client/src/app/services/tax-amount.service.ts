//import { Injectable } from '@angular/core';

//@Injectable({
//  providedIn: 'root'
//})
//export class TaxAmountService {

//  constructor() { }
//}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TaxAmount } from '../models/tax-amount';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TaxAmountService {
  private apiUrl = 'http://localhost:19243/api/TaxAmounts'; // 🔁 API URL 

  constructor(private http: HttpClient) { }

  getAll(): Observable<TaxAmount[]> {
    return this.http.get<TaxAmount[]>(`${this.apiUrl}`);
  }

  getById(id: string): Observable<TaxAmount> {
    return this.http.get<TaxAmount>(`${this.apiUrl}/${id}`);
  }

  create(data: TaxAmount): Observable<TaxAmount> {
    return this.http.post<TaxAmount>(`${this.apiUrl}`, data);
  }

  update(id: string, data: TaxAmount): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, data);
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
