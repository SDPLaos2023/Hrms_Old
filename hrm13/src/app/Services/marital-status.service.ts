import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { MaritalStatus } from '../models/marital-status.model';

@Injectable({
  providedIn: 'root'
})
export class MaritalStatusService {
  GetList() {
    return this.http.get(this.baseUrl + "api/MariatalStatus")
  }
  Create(param: any) {
    return this.http.post(this.baseUrl + "api/MariatalStatus", param)
  }
  Update(param: any) {
    return this.http.put(this.baseUrl + "api/MariatalStatus/" + param.id, param)
  }
  Delete(id: any) {
    return this.http.delete(this.baseUrl + "api/MariatalStatus/" + id)
  }
  baseUrl = environment.baseUrlApi
  constructor(private http: HttpClient) { }

  status: MaritalStatus[] = [];
  private _status = new Subject<MaritalStatus>()
  readonly _mstatus = this._status.asObservable();
  GetListStatus() {
    this.GetList().subscribe((resp: any) => {
      this.status = resp as MaritalStatus[]
      this.status.forEach(status => {
        this._status.next(status)
      })
    })
  }
}
