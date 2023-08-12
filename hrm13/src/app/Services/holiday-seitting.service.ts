import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Holiday } from '../models/holiday.model';

@Injectable({
  providedIn: 'root'
})
export class HolidaySeittingService {

  baseUrl = environment.baseUrlApi
  constructor(private http: HttpClient) { }

  GetList(year: any) {
    return this.http.get(this.baseUrl + "api/holidaySettings/active/" + year)
  }

  GetListDraff() {
    return this.http.get(this.baseUrl + "api/holidaySettings")
  }

  Get(id: any) {
    return this.http.get(this.baseUrl + "api/holidaySettings/" + id)
  }

  Create(param: Holiday) {
    return this.http.post(this.baseUrl + "api/holidaySettings", param)
  }

  Update(param: Holiday) {
    return this.http.put(this.baseUrl + "api/holidaySettings/" + param.id, param)
  }

  Delete(id: any) {
    return this.http.delete(this.baseUrl + "api/holidaySettings/" + id)
  }


  ByDate(param: any) {
    return this.http.post(this.baseUrl + "api/holidaySettings/bydate", param)
  }



}
