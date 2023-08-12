import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Section } from '../models/section.model';

@Injectable({
  providedIn: 'root'
})
export class SectionService {
  Delete(id: any) {
    return this.http.delete(this.baseUrl + "api/Sections/" + id);
  }
  baseUrl: string = environment.baseUrlApi;

  constructor(private http: HttpClient) { }

  GetList() {
    return this.http.get(this.baseUrl + "api/Sections")
  }
  Create(data: any) {
    return this.http.post(this.baseUrl + "api/Sections", data)
  }
  Update(data: any) {
    return this.http.put(this.baseUrl + "api/Sections/" + data.id, data)
  }

  private _section = new Subject<Section>();
  readonly _sections = this._section.asObservable();
  sections: Section[] = [];

  GetSections() {
    this.GetList().subscribe((resp: any) => {
      this.sections = resp as Section[];
      this.sections.forEach(section => {
        this._section.next(section)
      })
    })
  }
}
