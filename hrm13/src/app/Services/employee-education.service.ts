import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeeEducationService {
  baseUrl = environment.baseUrlApi

  constructor(private http: HttpClient) { }
  Create(param: any) {
    return this.http.post(this.baseUrl + "api/EmployeeEducations", param)
  }

  Delete(id: any) {
    return this.http.delete(this.baseUrl + "api/EmployeeEducations/" + id)
  }

  Update(param: any) {
    return this.http.put(this.baseUrl + "api/EmployeeEducations/" + param.id, param)
  }

  GetList(empId: any) {
    return this.http.get(this.baseUrl + "api/EmployeeEducations/employee/" + empId)
  }


}
