import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Department } from '../models/department.model';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {



  baseUrl: string = environment.baseUrlApi;

  constructor(private http: HttpClient) { }
  Create(data: any) {
    return this.http.post(this.baseUrl + "api/Departments", data);
  }

  Update(data: any) {
    return this.http.put(this.baseUrl + "api/Departments/" + data.id, data);
  }

  Delete(id: any) {
    return this.http.delete(environment.baseUrlApi + "api/Departments/" + id);
  }

  GetList() {

    return this.http.get(this.baseUrl + 'api/Departments');

  }

  private _department = new Subject<Department>();
  readonly _departments = this._department.asObservable();
  departments: Department[] = [];

  GetDepartments() {
    this.GetList().subscribe((resp: any) => {
      this.departments = resp as Department[];
      this.departments.forEach(dept => {
        this._department.next(dept)
      })
    })
  }


}
