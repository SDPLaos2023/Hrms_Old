import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RuleService {
  baseUrl = environment.baseUrlApi;
  constructor(private http: HttpClient) { }

  Get() {
    return this.http.get(this.baseUrl + "api/rules");
  }

  Create(param: any) {
    return this.http.post(this.baseUrl + "api/rules", param);
  }

  Update(param: any) {
    return this.http.put(this.baseUrl + "api/rules/" + param.id, param);
  }

  GetOne(id: any) {
    return this.http.get(this.baseUrl + "api/rules/" + id);
  }


}
