import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { async } from 'rxjs';
import { AnnualLeaveTypeService } from 'src/app/Services/annual-leave-type.service';
import { DepartmentService } from 'src/app/Services/department.service';
import { EmployeeLeaveSettingService } from 'src/app/Services/employee-leave-setting.service';
import { EmployeeService } from 'src/app/Services/employee.service';
import { PageDataService } from 'src/app/Services/shared/page-data.service';

@Component({
  selector: 'app-print-summary',
  templateUrl: './print-summary.component.html',
  styleUrls: ['./print-summary.component.css']
})
export class PrintSummaryComponent implements OnInit {
  employeeInfo: any = { departmentName: "", departmentEn: "" };
  departments: any;
  leaveTypes: any[] = [];
  summary: any[] = [];

  constructor(private route: ActivatedRoute, private page: PageDataService,
    private service: EmployeeLeaveSettingService,
    private empService: EmployeeService,
    private deptService: DepartmentService,
    private lpService: AnnualLeaveTypeService

  ) {

    this.LoadData()


  }
  list: any[] = [];
  ngOnInit(): void {



  }
  async LoadData() {
    const routeParams = this.route.snapshot.paramMap;
    let emp = routeParams.get("employee")
    let params = {
      employee: emp
    }
    await this.empService.GetEmployee(emp).subscribe(async (resp: any) => {
      this.employeeInfo = await resp;
    });
    await this.lpService.GetList().subscribe(async (resp: any) => {
      this.leaveTypes = await resp;
      this.leaveTypes = resp.filter((d: any) => d.id != 'LP')
    });
    await this.deptService.GetList().subscribe(async (resp: any) => {
      this.departments = await resp;
      if (this.employeeInfo.tbemployeeEmployments != undefined) {
        if (this.employeeInfo.tbemployeeEmployments.length > 0) {
          let deptId = this.employeeInfo.tbemployeeEmployments[0].department;
          let departments = resp.filter((d: any) => d.id == deptId);
          if (departments.length > 0)
            this.employeeInfo.departmentName = departments[0].name
          this.employeeInfo.departmentEn = departments[0].nameEn
        }

      }

    });
    await this.service.EmployeeGetLeaveSummary(params).subscribe(async (resp: any) => {
      this.list = await resp;
      let t: any[] = [];
      let sum = 0;
      // this.leaveTypes.forEach((l: any) => {

      //   resp.forEach((r: any) => {
      //     if (r.id == l.leaveTypes) {
      //       sum = sum + r.total
      //     }

      //   });
      //   let tt = {
      //     name: l.name,
      //     sum: sum
      //   }
      //   sum = 0;

      //   t.push(tt);
      //   this.summary = t;

      // });
      setTimeout(() => {
        window.print();

      }, 2000);
    })
  }

}
