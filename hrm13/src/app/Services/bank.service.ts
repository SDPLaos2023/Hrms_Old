import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Bank } from '../models/bank.model';

@Injectable({
  providedIn: 'root'
})
export class BankService {
  baseUrl = environment.baseUrlApi
  constructor(private http: HttpClient) { }
  GetList() {
    return this.http.get(this.baseUrl + "api/Banks")
  }

  Get(id: any) {
    return this.http.get(this.baseUrl + "api/Banks/" + id)
  }

  Delete(id: any) {
    return this.http.delete(this.baseUrl + "api/Banks/" + id)
  }

  Create(param: any) {
    console.log(param)
    return this.http.post(this.baseUrl + "api/Banks", param)
  }

  Update(param: any) {
    return this.http.put(this.baseUrl + "api/Banks/" + param.id, param)
  }
  private _BankOpt = new Subject<Bank>();
  readonly _BankOpts = this._BankOpt.asObservable();
  BankOpts: Bank[] = [];

  GetBankOpts() {
    this.GetList().subscribe((resp: any) => {
      this.BankOpts = resp as Bank[];
      this.BankOpts.forEach(group => {
        this._BankOpt.next(group)
      })
    })
  }
}
