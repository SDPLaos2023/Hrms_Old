import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeeProbationContractService {
  UpdateContract(param: any) {
    return this.http.put(this.baseUrl + "api/EmployeeProbations/" + param.Id, param)
  }

  NewContract(param:any) {
    return this.http.post(this.baseUrl + "api/EmployeeProbations", param)
  }

  baseUrl = environment.baseUrlApi

  constructor(private http: HttpClient) { }
}