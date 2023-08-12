import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { SalaryPayType } from '../models/salary-pay-type.model';

@Injectable({
  providedIn: 'root'
})
export class SalaryPayTypeService {
  baseUrl = environment.baseUrlApi
  constructor(private http: HttpClient) { }
  GetList() {
    return this.http.get(this.baseUrl + "api/SalaryPayTypes")
  }

  Get(id: any) {
    return this.http.get(this.baseUrl + "api/SalaryPayTypes/" + id)
  }
  Delete(id: any) {
    return this.http.delete(this.baseUrl + "api/SalaryPayTypes/" + id)
  }
  Create(param: any) {
    console.log(param)
    return this.http.post(this.baseUrl + "api/SalaryPayTypes", param)
  }

  Update(param: any) {
    return this.http.put(this.baseUrl + "api/SalaryPayTypes/" + param.id, param)
  }


  private _SalaryPayType = new Subject<SalaryPayType>();
  readonly _SalaryPayTypes = this._SalaryPayType.asObservable();
  SalaryPayTypes: SalaryPayType[] = [];

  GetSalaryPayTypes() {
    this.GetList().subscribe((resp: any) => {
      this.SalaryPayTypes = resp as SalaryPayType[];
      this.SalaryPayTypes.forEach(group => {
        this._SalaryPayType.next(group)
      })
    })
  }
}
