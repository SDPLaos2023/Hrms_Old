import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { EmployeeGroup } from '../models/employee-group.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeGroupService {
  Delete(id: any) {
    return this.http.delete(this.baseUrl + "api/EmployeeGroups/" + id)
  }
  baseUrl = environment.baseUrlApi
  constructor(private http: HttpClient) { }
  GetList() {
    return this.http.get(this.baseUrl + "api/EmployeeGroups")
  }

  Get(id: any) {
    return this.http.get(this.baseUrl + "api/EmployeeGroups/" + id)
  }

  Create(param: any) {
    console.log(param)
    return this.http.post(this.baseUrl + "api/EmployeeGroups", param)
  }

  Update(param: any) {
    return this.http.put(this.baseUrl + "api/EmployeeGroups/" + param.id, param)
  }


  private _employeeGroup = new Subject<EmployeeGroup>();
  readonly _employeeGroups = this._employeeGroup.asObservable();
  employeeGroups: EmployeeGroup[] = [];

  GetEmployeeGroups() {
    this.GetList().subscribe((resp: any) => {
      this.employeeGroups = resp as EmployeeGroup[];
      this.employeeGroups.forEach(group => {
        this._employeeGroup.next(group)
      })
    })
  }
}
