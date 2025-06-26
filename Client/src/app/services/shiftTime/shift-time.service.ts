import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ShiftTime } from 'src/app/models/shiftTime/shift-time'; // Adjust the import path as necessary

@Injectable({ providedIn: 'root' })
export class ShiftTimeService {
  private apiUrl = 'http://localhost:19243/api/ShiftTimes';

  constructor(private http: HttpClient) {}

  getAll(): Observable<ShiftTime[]> {
    return this.http.get<ShiftTime[]>(this.apiUrl);
  }

  create(data: ShiftTime): Observable<ShiftTime> {
    return this.http.post<ShiftTime>(this.apiUrl, data);
  }

  update(id: string, data: ShiftTime): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, data);
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}