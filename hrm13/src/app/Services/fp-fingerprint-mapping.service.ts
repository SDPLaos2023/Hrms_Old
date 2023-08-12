import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class FpFingerprintMappingService {


  baseUrl = environment.baseUrlApi
  constructor(private http: HttpClient) { }
  GetList(id: any) {
    return this.http.get(this.baseUrl + "api/DeviceFingerMappings/fingerprint/" + id)
  }

  Get(id: any) {
    return this.http.get(this.baseUrl + "api/DeviceFingerMappings/" + id)
  }

  Create(param: any) {
    console.log(param)
    return this.http.post(this.baseUrl + "api/DeviceFingerMappings", param)
  }

  Update(param: any) {
    return this.http.put(this.baseUrl + "api/DeviceFingerMappings/" + param.id, param)
  }

  Delete(id: any) {
    return this.http.delete(this.baseUrl + "api/DeviceFingerMappings/" + id)
  }
}
