import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SalaryDeduction } from '../models/salary-deduction';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SalaryDeductionService {

  private apiUrl = 'http://localhost:19243/api/Salary/SalaryDeduction';

  constructor(private http:HttpClient) { }

  getAll(): Observable<SalaryDeduction[]> {
    return this.http.get<SalaryDeduction[]>(this.apiUrl);
  }

    create(data: SalaryDeduction): Observable<SalaryDeduction> {
    return this.http.post<SalaryDeduction>(this.apiUrl, data);
  }

    update(id: string, data: SalaryDeduction): Observable<SalaryDeduction> {
    return this.http.put<SalaryDeduction>(`${this.apiUrl}${id}`, data);
  }

    delete(id: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}${id}`);
  }
}
