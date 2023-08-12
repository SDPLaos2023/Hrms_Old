import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CurrencyService {
  Delete(id: any) {
    return this.http.delete(this.baseUrl + "api/Currencies/" + id);
  }
  baseUrl: string = environment.baseUrlApi;

  constructor(private http: HttpClient) { }

  GetList() {
    return this.http.get(this.baseUrl + "api/Currencies")
  }
  Create(data: any) {
    return this.http.post(this.baseUrl + "api/Currencies", data)
  }
  Update(data: any) {
    return this.http.put(this.baseUrl + "api/Currencies/" + data.id, data)
  }
}
