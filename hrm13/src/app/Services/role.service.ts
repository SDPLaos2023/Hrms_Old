import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RoleService {
  baseUrl = environment.baseUrlApi;
  constructor(private http: HttpClient) { }

  GetList() {
    return this.http.post(this.baseUrl + "api/roles", {});
  }

  Get(id: any) {
    return this.http.post(this.baseUrl + "api/roles/" + id, {});
  }
}
