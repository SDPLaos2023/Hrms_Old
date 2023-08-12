import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Country } from '../models/country.model';
import { Province } from '../models/province.model';

@Injectable({
  providedIn: 'root'
})
export class CountryService {



  countries: Country[] = [];
  private _country = new Subject<Country>()
  readonly _countries = this._country.asObservable();

  baseUrl = environment.baseUrlApi
  constructor(private http: HttpClient) { }
  GetList() {
    return this.http.get(this.baseUrl + "api/Countries")
  }

  Get(id: any) {
    return this.http.get(this.baseUrl + "api/Countries/" + id)
  }

  Create(param: any) {
    console.log(param)
    return this.http.post(this.baseUrl + "api/Countries", param)
  }

  Update(param: any) {
    return this.http.put(this.baseUrl + "api/Countries/" + param.id, param)
  }

  Delete(id: any) {
    return this.http.delete(this.baseUrl + "api/Countries/" + id)
  }

  GetListCountries() {
    this.GetList().subscribe((resp: any) => {
      this.countries = resp as Country[];
      this.countries.forEach(country => {
        this._country.next(country);
      });
    });
  }
}
