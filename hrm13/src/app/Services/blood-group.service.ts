import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { BloodGroup } from '../models/blood-group.model';

@Injectable({
  providedIn: 'root'
})
export class BloodGroupService {
  GetList() {
    return this.http.get(this.baseUrl + "api/BloodGroups")
  }
  Create(param: any) {
    return this.http.post(this.baseUrl + "api/BloodGroups", param)
  }
  Delete(id: any) {
    return this.http.delete(this.baseUrl + "api/BloodGroups/" + id)
  }
  Update(param: any) {
    return this.http.put(this.baseUrl + "api/BloodGroups/" + param.id, param)

  }
  baseUrl = environment.baseUrlApi
  constructor(private http: HttpClient) { }


  bloodgroups: BloodGroup[] = [];
  private _bloodgroup = new Subject<BloodGroup>()
  readonly _bloodgroups = this._bloodgroup.asObservable();

  GetListBg() {
    this.GetList().subscribe((resp: any) => {
      this.bloodgroups = resp as BloodGroup[];
      this.bloodgroups.forEach(bloodgroup => {
        this._bloodgroup.next(bloodgroup);
      });
    });
  }
}