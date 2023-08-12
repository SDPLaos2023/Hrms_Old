import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeeFamilyContactService {
  UpdateContact(param: any) {
    return this.http.put(this.baseUrl + "api/EmployeeFamilyContacts/" + param.Id, param)
  }

  NewContact(param: any) {
    return this.http.post(this.baseUrl + "api/EmployeeFamilyContacts", param)
  }

  baseUrl = environment.baseUrlApi

  constructor(private http: HttpClient) {


  }
}
