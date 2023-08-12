import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { WorkingType } from '../models/working-type.model';

@Injectable({
  providedIn: 'root'
})
export class WorkingTypeService {
  Delete(id: any) {
    return this.http.delete(this.baseUrl + "api/WorkingTypes/" + id)
  }
  baseUrl = environment.baseUrlApi
  constructor(private http: HttpClient) { }
  GetList() {
    return this.http.get(this.baseUrl + "api/WorkingTypes")
  }

  Get(id: string) {
    return this.http.get(this.baseUrl + "api/WorkingTypes/" + id)
  }

  Create(param: any) {
    console.log(param)
    return this.http.post(this.baseUrl + "api/WorkingTypes", param)
  }

  Update(param: any) {
    return this.http.put(this.baseUrl + "api/WorkingTypes/" + param.id, param)
  }

  private _workingType = new Subject<WorkingType>();
  readonly _workingTypes = this._workingType.asObservable();
  workingTypes: WorkingType[] = [];

  GetworkingTypes() {
    this.GetList().subscribe((resp: any) => {
      this.workingTypes = resp as WorkingType[];
      this.workingTypes.forEach(workingType => {
        this._workingType.next(workingType)
      })
    })
  }

}
