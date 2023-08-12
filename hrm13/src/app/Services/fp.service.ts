import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Fp } from '../models/fp.model';

@Injectable({
  providedIn: 'root'
})
export class FpService {
  transferUser(data: any, fpId: any) {
    return this.http.post(this.baseUrl + "api/DeviceUsers/transfer/" + fpId, data)
  }

  baseUrl = environment.baseUrlApi
  constructor(private http: HttpClient) { }
  GetList() {
    return this.http.get(this.baseUrl + "api/FpDevices")
  }

  Get(id: any) {
    return this.http.get(this.baseUrl + "api/FpDevices/" + id)
  }

  Create(param: any) {
    console.log(param)
    return this.http.post(this.baseUrl + "api/FpDevices", param)
  }

  Update(param: any) {
    return this.http.put(this.baseUrl + "api/FpDevices/" + param.id, param)
  }

  private _device = new Subject<Fp>();
  readonly _devices = this._device.asObservable();
  devices: Fp[] = [];

  GetDevices() {
    this.GetList().subscribe((resp: any) => {
      this.devices = resp as Fp[];
      this.devices.forEach(group => {
        this._device.next(group)
      })
    })
  }
}
