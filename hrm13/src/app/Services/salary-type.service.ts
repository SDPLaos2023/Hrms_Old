import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { SalaryType } from '../models/salary-type.model';

@Injectable({
  providedIn: 'root'
})
export class SalaryTypeService {
  Delete(id: any) {
    return this.http.delete(this.baseUrl + "api/Salary/" + id)
  }
  baseUrl = environment.baseUrlApi
  constructor(private http: HttpClient) { }
  GetList() {
    return this.http.get(this.baseUrl + "api/Salary")
  }

  Get(id: any) {
    return this.http.get(this.baseUrl + "api/Salary/" + id)
  }

  Create(param: any) {
    console.log(param)
    return this.http.post(this.baseUrl + "api/Salary", param)
  }

  Update(param: any) {
    return this.http.put(this.baseUrl + "api/Salary/" + param.id, param)
  }

  private _SalaryType = new Subject<SalaryType>();
  readonly _SalaryTypes = this._SalaryType.asObservable();
  SalaryTypes: SalaryType[] = [];

  GetSalaryTypes() {
    this.GetList().subscribe((resp: any) => {
      this.SalaryTypes = resp as SalaryType[];
      this.SalaryTypes.forEach(group => {
        this._SalaryType.next(group)
      })
    })
  }
}
