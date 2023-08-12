import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { EmployeeLevel } from '../models/employee-level.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeLevelService {
  Delete(id: any) {
    return this.http.delete(this.baseUrl + "api/EmployeeLevels/" + id)
  }
  baseUrl = environment.baseUrlApi
  constructor(private http: HttpClient) { }
  GetList() {
    return this.http.get(this.baseUrl + "api/EmployeeLevels")
  }

  Get(id: any) {
    return this.http.get(this.baseUrl + "api/EmployeeLevels/" + id)
  }

  Create(param: any) {
    console.log(param)
    return this.http.post(this.baseUrl + "api/EmployeeLevels", param)
  }

  Update(param: any) {
    return this.http.put(this.baseUrl + "api/EmployeeLevels/" + param.id, param)
  }


  private _employeeLevel = new Subject<EmployeeLevel>();
  readonly _employeeLevels = this._employeeLevel.asObservable();
  employeeLevels: EmployeeLevel[] = [];

  GetEmployeeLevels() {
    this.GetList().subscribe((resp: any) => {
      this.employeeLevels = resp as EmployeeLevel[];
      this.employeeLevels.forEach(group => {
        this._employeeLevel.next(group)
      })
    })
  }
}
