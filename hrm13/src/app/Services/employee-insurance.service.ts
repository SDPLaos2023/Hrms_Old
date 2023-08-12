import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeeInsuranceService {

  UpdateInsuranceSetting(param: any) {
    return this.http.post(this.baseUrl + "api/EmployeeInsurances/" + param.Id, param)
  }

  NewInsuranceSetting(param: any) {
    return this.http.post(this.baseUrl + "api/EmployeeInsurances", param)
  }

  baseUrl = environment.baseUrlApi
  constructor(private http: HttpClient) { }
}
