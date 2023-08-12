import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Nationality } from '../models/nationality.model';
import { Race } from '../models/race.model';

@Injectable({
  providedIn: 'root'
})
export class NationlityAndRaceService {
  baseUrl = environment.baseUrlApi
  constructor(private http: HttpClient) { }

  GetList(path: any) {
    return this.http.get(this.baseUrl + "api/" + path)
  }

  Get(path: any, id: any) {
    return this.http.get(this.baseUrl + "api/" + path + "/" + id)
  }

  Delete(path: any, id: any) {
    return this.http.delete(this.baseUrl + "api/" + path + "/" + id)
  }

  Create(path: any, param: any) {
    return this.http.post(this.baseUrl + "api/" + path, param)
  }

  Update(path: any, param: any) {
    console.log('param', param)
    return this.http.put(this.baseUrl + "api/" + path + "/" + param.id, param)
  }

  nationalities: Nationality[] = [];
  private _nationality = new Subject<Nationality>()
  readonly _nationalities = this._nationality.asObservable();
  GetListNationalities() {
    this.GetList("Nationalities").subscribe((resp: any) => {
      this.nationalities = resp as Nationality[]
      this.nationalities.forEach(nationality => {
        this._nationality.next(nationality)
      })
    })
  }

  races: Race[] = [];
  private _race = new Subject<Race>()
  readonly _races = this._race.asObservable();
  GetListRaces() {
    this.GetList("Races").subscribe((resp: any) => {
      this.races = resp as Race[]
      this.races.forEach(race => {
        this._race.next(race)
      })
    })
  }

}
