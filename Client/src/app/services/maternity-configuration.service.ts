import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MaternityConfiguration } from '../models/maternity-configuration';

const apiUrl ='http://localhost:19243/api/MaternityConfig';
@Injectable({
  providedIn: 'root'
})
export class MaternityConfigurationService {

  constructor(private http: HttpClient) { }

  getAll(): Observable<MaternityConfiguration[]>{
    return this.http.get<MaternityConfiguration[]>(apiUrl);
  }

  create(data: MaternityConfiguration): Observable<MaternityConfiguration> {
    return this.http.post<MaternityConfiguration>(apiUrl + '/Create', data);
  }
}

