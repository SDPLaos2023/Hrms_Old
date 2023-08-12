import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseUrl = environment.baseUrlApi
  constructor(private http: HttpClient) { }
  Get(user_id: string) {
    return this.http.post(this.baseUrl + "api/users/" + user_id, {})
  }

  Delete(user_id: string) {
    return this.http.delete(this.baseUrl + "api/users/" + user_id)
  }

  GetList() {
    return this.http.get(this.baseUrl + "api/users")
  }

  Create(param: any) {
    return this.http.post(this.baseUrl + "api/users", param)
  }

  Update(param: any) {
    return this.http.put(this.baseUrl + "api/users/" + param.id, param)
  }

  ChangePassword(param: any) {
    return this.http.post(this.baseUrl + "api/users/chw/" + param.Id, param)
  }
}
