import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Province } from '../models/province.model';

@Injectable({
  providedIn: 'root'
})
export class ProvinceService {
  provinces: Province[] = [];
  private _province = new Subject<Province>()
  readonly _provinces = this._province.asObservable();

  baseUrl = environment.baseUrlApi
  constructor(private http: HttpClient) { }
  GetList() {
    return this.http.get(this.baseUrl + "api/Provinces")
  }

  Get(id: any) {
    return this.http.get(this.baseUrl + "api/Provinces/" + id)
  }
  Delete(id: any) {
    return this.http.delete(this.baseUrl + "api/Provinces/" + id)
  }

  Create(param: any) {
    console.log(param)
    return this.http.post(this.baseUrl + "api/Provinces", param)
  }

  Update(param: any) {
    return this.http.put(this.baseUrl + "api/Provinces/" + param.id, param)
  }

  GetListProvinces() {
    this.GetList().subscribe((resp: any) => {
      this.provinces = resp as Province[]
      this.provinces.forEach(province => {
        this._province.next(province);
      })

    })
  }
}
