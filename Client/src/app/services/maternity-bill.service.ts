import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MaternityBill } from '../models/maternity-bill';
import { Observable } from 'rxjs';

const apiUrl ='http://localhost:19243/api/Maternity';
@Injectable({
  providedIn: 'root'
})
export class MaternityBillService {

  constructor(private http: HttpClient) { }

   getAll(): Observable<MaternityBill[]>{
      return this.http.get<MaternityBill[]>(apiUrl);
    }

    create(data: MaternityBill): Observable<MaternityBill> {
        return this.http.post<MaternityBill>(apiUrl + '/Create', data);
      }
}
