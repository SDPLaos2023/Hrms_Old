import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { EducationInstitution } from '../models/education-institution.model';

@Injectable({
  providedIn: 'root'
})
export class EducationInstitutionService {
  baseUrl = environment.baseUrlApi
  constructor(private http: HttpClient) { }
  GetList() {
    return this.http.get(this.baseUrl + "api/EducationInstitutions")
  }

  Get(id: any) {
    return this.http.get(this.baseUrl + "api/EducationInstitutions/" + id)
  }
  Delete(id: any) {
    return this.http.delete(this.baseUrl + "api/EducationInstitutions/" + id)
  }

  Create(param: any) {
    console.log(param)
    return this.http.post(this.baseUrl + "api/EducationInstitutions", param)
  }

  Update(param: any) {
    return this.http.put(this.baseUrl + "api/EducationInstitutions/" + param.id, param)
  }



  edus: EducationInstitution[] = [];
  private _edus = new Subject<EducationInstitution>()
  readonly _eduInstitutionList = this._edus.asObservable();
  GetListInstitutions() {
    this.GetList().subscribe((resp: any) => {
      this.edus = resp as EducationInstitution[]
      console.log('tag', resp)
      this.edus.forEach(eduInstitution => {
        this._edus.next(eduInstitution);
      })

    })
  }
}
