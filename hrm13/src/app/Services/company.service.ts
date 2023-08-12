import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  baseUrl: string = environment.baseUrlApi;

  constructor(private http: HttpClient) { }

  GetCompany() {
    return this.http.get(this.baseUrl + "api/Companies/C00001")
  }
  saveUpdate(value: any) {
    return this.http.put(this.baseUrl + "api/Companies/" + value.id, value);
  }
  GetList() {
    return this.http.get(this.baseUrl + "api/Companies/");
  }
}
