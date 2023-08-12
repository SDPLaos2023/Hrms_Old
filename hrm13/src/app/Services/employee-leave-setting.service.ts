import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeeLeaveSettingService {
  UpdateLeaveSetting(param: any) {
    return this.http.put(this.baseUrl + "api/EmployeeLeaveSettings/" + param.Id, param)
  }
  NewLeaveSetting(param: any) {
    return this.http.post(this.baseUrl + "api/EmployeeLeaveSettings", param)
  }

  GetLeaveRequest(param: any) {
    return this.http.post(this.baseUrl + "api/EmployeeLeaveSettings/leave-request", param)
  }

  EmployeeGetLeaveRequest(param: any) {
    return this.http.post(this.baseUrl + "api/EmployeeLeaveSettings/leave-request/employee", param)
  }

  EmployeeGetLeaveHistories(param: any) {
    return this.http.post(this.baseUrl + "api/EmployeeLeaveSettings/leave-request/employee/histories", param)
  }

  ManagerGetLeaveRequest(param: any) {
    return this.http.post(this.baseUrl + "api/EmployeeLeaveSettings/leave-request/managers/active", param)
  }
  ManagerGetLeaveApproved(param: any) {
    return this.http.post(this.baseUrl + "api/EmployeeLeaveSettings/leave-request/managers/approved", param)
  }
  ManagerGetLeaveRejected(param: any) {
    return this.http.post(this.baseUrl + "api/EmployeeLeaveSettings/leave-request/managers/rejected", param)
  }

  HrGetLeaveRequest(param: any) {
    return this.http.post(this.baseUrl + "api/EmployeeLeaveSettings/leave-request/hr/active", param)
  }
  HrGetLeaveApproved(param: any) {
    return this.http.post(this.baseUrl + "api/EmployeeLeaveSettings/leave-request/hr/approved", param)
  }
  HrGetLeaveRejected(param: any) {
    return this.http.post(this.baseUrl + "api/EmployeeLeaveSettings/leave-request/hr/rejected", param)
  }

  CreateLeaveRequest(param: any) {
    return this.http.post(this.baseUrl + "api/EmployeeLeaveSettings/leave-request/create", param)
  }

  UpdateLeaveRequest(param: any) {
    return this.http.post(this.baseUrl + "api/EmployeeLeaveSettings/leave-request/update", param)
  }

  DeleteLeaveRequest(param: any) {
    return this.http.post(this.baseUrl + "api/EmployeeLeaveSettings/leave-request/delete", param)
  }

  EmployeeGetLeaveSummary(param: any) {
    return this.http.post(this.baseUrl + "api/EmployeeLeaveSettings/leave/employee/summary", param)
  }
  baseUrl = environment.baseUrlApi
  constructor(private http: HttpClient) { }
}
