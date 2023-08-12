import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeeCalssificationService {
  UpdateEmployeeClass(param: any) {
    return this.http.put(this.baseUrl + "api/EmployeeClassifications/" + param.Id, param)
  }
  NewEmployeeClass(param: any) {
    return this.http.post(this.baseUrl + "api/EmployeeClassifications", param)
  }

  baseUrl = environment.baseUrlApi
  constructor(private http: HttpClient) { }
}
