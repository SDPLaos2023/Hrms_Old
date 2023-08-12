import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { EmployeeTransaction } from '../models/employee-transaction.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeTransactionService {
  baseUrl: string = environment.baseUrlApi;

  constructor(private http: HttpClient) { }

  GetList(empId: any) {
    return this.http.get(this.baseUrl + "api/EmployeeTransactions/employee/" + empId)
  }

  Create(data: any) {
    return this.http.post(this.baseUrl + "api/EmployeeTransactions", data)
  }

  Update(data: any) {
    return this.http.put(this.baseUrl + "api/EmployeeTransactions/" + data.id, data)
  }

  Delete(id: any) {
    return this.http.delete(this.baseUrl + "api/EmployeeTransactions/" + id)
  }


  empTransactions: EmployeeTransaction[] = [];
  private _empTransactions = new Subject<EmployeeTransaction>()
  readonly _empTransactionList = this._empTransactions.asObservable();
  GetListIdentity(empId: any) {
    this.GetList(empId).subscribe((resp: any) => {
      this.empTransactions = resp as EmployeeTransaction[]
      this.empTransactions.forEach(item => {
        this._empTransactions.next(item)
      })
    })
  }

}
