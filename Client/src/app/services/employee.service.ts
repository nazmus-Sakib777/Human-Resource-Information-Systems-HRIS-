import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { EmployeeInformation } from '../models/employee.model';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class EmployeeService {
  private apiUrl = '/api/EmployeeInformations';

  constructor(private http: HttpClient) { }

  getEmployees(): Observable<EmployeeInformation[]> {
    return this.http.get<EmployeeInformation[]>(this.apiUrl);
  }

  //getEmployee(id: string): Observable<EmployeeInformation> {
  //  return this.http.get<EmployeeInformation>(`${this.apiUrl}/${id}`);
  //}

  addEmployee(employee: EmployeeInformation): Observable<EmployeeInformation> {
    return this.http.post<EmployeeInformation>(this.apiUrl, employee);
  }

  getEmployee(id: string): Observable<EmployeeInformation> {
    return this.http.get<EmployeeInformation>(`${this.apiUrl}/${id}`);
  }

  updateEmployee(employee: EmployeeInformation): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${employee.EmployeeID}`, employee);
  }

  deleteEmployee(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }


  //updateEmployee(employee: EmployeeInformation): Observable<void> {
  //  return this.http.put<void>(`${this.apiUrl}/${employee.EmployeeID}`, employee);
  //}

  //deleteEmployee(id: string): Observable<void> {
  //  return this.http.delete<void>(`${this.apiUrl}/${id}`);
  //}

}
