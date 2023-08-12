import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Allowance } from '../models/allowance.model';

@Injectable({
  providedIn: 'root'
})
export class AllowanceService {
  baseUrl = environment.baseUrlApi
  constructor(private http: HttpClient) { }

  GetList() {
    return this.http.get(this.baseUrl + "api/Allowances")
  }

  Create(param: any) {
    return this.http.post(this.baseUrl + "api/Allowances", param)
  }

  Update(param: any) {
    return this.http.put(this.baseUrl + "api/Allowances/" + param.id, param)
  }

  Delete(id: any) {
    return this.http.delete(this.baseUrl + "api/Allowances/" + id)
  }

  private _allowances = new Subject<Allowance>();
  readonly _allowanceList = this._allowances.asObservable();
  allowances: Allowance[] = [];

  GetListAllowance() {
    this.GetList().subscribe((resp: any) => {
      this.allowances = resp as Allowance[];
      this.allowances.forEach(item => {
        this._allowances.next(item)
      })
    })
  }

}
