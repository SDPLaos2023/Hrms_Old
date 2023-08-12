import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IdentityType } from '../models/identity-type.model';

@Injectable({
  providedIn: 'root'
})
export class IdentityTypeService {
  baseUrl = environment.baseUrlApi
  constructor(private http: HttpClient) { }

  idTypes: IdentityType[] = [];
  private _idTypes = new Subject<IdentityType>()
  readonly _idTypeList = this._idTypes.asObservable();
  GetListIdentity() {
    this.GetList().subscribe((resp: any) => {
      this.idTypes = resp as IdentityType[]
      this.idTypes.forEach(item => {
        this._idTypes.next(item)
      })
    })
  }

  GetList() {
    return this.http.get(this.baseUrl + "api/IdentityTypes");
  }
}
