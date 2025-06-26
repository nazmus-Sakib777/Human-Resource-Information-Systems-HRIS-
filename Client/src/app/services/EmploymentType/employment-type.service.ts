import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EmploymentType } from 'src/app/models/employment-type/employment-type';

@Injectable({
  providedIn: 'root'
})
export class EmploymentTypeService {
  private apiUrl = 'http://localhost:19243/api/EmploymentTypes';

  constructor(private http: HttpClient) {}

  getAll(): Observable<EmploymentType[]> {
    return this.http.get<EmploymentType[]>(this.apiUrl);
  }

  create(data: EmploymentType): Observable<EmploymentType> {
    return this.http.post<EmploymentType>(this.apiUrl, data);
  }

  update(id: string, data: EmploymentType): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, data);
  }

  delete(id: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
