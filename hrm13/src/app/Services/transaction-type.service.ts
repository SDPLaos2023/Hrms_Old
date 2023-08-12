import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { TransactionType } from '../models/transaction-type.model';

@Injectable({
  providedIn: 'root'
})
export class TransactionTypeService {
  baseUrl: string = environment.baseUrlApi;

  constructor(private http: HttpClient) { }

  GetList() {
    return this.http.get(this.baseUrl + "api/TransactionTypes")
  }
  Create(data: any) {
    return this.http.post(this.baseUrl + "api/TransactionTypes", data)
  }
  Update(data: any) {
    return this.http.put(this.baseUrl + "api/TransactionTypes/" + data.id, data)
  }
  Delete(id: any) {
    return this.http.delete(this.baseUrl + "api/TransactionTypes/" + id)
  }


  private _transactionTypes = new Subject<TransactionType>();
  readonly _transactionTypeList = this._transactionTypes.asObservable();
  transactionTypes: TransactionType[] = [];

  GetSections() {
    this.GetList().subscribe((resp: any) => {
      this.transactionTypes = resp as TransactionType[];
      this.transactionTypes.forEach(section => {
        this._transactionTypes.next(section)
      })
    })
  }
}
