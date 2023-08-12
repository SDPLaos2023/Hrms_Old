import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TimetableService {
  baseUrl = environment.baseUrlApi
  GetList() {
    return this.http.get(this.baseUrl + "api/timetables")
  }

  Update(params: any) {
    return this.http.put(this.baseUrl + "api/timetables/" + params.id, params)
  }
  Delete(id: any) {
    return this.http.delete(this.baseUrl + "api/timetables/" + id)
  }
  Create(params: any) {
    return this.http.post(this.baseUrl + "api/timetables/", params)
  }

  GetAllShift(params: any) {
    return this.http.post(this.baseUrl + "api/timetables/shift", params)
  }

  CreateShift(params: any) {
    return this.http.post(this.baseUrl + "api/timetables/shift/create", params)
  }

  UpdateShift(params: any) {
    return this.http.post(this.baseUrl + "api/timetables/shift/update", params)
  }

  DeleteShift(params: any) {
    return this.http.post(this.baseUrl + "api/timetables/shift/delete", params)
  }

  GetAllShiftDetail(params: any) {
    return this.http.post(this.baseUrl + "api/timetables/shift/detail", params)
  }

  CreateShiftDetail(params: any) {
    return this.http.post(this.baseUrl + "api/timetables/shift/detail/create", params)
  }

  UpdateShiftDetail(params: any) {
    return this.http.post(this.baseUrl + "api/timetables/shift/detail/update", params)
  }

  DeleteShiftDetail(params: any) {
    return this.http.post(this.baseUrl + "api/timetables/shift/detail/delete", params)
  }
  constructor(private http: HttpClient) { }


}
