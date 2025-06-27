

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AttendanceRecord } from '../models/attendance-record';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AttendanceRecordService {
  private apiUrl = 'http://localhost:19243/api/AttendanceRecords';

  constructor(private http: HttpClient) { }

  getAll(): Observable<AttendanceRecord[]> {
    return this.http.get<AttendanceRecord[]>(this.apiUrl);
  }

  getById(id: string): Observable<AttendanceRecord> {
    return this.http.get<AttendanceRecord>(`${this.apiUrl}/${id}`);
  }

  create(record: AttendanceRecord): Observable<any> {
    return this.http.post(this.apiUrl, record);
  }

  update(id: string, data: AttendanceRecord): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, data);
  }

  delete(id: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}

