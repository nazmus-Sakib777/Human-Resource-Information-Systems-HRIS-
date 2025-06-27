import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LeaveRecord } from '../models/leave-record';

const apiUrl = 'http://localhost:19243/api/LeaveRecord';
@Injectable({
  providedIn: 'root'
})
export class LeaveRecordService {

  constructor(private http: HttpClient) { }
  getAll(): Observable<LeaveRecord[]> {
    return this.http.get<LeaveRecord[]>(apiUrl);
  }

  create(data: LeaveRecord): Observable<LeaveRecord> {
    return this.http.post<LeaveRecord>(apiUrl + '/Create', data);
  }

  update(id: string, data: LeaveRecord): Observable<LeaveRecord> {
    return this.http.put<LeaveRecord>(apiUrl + '/Update/' + id, data);
  }

}
