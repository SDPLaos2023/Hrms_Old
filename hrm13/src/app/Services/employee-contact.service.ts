import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeeContactService {
  UpdateContact(param: any) {
    return this.http.put(this.baseUrl + "api/EmployeeContacts/" + param.Id, param)
  }
  NewContact(param: any) {
    return this.http.post(this.baseUrl + "api/EmployeeContacts", param)
  }
  baseUrl = environment.baseUrlApi

  constructor(private http: HttpClient) {


  }
}
