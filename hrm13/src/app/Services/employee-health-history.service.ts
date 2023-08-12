import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeeHealthHistoryService {
  baseUrl = environment.baseUrlApi
  constructor(private http: HttpClient) { }

  GetList(emp_id: any) {
    return this.http.get(this.baseUrl + "api/EmployeeHealthHistories/" + emp_id)
  }

  Create(param: any) {
    return this.http.post(this.baseUrl + "api/EmployeeHealthHistories", param)
  }

  Update(param: any) {
    return this.http.put(this.baseUrl + "api/EmployeeHealthHistories/" + param.id, param)
  }

  Delete(id: any) {
    return this.http.delete(this.baseUrl + "api/EmployeeHealthHistories/" + id)
  }

}
