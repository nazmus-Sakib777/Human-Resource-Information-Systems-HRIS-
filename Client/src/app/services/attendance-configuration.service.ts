//import { Injectable } from '@angular/core';

//@Injectable({
//  providedIn: 'root'
//})
//export class AttendanceConfigurationService {

//  constructor() { }
//}

// attendance-configuration.service.ts
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AttendanceConfiguration } from '../models/attendance-configuration';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AttendanceConfigurationService {
  private apiUrl = 'http://localhost:19243/api/AttendanceConfigurations';

  constructor(private http: HttpClient) { }

  getAll(): Observable<AttendanceConfiguration[]> {
    return this.http.get<AttendanceConfiguration[]>(this.apiUrl);
  }

  getById(id: string): Observable<AttendanceConfiguration> {
    return this.http.get<AttendanceConfiguration>(`${this.apiUrl}/${id}`);
  }

  create(data: AttendanceConfiguration): Observable<AttendanceConfiguration> {
    return this.http.post<AttendanceConfiguration>(this.apiUrl, data);
  }

  update(id: string, data: AttendanceConfiguration): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, data);
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

