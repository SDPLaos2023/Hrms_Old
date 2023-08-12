import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RuleItemService {
  AddBySelectAll(rule_id: any) {
    return this.http.post(this.baseUrl + 'api/ruleitems/' + rule_id + '/select-all', {});
  }

  AddRuleItem(rule_id: any, page_id: any) {
    return this.http.post(this.baseUrl + 'api/ruleitems/' + rule_id + '/' + page_id, {});
  }

  constructor(private http: HttpClient) { }
  baseUrl = environment.baseUrlApi;

  GetList(rule_id: any) {
    return this.http.post(this.baseUrl + 'api/ruleitems/rule/' + rule_id, {});
  }

  Create(param: any) {
    return this.http.post(this.baseUrl + 'api/ruleitems/create', param);
  }

  Update(param: any) {
    return this.http.put(this.baseUrl + 'api/ruleitems/' + param.id, param);
  }

  Delete(id: any) {
    return this.http.delete(this.baseUrl + 'api/ruleitems/' + id);
  }
}
