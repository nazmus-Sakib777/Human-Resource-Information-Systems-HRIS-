import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


export interface mAttendanceRecord {
  employeeId: string;
  employeeName: string;
  unitName: string;
  divisionName: string;
  departmentName: string;
  sectionName: string;
  lineName: string;
  recordDate: string; // or Date
  inTime: string | null;
  outTime: string | null;
  presentStatus: string;
}

@Injectable({
  providedIn: 'root'
})


export class MAttendanceService {

  private apiUrl = 'http://localhost:19243/api/MultipleAttendance'; 

  constructor(private http: HttpClient) { }

  getAttendance(
    startDate?: string,
    endDate?: string,
    specificDate?: string,
    divisionId?: string,
    departmentId?: string,
    unitId?: string,
    sectionId?: string,
    lineId?: string,
    employeeId?: string
  ): Observable<mAttendanceRecord[]> {

    let params = new HttpParams();

    if (startDate) params = params.set('startDate', startDate);
    if (endDate) params = params.set('endDate', endDate);
    if (specificDate) params = params.set('specificDate', specificDate);
    if (divisionId) params = params.set('divisionId', divisionId);
    if (departmentId) params = params.set('departmentId', departmentId);
    if (unitId) params = params.set('unitId', unitId);
    if (sectionId) params = params.set('sectionId', sectionId);
    if (lineId) params = params.set('lineId', lineId);
    if (employeeId) params = params.set('employeeId', employeeId);

    return this.http.get<mAttendanceRecord[]>(this.apiUrl, { params });
  }
}
