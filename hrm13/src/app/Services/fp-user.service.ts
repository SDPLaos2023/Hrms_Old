import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { FpUser } from '../models/fp-user.model';

@Injectable({
  providedIn: 'root'
})
export class FpUserService {

  baseUrl = environment.baseUrlApi
  constructor(private http: HttpClient) { }
  GetList(id: any) {
    return this.http.get(this.baseUrl + "api/DeviceUsers/" + id + "/all")
  }

  GetListNoneUser(id: any) {
    return this.http.get(this.baseUrl + "api/DeviceUsers/" + id + "/none-users")
  }

  Get(id: any) {
    return this.http.get(this.baseUrl + "api/DeviceUsers/" + id)
  }

  Create(param: any) {
    console.log(param)
    return this.http.post(this.baseUrl + "api/DeviceUsers", param)
  }

  Update(param: any) {
    return this.http.put(this.baseUrl + "api/DeviceUsers/" + param.id, param)
  }

  Delete(id: any) {
    return this.http.delete(this.baseUrl + "api/DeviceUsers/" + id)
  }

  TransferUser(data: any) { }
}
