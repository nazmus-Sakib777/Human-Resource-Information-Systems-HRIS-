import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SalaryRecord } from '../models/salary-record';

@Injectable({
  providedIn: 'root'
})
export class SalaryRecordService {

 private apiUrl = 'http://localhost:19243/api/Salary/SalaryRecord';
 
   constructor(private http:HttpClient) { }
 
   getAll(): Observable<SalaryRecord[]> {
     return this.http.get<SalaryRecord[]>(this.apiUrl);
   }
 
     create(data: SalaryRecord): Observable<SalaryRecord> {
     return this.http.post<SalaryRecord>(this.apiUrl, data);
   }
 
     update(id: string, data: SalaryRecord): Observable<SalaryRecord> {
     return this.http.put<SalaryRecord>(`${this.apiUrl}${id}`, data);
   }
 
     delete(id: string): Observable<any> {
     return this.http.delete(`${this.apiUrl}${id}`);
   }
}
