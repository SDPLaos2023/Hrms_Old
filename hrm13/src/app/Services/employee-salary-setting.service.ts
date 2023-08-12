import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeeSalarySettingService {
  UpdateSalarySetting(param: any) {
    return this.http.put(this.baseUrl + "api/EmployeeSalarySettings/" + param.Id, param)
  }

  NewSalarySetting(param: any) {
    return this.http.post(this.baseUrl + "api/EmployeeSalarySettings", param)
  }

  baseUrl = environment.baseUrlApi

  constructor(private http: HttpClient) { }
}
