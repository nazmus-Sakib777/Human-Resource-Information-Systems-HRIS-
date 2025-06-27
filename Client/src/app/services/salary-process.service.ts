import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SalaryProcess } from '../models/salary-process';

@Injectable({
  providedIn: 'root'
})
export class SalaryProcessService {

  private apiUrl = 'http://localhost:19243/api/Salary/SalaryProcess';
  
    constructor(private http:HttpClient) { }
  
    getAll(): Observable<SalaryProcess[]> {
      return this.http.get<SalaryProcess[]>(this.apiUrl);
    }
  
      create(data: SalaryProcess): Observable<SalaryProcess> {
      return this.http.post<SalaryProcess>(this.apiUrl, data);
    }
  
      update(id: string, data: SalaryProcess): Observable<SalaryProcess> {
      return this.http.put<SalaryProcess>(`${this.apiUrl}${id}`, data);
    }
  
      delete(id: string): Observable<any> {
      return this.http.delete(`${this.apiUrl}${id}`);
    }
}
