import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AttendanceRecord } from '../models/attendance-record';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http: HttpClient) { }
  getAttendanceRecords(): Observable<AttendanceRecord[]> {
    return this.http.get<AttendanceRecord[]>("http://localhost:19243/api/AttendanceRecords");
  }
}
