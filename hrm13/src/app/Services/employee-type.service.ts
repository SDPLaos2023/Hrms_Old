import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { EmployeeType } from '../models/employee-type.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeTypeService {
  baseUrl = environment.baseUrlApi
  constructor(private http: HttpClient) { }
  GetList() {
    return this.http.get(this.baseUrl + "api/EmployeeTypes")
  }

  Get(id: any) {
    return this.http.get(this.baseUrl + "api/EmployeeTypes/" + id)
  }

  Create(param: any) {
    console.log(param)
    return this.http.post(this.baseUrl + "api/EmployeeTypes", param)
  }

  Update(param: any) {
    return this.http.put(this.baseUrl + "api/EmployeeTypes/" + param.id, param)
  }


  Delete(id: any) {
    return this.http.delete(this.baseUrl + "api/EmployeeTypes/" + id)
  }

  private _employeeType = new Subject<EmployeeType>();
  readonly _employeeTypes = this._employeeType.asObservable();
  employeeTypes: EmployeeType[] = [];

  GetEmployeeTypes() {
    this.GetList().subscribe((resp: any) => {
      this.employeeTypes = resp as EmployeeType[];
      this.employeeTypes.forEach(group => {
        this._employeeType.next(group)
      })
    })
  }

}
