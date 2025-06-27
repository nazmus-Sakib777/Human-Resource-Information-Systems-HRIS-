import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Salarygrade } from '../models/salarygrade';

@Injectable({
  providedIn: 'root'
})
export class SalarygradeService {
  private apiUrl = "http://localhost:19243/api/Salary/salaryGrade";

  constructor(private http: HttpClient) { }

  getSalarygrade(): Observable<Salarygrade[]> {
    return this.http.get<Salarygrade[]>(this.apiUrl);
  }

  getSalarygradeById(id: string): Observable<Salarygrade> {
    return this.http.get<Salarygrade>(`${this.apiUrl}/${id}`);
  }

  addSalaryGrade(data: Salarygrade): Observable<Salarygrade> {
    return this.http.post<Salarygrade>(this.apiUrl, data);
  }

  updateSalaryGrade(data: Salarygrade): Observable<Salarygrade> {
    return this.http.put<Salarygrade>(`${this.apiUrl}/${data.salaryGradeID}`, data);
  }

  deleteSalaryGrade(id: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
