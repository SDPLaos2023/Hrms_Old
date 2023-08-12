import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TimesheetService {
  employeeSelected: string = ""

  getTimesheet(params: any) {
    // return this.http.post(this.baseUrl + 'api/Timesheets/time-att-log', params)
    return this.http.post(this.baseUrl + 'api/Timesheets/getusertimesheetbydate', params)
  }
  GetDepartmentAttLog(params: any) {
    //return this.http.post(this.baseUrl + 'api/Timesheets/time-att-logs', params)
    return this.http.post(this.baseUrl + 'api/Timesheets/getalltimesheetmonthly', params)
  }

  AddTimeInq(params: any) {
    return this.http.post(this.baseUrl + 'api/Timesheets/addtime-inq', params)
  }
  AddTime(params: any) {
    return this.http.post(this.baseUrl + 'api/Timesheets/addtime', params)
  }

  GetUserTimesheetByDate(params: any) {
    return this.http.post(this.baseUrl + 'api/Timesheets/getusertimesheetbydepartmentdate', params)
  }

  UpdateTimesheet(params: any) {
    return this.http.post(this.baseUrl + 'api/Timesheets/updatetimesheetadjustment', params)
  }


  AddLog(params: any) {
    return this.http.post(this.baseUrl + 'api/Timesheets/addlog', params)
  }

  CalucateTimesheet(params: any) {
    return this.http.post(this.baseUrl + 'api/Timesheets/calcalate', params)
  }

  GetWorkingPeriod(company: any) {
    return this.http.post(this.baseUrl + 'api/Timesheets/workingperiod/' + company, {})
  }

  NewWorkingPeriod(params: any) {
    return this.http.post(this.baseUrl + 'api/Timesheets/workingperiod/create', params)
  }
  UpdateWorkingPeriod(params: any) {
    return this.http.post(this.baseUrl + 'api/Timesheets/workingperiod/update', params)
  }
  ActiveWorkingPeriod(params: any) {
    return this.http.post(this.baseUrl + 'api/Timesheets/workingperiod/active/' + params, {})
  }
  GetEmployeeWorkingPeriod(params: any) {
    return this.http.post(this.baseUrl + 'api/Timesheets/workingperiod/fpuser/' + params, {})
  }
  GetEmployeeTimeAssignment(params: any) {
    return this.http.post(this.baseUrl + 'api/Timesheets/timeassigment/' + params, {})
  }
  ///api/Timesheets/timeassigment/E00371

  baseUrl: string = environment.baseUrlApi;

  constructor(private http: HttpClient) { }
}
