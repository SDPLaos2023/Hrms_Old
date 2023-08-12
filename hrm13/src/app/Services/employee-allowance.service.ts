import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeeAllowanceService {
  baseUrl = environment.baseUrlApi
  constructor(private http: HttpClient) { }

  GetList(empId: any) {
    return this.http.get(this.baseUrl + "api/EmployeeAllowances/employee/" + empId)
  }

  Create(param: any) {
    return this.http.post(this.baseUrl + "api/EmployeeAllowances", param)
  }

  Update(param: any) {
    return this.http.put(this.baseUrl + "api/EmployeeAllowances/" + param.id, param)
  }

  Delete(id: any) {
    return this.http.delete(this.baseUrl + "api/EmployeeAllowances/" + id)
  }
}
