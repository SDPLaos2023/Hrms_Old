import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ContractType } from '../models/contract-type.model';

@Injectable({
  providedIn: 'root'
})
export class ContractTypeService {
  Delete(id: any) {
    return this.http.delete(this.baseUrl + "api/ContractTypes/" + id)
  }
  baseUrl = environment.baseUrlApi
  constructor(private http: HttpClient) { }
  GetList() {
    return this.http.get(this.baseUrl + "api/ContractTypes")
  }

  Get(id: any) {
    return this.http.get(this.baseUrl + "api/ContractTypes/" + id)
  }

  Create(param: any) {
    console.log(param)
    return this.http.post(this.baseUrl + "api/ContractTypes", param)
  }

  Update(param: any) {
    return this.http.put(this.baseUrl + "api/ContractTypes/" + param.id, param)
  }

  contractTypes: ContractType[] = [];
  private _contractType = new Subject<ContractType>()
  readonly _contractTypes = this._contractType.asObservable();
  GetListContractTypes() {
    this.GetList().subscribe((resp: any) => {
      this.contractTypes = resp as ContractType[];
      this.contractTypes.forEach(country => {
        this._contractType.next(country);
      });
    });
  }
}
