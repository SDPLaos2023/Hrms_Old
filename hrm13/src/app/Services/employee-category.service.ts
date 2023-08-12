import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { EmployeeCategory } from '../models/employee-category.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeCategoryService {
  Delete(id: any) {
    return this.http.delete(this.baseUrl + "api/EmployeeCategories/" + id)
  }
  baseUrl = environment.baseUrlApi
  constructor(private http: HttpClient) { }
  GetList() {
    return this.http.get(this.baseUrl + "api/EmployeeCategories")
  }

  Get(id: any) {
    return this.http.get(this.baseUrl + "api/EmployeeCategories/" + id)
  }

  Create(param: any) {
    console.log(param)
    return this.http.post(this.baseUrl + "api/EmployeeCategories", param)
  }

  Update(param: any) {
    return this.http.put(this.baseUrl + "api/EmployeeCategories/" + param.id, param)
  }

  private _employeeCategory = new Subject<EmployeeCategory>();
  readonly _employeeCategories = this._employeeCategory.asObservable();
  employeeCategories: EmployeeCategory[] = [];

  GetEmployeeCategories() {
    this.GetList().subscribe((resp: any) => {
      this.employeeCategories = resp as EmployeeCategory[];
      this.employeeCategories.forEach(employeeCategory => {
        this._employeeCategory.next(employeeCategory)
      })
    })
  }

}
