import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Suspend } from 'src/app/models/suspend/suspend'; // Adjust the import path as necessary

@Injectable({ providedIn: 'root' })
export class SuspendService {
  private apiUrl = 'http://localhost:19243//api/Suspends';

  constructor(private http: HttpClient) {}

  getAll(): Observable<Suspend[]> {
    return this.http.get<Suspend[]>(this.apiUrl);
  }

  get(id: string): Observable<Suspend> {
    return this.http.get<Suspend>(`${this.apiUrl}/${id}`);
  }

  create(data: Suspend): Observable<Suspend> {
    return this.http.post<Suspend>(this.apiUrl, data);
  }

  update(id: string, data: Suspend): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, data);
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}