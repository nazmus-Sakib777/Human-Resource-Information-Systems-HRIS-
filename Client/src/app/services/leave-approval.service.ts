import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LeaveApproval } from '../models/leave-approval';

const apiUrl ='http://localhost:19243/api/LeaveApproval';
@Injectable({
  providedIn: 'root'
})
export class LeaveApprovalService {

  constructor(private http: HttpClient) { }
  getAll(): Observable<LeaveApproval[]>{
    return this.http.get<LeaveApproval[]>(apiUrl);
  }

  create(data: LeaveApproval): Observable<LeaveApproval> {
      return this.http.post<LeaveApproval>(apiUrl + '/Create', data);
    }
}
