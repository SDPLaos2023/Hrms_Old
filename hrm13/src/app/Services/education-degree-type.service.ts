import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { EducationDegree } from '../models/education-degree.model';

@Injectable({
  providedIn: 'root'
})
export class EducationDegreeTypeService {

  baseUrl = environment.baseUrlApi
  constructor(private http: HttpClient) { }
  GetList() {
    return this.http.get(this.baseUrl + "api/EducationDegrees")
  }

  Get(id: any) {
    return this.http.get(this.baseUrl + "api/EducationDegrees/" + id)
  }

  Delete(id: any) {
    return this.http.delete(this.baseUrl + "api/EducationDegrees/" + id)
  }
  Create(param: any) {
    console.log(param)
    return this.http.post(this.baseUrl + "api/EducationDegrees", param)
  }

  Update(param: any) {
    return this.http.put(this.baseUrl + "api/EducationDegrees/" + param.id, param)
  }

  degrees: EducationDegree[] = [];
  private _degrees = new Subject<EducationDegree>()
  readonly _degreeList = this._degrees.asObservable();
  GetListDegrees() {
    this.GetList().subscribe((resp: any) => {
      this.degrees = resp as EducationDegree[]
      this.degrees.forEach(degree => {
        this._degrees.next(degree);
      })

    })
  }
}
