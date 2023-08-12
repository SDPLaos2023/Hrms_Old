import { DatePipe } from '@angular/common';
import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs';
import { DepartmentService } from 'src/app/Services/department.service';
import { EmployeeService } from 'src/app/Services/employee.service';
import { PageDataService } from 'src/app/Services/shared/page-data.service';
import { UserInfoService } from 'src/app/Services/shared/user-info.service';
import { TimesheetService } from 'src/app/Services/timesheet.service';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-att-calculate',
  templateUrl: './att-calculate.component.html',
  styleUrls: ['./att-calculate.component.css']
})
export class AttCalculateComponent implements OnInit, AfterViewInit {
  departments: any = [];
  form: FormGroup;
  employees: any = [];
  calculated: boolean = false;

  @ViewChild(DataTableDirective, { static: false })
  dtElement: DataTableDirective;
  dtElementC: DataTableDirective;

  dtOptions: any = {};
  dtTrigger: Subject<any> = new Subject();
  dtTriggerx: Subject<any> = new Subject();
  listCalculated: any = [];
  workingperiod: any;

  constructor(private page: PageDataService,
    private departmentService: DepartmentService,
    private router: Router,
    private employeeService: EmployeeService,
    private spinner: NgxSpinnerService,
    private datepipe: DatePipe,
    private user: UserInfoService,
    private timesheet: TimesheetService


  ) { }
  ngAfterViewInit(): void {
    this.dtOptions = {
      language: {
        processing: "Procesando...",
        search: "ຄົ້ນຫາ:",
        lengthMenu: "ສະແດງ _MENU_ ລາຍການ",
        info: "ສະແດງ _START_ ເຖີງ _END_ ຂອງ _TOTAL_ ລາຍການ",
        infoEmpty: "ສະແດງ 0 ເຖິງ 0 ຂອງ 0 ລາຍການ",
        infoFiltered: "(ຈາກທັງຫມົດ _MAX_ ລາຍການ)",
        infoPostFix: "",
        loadingRecords: "ກຳລັງໂຫລດຂໍ້ມູນ...",
        zeroRecords: "ບໍ່ພົບຂໍ້ມູນທີ່ຄົ້ນຫາ",
        emptyTable: "ບໍ່ມີຂໍ້ມູນສະແດງ",
        paginate: {
          first: "ເລີ່ມຕົ້ນ",
          previous: "ກ່ອນຫນ້າ",
          next: "ຖັດໄປ",
          last: "ສຸດທ້າຍ"
        },
        aria: {
          sortAscending: ": ຈັດລຽງຂໍ້ມູນຈາກນ້ອຍໄປໃຫຍ່",
          sortDescending: ": ຈັດລຽງຂໍ້ມູນຈາກໃຫຍ່ໄປນ້ອຍ"
        }
      }
    }
    this.dtTrigger.next(this.dtOptions);
  }

  ngOnInit(): void {

    this.page.pagename = "ຄິດໄລ່ປ້ຳໂມງ "// + this.employeeId //+ " " + resp.name
    this.page.breadcrumb = '<li class="breadcrumb-item"> <i class="fas fa-home"></i> Home</li><li class="breadcrumb-item"> Attendances </li> <li class="breadcrumb-item active" >' + this.page.pagename + ' </li>'
    this.GetDepartments();
    this.GetWorkingPeriod();

    this.form = new FormGroup({
      department: new FormControl("D")
    });

  }
  GetWorkingPeriod() {
    this.timesheet.GetWorkingPeriod('C00001').subscribe((resp: any) => {
      this.workingperiod = resp;

      console.log("workingperiod", this.workingperiod)
    })
  }



  GetDepartments() {
    this.departmentService.GetDepartments();
    this.departmentService._departments.subscribe(department => {
      this.departments.push(department)
    })
  }
  inquiryEmployees() {
    this.calculated = false;
    this.listCalculated.length = 0;
    this.employeeService.GetEmployeeByDepartment(this.form.value.department).subscribe((resp: any) => {
      this.employees = [];
      resp.forEach((item: any) => {
        let emp = {
          checked: false,
          employeecode: item.employeecode,
          employeename: item.employeename,
          fp_user_id: item.fp_user_id,
          department: item.department,
          departmentname: item.departmentname,
          division: item.division,
          divisionname: item.divisionname,
          section: item.section,
          sectionname: item.sectionname,
        }
        this.employees.push(emp);

      })

      this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
        dtInstance.destroy();
        this.dtTrigger.next(this.dtOptions);
        setTimeout(() => {
          this.spinner.hide();
        }, 1500);
      });

      setTimeout(() => {
        this.spinner.hide()
      }, 1500);
    });

  }

  checkall(data: any) {
    this.employees.forEach((item: any) => { item.checked = data })
  }

  async GetCalculate() {
    let list = this.employees.filter((item: any) => item.checked == true && item.fp_user_id != '')
    console.log(list)
    let fpusers: any = [];
    list.forEach((item: any) => {
      fpusers.push(item.fp_user_id)
    });
    console.log(fpusers.toString())
    let asofdate = this.datepipe.transform(new Date, 'yyyy-MM-dd');
    let params = {
      ids: fpusers.toString(),
      asofdate: asofdate,
      creator: this.user.GetUsername(),
      company: "C00001"
    }
    console.log(params)
    this.spinner.show();
    await this.timesheet.CalucateTimesheet(params).subscribe((resp: any) => {
      console.log("attendance", resp)
      this.spinner.hide();
      if (resp.length > 0) {

        this.listCalculated = []
        let workingperiod = this.workingperiod.length > 0 ? this.workingperiod[0] : []
        resp.forEach((item: any) => {
          let att = {
            company: workingperiod.company,
            workingperiod: workingperiod.name,
            started_at: workingperiod.started_at,
            ended_at: workingperiod.ended_at,
            employeecode: item.employeecode,
            employeename: item.employeename,
            minwork: item.minwork,
            late_in: item.late_in,
            total_late: item.total_late,
            early_out: item.early_out,
            total_early_out: item.total_early_out,
            totalworkdays: item.totalworkdays,
            totaldays: item.totaldays,
            total_hrs: item.total_hrs,
            totalworkhrs: item.totalworkhrs,
            totalmissdays: item.totalmissdays,
            totalleavewp: item.totalleavewp,
            totalleavewop: item.totalleavewop,
            totalleaves: item.totalleaves,
            sessionid: item.sessionid,
            created_by: item.created_by,
            data_asofdate: item.data_asofdate,
          };

          this.listCalculated.push(att)
        })
        this.calculated = true;

        this.dtElementC.dtInstance.then((dtInstance: DataTables.Api) => {
          dtInstance.destroy();
          this.dtTriggerx.next(this.dtOptions);
          setTimeout(() => {
            this.spinner.hide();
          }, 1500);
        })
        console.log(this.listCalculated)
      }
    })



  }


}
