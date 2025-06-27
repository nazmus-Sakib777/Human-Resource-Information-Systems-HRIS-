//import { Injectable } from '@angular/core';

//@Injectable({
//  providedIn: 'root'
//})
//export class TaxExemptedService {

//  constructor() { }
//}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TaxExempted } from '../models/tax-exempted';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TaxExemptedService {

  private baseUrl = 'http://localhost:19243/api/TaxExempteds'; 

  constructor(private http: HttpClient) { }

  // Get all records
  getAll(): Observable<TaxExempted[]> {
    return this.http.get<TaxExempted[]>(this.baseUrl);
  }

  // Get single record by ID
  get(id: string): Observable<TaxExempted> {
    return this.http.get<TaxExempted>(`${this.baseUrl}/${id}`);
  }

  // Create a new record
  create(data: TaxExempted): Observable<any> {
    return this.http.post(this.baseUrl, data);
  }

  // Update existing record
  update(id: string, data: TaxExempted): Observable<any> {
    return this.http.put(`${this.baseUrl}/${id}`, data);
  }

  // Delete record
  delete(id: string): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
