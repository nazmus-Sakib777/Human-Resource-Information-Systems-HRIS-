import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SpecialEmployee } from 'src/app/models/specialEmployee/special-employee'; // Adjust the import path as necessary

@Injectable({ providedIn: 'root' })
export class SpecialEmployeeService {
  private apiUrl = 'http://localhost:19243/api/SpecialEmployees';

  constructor(private http: HttpClient) {}

  getAll(): Observable<SpecialEmployee[]> {
    return this.http.get<SpecialEmployee[]>(this.apiUrl);
  }

  create(data: SpecialEmployee): Observable<SpecialEmployee> {
    return this.http.post<SpecialEmployee>(this.apiUrl, data);
  }

  update(id: string, data: SpecialEmployee): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, data);
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}