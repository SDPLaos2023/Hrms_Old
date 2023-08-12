import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Position } from '../models/position.model';

@Injectable({
  providedIn: 'root'
})
export class PositionService {
  baseUrl: string = environment.baseUrlApi;

  constructor(private http: HttpClient) { }

  GetList() {
    return this.http.get(this.baseUrl + "api/Positions")
  }
  Create(data: any) {
    return this.http.post(this.baseUrl + "api/Positions", data)
  }
  Update(data: any) {
    return this.http.put(this.baseUrl + "api/Positions/" + data.id, data)
  }
  Delete(id: any) {
    return this.http.delete(this.baseUrl + "api/Positions/" + id)
  }
  private _position = new Subject<Position>();
  readonly _positions = this._position.asObservable();
  positions: Position[] = [];

  GetPositions() {
    this.GetList().subscribe((resp: any) => {
      this.positions = resp as Position[];
      this.positions.forEach(position => {
        this._position.next(position)
      })
    })
  }


}
