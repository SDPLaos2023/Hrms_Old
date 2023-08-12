import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ResignationReasonService {
  Delete(id: any) {
    return this.http.delete(this.baseUrl + "api/ResignationReasons/" + id)
  }
  baseUrl = environment.baseUrlApi
  constructor(private http: HttpClient) { }
  GetList() {
    return this.http.get(this.baseUrl + "api/ResignationReasons")
  }

  Get(id: any) {
    return this.http.get(this.baseUrl + "api/ResignationReasons/" + id)
  }

  Create(param: any) {
    console.log(param)
    return this.http.post(this.baseUrl + "api/ResignationReasons", param)
  }

  Update(param: any) {
    return this.http.put(this.baseUrl + "api/ResignationReasons/" + param.id, param)
  }
}
