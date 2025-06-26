import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { JobLeft } from 'src/app/models/jobLeft/job-left'; // Adjust the import path as necessary

@Injectable({ providedIn: 'root' })
export class JobLeftService {
  private apiUrl = 'http://localhost:19243/api/JobLefts';

  constructor(private http: HttpClient) {}

  getAll(): Observable<JobLeft[]> {
    return this.http.get<JobLeft[]>(this.apiUrl);
  }

  get(id: string): Observable<JobLeft> {
    return this.http.get<JobLeft>(`${this.apiUrl}/${id}`);
  }

  create(data: JobLeft): Observable<JobLeft> {
    return this.http.post<JobLeft>(this.apiUrl, data);
  }

  update(id: string, data: JobLeft): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, data);
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}