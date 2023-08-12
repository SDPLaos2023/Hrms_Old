import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PageMasterService {
  baseUrl = environment.baseUrlApi
  constructor(private http: HttpClient) { }
  GetAll() {
    return this.http.post(this.baseUrl + 'api/pagemasters', {});
  }

  Get(pageGroup: any) {
    return this.http.post(this.baseUrl + 'api/pagemasters/' + pageGroup, {});
  }
}
