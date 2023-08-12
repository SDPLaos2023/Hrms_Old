import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AnnualLeaveType } from '../models/annual-leave-type.model';

@Injectable({
  providedIn: 'root'
})
export class AnnualLeaveTypeService {
  baseUrl = environment.baseUrlApi
  constructor(private http: HttpClient) { }
  GetList() {
    return this.http.get(this.baseUrl + "api/AnnualLeaveTypes")
  }

  Get(id: any) {
    return this.http.get(this.baseUrl + "api/AnnualLeaveTypes/" + id)
  }

  Create(param: any) {
    console.log(param)
    return this.http.post(this.baseUrl + "api/AnnualLeaveTypes", param)
  }

  Update(param: any) {
    return this.http.put(this.baseUrl + "api/AnnualLeaveTypes/" + param.id, param)
  }

  Delete(id: any) {
    return this.http.delete(this.baseUrl + "api/AnnualLeaveTypes/" + id)
  }
  private _AnnualLeaveType = new Subject<AnnualLeaveType>();
  readonly _AnnualLeaveTypes = this._AnnualLeaveType.asObservable();
  AnnualLeaveTypes: AnnualLeaveType[] = [];

  GetAnnualLeaveTypes() {
    this.GetList().subscribe((resp: any) => {
      this.AnnualLeaveTypes = resp as AnnualLeaveType[];
      this.AnnualLeaveTypes.forEach(group => {
        this._AnnualLeaveType.next(group)
      })
    })
  }
}
