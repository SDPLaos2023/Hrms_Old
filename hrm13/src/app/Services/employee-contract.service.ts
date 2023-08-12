import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeeContractService {
  NewContract(param: any) {
    return this.http.post(this.baseUrl + "api/EmployeeContracts", param)
  }

  UpdateContract(param: any) {
    return this.http.put(this.baseUrl + "api/EmployeeContracts/" + param.id, param)
  }

  baseUrl = environment.baseUrlApi

  constructor(private http: HttpClient) { }
}
