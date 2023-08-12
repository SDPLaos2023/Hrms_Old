import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Division } from '../models/division.model';

@Injectable({
  providedIn: 'root'
})
export class DivisionService {
  baseUrl: string = environment.baseUrlApi;

  constructor(private http: HttpClient) { }

  GetList() {
    return this.http.get(this.baseUrl + "api/Divisions")
  }
  Create(data: any) {
    return this.http.post(this.baseUrl + "api/Divisions", data)
  }
  Update(data: any) {
    return this.http.put(this.baseUrl + "api/Divisions/" + data.id, data)
  }
  Delete(id: any) {
    return this.http.delete(this.baseUrl + "api/Divisions/" + id);
  }


  private _division = new Subject<Division>();
  readonly _divisions = this._division.asObservable();
  divisions: Division[] = [];

  GetDivisions() {
    this.GetList().subscribe((resp: any) => {
      this.divisions = resp as Division[];
      this.divisions.forEach(dept => {
        this._division.next(dept)
      })
    })
  }
}
