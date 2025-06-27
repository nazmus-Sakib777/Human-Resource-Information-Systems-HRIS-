import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SalaryEntry } from '../models/salary-entry';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SalaryEntryService {

private apiUrl = 'http://localhost:19243/api/Salary/SalaryEntry';

  constructor(private http:HttpClient) { }

  getAll(): Observable<SalaryEntry[]> {
    return this.http.get<SalaryEntry[]>(this.apiUrl);
  }

    create(data: SalaryEntry): Observable<SalaryEntry> {
    return this.http.post<SalaryEntry>(this.apiUrl, data);
  }

    update(id: string, data: SalaryEntry): Observable<SalaryEntry> {
    return this.http.put<SalaryEntry>(`${this.apiUrl}${id}`, data);
  }

    delete(id: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}${id}`);
  }
}
