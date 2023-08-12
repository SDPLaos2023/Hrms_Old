import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeeIdentityService {

  baseUrl = environment.baseUrlApi
  constructor(private http: HttpClient) { }

  GetList(empId: any) {
    return this.http.get(this.baseUrl + "api/EmployeeIdentities/employee/" + empId);
  }

  Create(param: any) {
    return this.http.post(this.baseUrl + "api/EmployeeIdentities/", param);
  }

  Update(param: any) {
    return this.http.put(this.baseUrl + "api/EmployeeIdentities/" + param.id, param);
  }

  Delete(id: any) {
    return this.http.delete(this.baseUrl + "api/EmployeeIdentities/" + id);
  }
}
