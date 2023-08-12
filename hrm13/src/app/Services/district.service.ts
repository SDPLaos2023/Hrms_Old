import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { District } from '../models/district.model';

@Injectable({
  providedIn: 'root'
})
export class DistrictService {
  Delete(id: any) {
    return this.http.delete(this.baseUrl + "api/Districts/" + id)
  }
  districts: District[] = [];
  private _district = new Subject<District>()
  readonly _districts = this._district.asObservable();

  baseUrl = environment.baseUrlApi
  constructor(private http: HttpClient) { }
  GetList() {
    return this.http.get(this.baseUrl + "api/Districts")
  }

  GetDistricts(provinceId: any) {
    return this.http.get(this.baseUrl + "api/Districts/Province/" + provinceId)
  }

  Get(id: any) {
    return this.http.get(this.baseUrl + "api/Districts/" + id)
  }

  Create(param: any) {
    console.log(param)
    return this.http.post(this.baseUrl + "api/Districts", param)
  }

  Update(param: any) {
    return this.http.put(this.baseUrl + "api/Districts/" + param.id, param)
  }

  GetListDistricts(provinceId: any) {
    this.GetDistricts(provinceId).subscribe((resp: any) => {
      this.districts = resp as District[]
      return this.districts;
      // this.districts.forEach(province => {
      //   this._district.next(province);
      // })
    })
  }

  // ClearDistricts() {
  //   this._district.unsubscribe();
  //   this._district.asObservable()
  // }
}
