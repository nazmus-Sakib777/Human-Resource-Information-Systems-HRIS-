import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
//import { environment } from '../../environments/environment';
import { Grade } from '../models/grade.model'; // Adjust the path if needed




@Injectable({
  providedIn: 'root',
})
export class GradeService {
  private readonly apiUrl = '/api/Grades';
  //private apiUrl = `${environment.apiBaseUrl}/Grades`;

  constructor(private readonly http: HttpClient) {}

  getGrades(): Observable<Grade[]> {
    return this.http.get<Grade[]>(this.apiUrl);
  }

  getGrade(id: string): Observable<Grade> {
    return this.http.get<Grade>(`${this.apiUrl}/${id}`);
  }

  addGrade(grade: Grade): Observable<Grade> {
    return this.http.post<Grade>(this.apiUrl, grade);
  }

  updateGrade(id: string, grade: Grade): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, grade);
  }

  deleteGrade(id: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
