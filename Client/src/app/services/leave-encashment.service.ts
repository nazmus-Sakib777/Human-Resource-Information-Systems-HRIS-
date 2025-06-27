import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LeaveEncashment } from '../models/leave-encashment';

const apiUrl ='http://localhost:19243/api/LeaveEncashment';
@Injectable({
  providedIn: 'root'
})
export class LeaveEncashmentService {

  constructor(private http:HttpClient) { }
  getAll():Observable<LeaveEncashment[]>{
    return this.http.get<LeaveEncashment[]>(apiUrl);
  }

  create(data: LeaveEncashment): Observable<LeaveEncashment> {
      return this.http.post<LeaveEncashment>(apiUrl + '/Create', data);
    }
}
