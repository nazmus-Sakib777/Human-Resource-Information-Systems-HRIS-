import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BonusRecord } from '../models/bonus-record';

@Injectable({
  providedIn: 'root'
})
export class BonusRecordService {

  private apiUrl = 'http://localhost:19243/api/Salary/BonusRecord';
  
    constructor(private http:HttpClient) { }
  
    getAll(): Observable<BonusRecord[]> {
      return this.http.get<BonusRecord[]>(this.apiUrl);
    }
  
      create(data: BonusRecord): Observable<BonusRecord> {
      return this.http.post<BonusRecord>('http://localhost:19243/api/Salary/BonusRecord', data);
    }
  
      update(id: string, data: BonusRecord): Observable<BonusRecord> {
      return this.http.put<BonusRecord>(`${this.apiUrl}${id}`, data);
    }
  
      delete(id: string): Observable<any> {
      return this.http.delete(`${this.apiUrl}${id}`);
    }
}
