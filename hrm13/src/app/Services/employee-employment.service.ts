import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeeEmploymentService {
  UpdateEmployment(param: any) {
    return this.http.put(this.baseUrl + "api/EmployeeEmployments/" + param.Id, param)
  }

  NewEmployment(param: any) {
    return this.http.post(this.baseUrl + "api/EmployeeEmployments", param)
  }


  baseUrl = environment.baseUrlApi

  constructor(private http: HttpClient) { }
}
