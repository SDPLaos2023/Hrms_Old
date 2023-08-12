import { DatePipe } from '@angular/common';
import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { NgxSpinnerService } from 'ngx-spinner';
import { async, Subject } from 'rxjs';
import { Timesheet } from 'src/app/models/attendances/timesheet.model';
import { Employee } from 'src/app/models/employee.model';
import { TimesheetD } from 'src/app/models/timesheet-d.model';
import { EmployeeService } from 'src/app/Services/employee.service';
import { HolidaySeittingService } from 'src/app/Services/holiday-seitting.service';
import { PageDataService } from 'src/app/Services/shared/page-data.service';
import { UserInfoService } from 'src/app/Services/shared/user-info.service';
import { TimesheetService } from 'src/app/Services/timesheet.service';

@Component({
  selector: 'app-monthly-timesheet',
  templateUrl: './monthly-timesheet.component.html',
  styleUrls: ['./monthly-timesheet.component.css']
})
export class MonthlyTimesheetComponent implements OnInit, AfterViewInit {
  employeeId: string;
  employee: Employee
  list: any[] = []
  @ViewChild(DataTableDirective, { static: false })
  dtElement: DataTableDirective;
  dtOptions: any = {};
  dtTrigger: Subject<any> = new Subject();
  today: any;
  form: FormGroup;
  timesheets: Timesheet[] = [];
  employeeName: any;
  CardHeader: string;
  periodname: any;
  perioddatefrom: any;
  perioddateto: any;
  totalworkingdays: any;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private page: PageDataService,
    private spinner: NgxSpinnerService,
    private timesheetService: TimesheetService,
    private datePipe: DatePipe,
    public user: UserInfoService,
    private employeeService: EmployeeService,
    private holiService: HolidaySeittingService
  ) {


  }
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

  iniform() {

    // console.log("init form", this.today)

    let dept = this.user.GetDeptCode();

    this.form = new FormGroup({
      employee: new FormControl(this.employeeId),
      department: new FormControl(dept),
      datefrom: new FormControl(this.today, Validators.required),
      // dateto: new FormControl("2022-02", Validators.required)
    });
  }

  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    let emp = routeParams.get("employee")
    let date: any = routeParams.get("month")
    console.log(emp)

    this.today = this.datePipe.transform(new Date, 'yyyy-MM');


    if (emp == null || emp == undefined) {
      this.employeeId = this.user.GetEmployeeIdInfo();
      this.GetEmployeeName(this.employeeId)
    }
    else {

      this.employeeId = emp
      this.today = this.datePipe.transform(new Date(date), 'yyyy-MM');
      console.log(this.today)
      this.GetEmployeeName(emp)

    }

    this.spinner.show();
    this.employeeService.GetEmployee(this.employeeId).subscribe(async (resp: any) => {
      this.employee = resp as Employee

      this.page.pagename = "ຂໍ້ມູນການປ້ຳໂມງ "// + this.employeeId //+ " " + resp.name
      this.page.breadcrumb = '<li class="breadcrumb-item"> <i class="fas fa-home"></i> Home</li><li class="breadcrumb-item"> Attendances </li> <li class="breadcrumb-item active" >' + this.page.pagename + ' </li>'

      await this.ShowTable(this.today);
      this.spinner.hide();
    });

    this.iniform()

  }
  GetEmployeeName(emp: string) {

    this.employeeService.GetEmployeeName(emp).subscribe((resp: any) => {
      this.employeeName = resp.name
      this.CardHeader = "ຂໍ້ມູນການປ້ຳໂມງຂອງ : " + this.employeeName;
    })

  }

  params = {}
  async ShowTable(AttDate: any) {


    await this.timesheetService.GetEmployeeWorkingPeriod(this.employee.code)
      .subscribe(async (wkpresp: any) => {
        console.log(wkpresp)
        this.periodname = wkpresp.name;
        this.perioddatefrom = this.datePipe.transform(Date.parse(wkpresp.startedAt), "dd/MM/YYYY");
        this.perioddateto = this.datePipe.transform(Date.parse(wkpresp.endedAt), "dd/MM/YYYY");
        this.totalworkingdays = wkpresp.total;

        this.CardHeader += " [ ຂໍ້ມູນການເຮັດວຽກປະຈຳເດືອນ : " + this.periodname + " "
        this.CardHeader += "ລະຫວ່າງວັນທີ : " + this.perioddatefrom + " "
        this.CardHeader += "ຫາວັນທີ : " + this.perioddateto + " "
        this.CardHeader += "ລວມ : " + this.totalworkingdays + " ວັນ ]"

        var c = Date.parse(AttDate)
        var year: any = this.datePipe.transform(c, "yyyy")
        var month: any = this.datePipe.transform(c, "M")
        month -= 1 //month start from 0


        let start = this.datePipe.transform(Date.parse(wkpresp.startedAt), "YYYY-MM-dd");
        let stop = this.datePipe.transform(Date.parse(wkpresp.endedAt), "YYYY-MM-dd");

        var days = this.getDates(start, stop)// this.getDaysInMonth(month, year)
        const routeParams = this.route.snapshot.paramMap;
        let dept: any = routeParams.get("dept")

        let activeYear = this.datePipe.transform(Date.parse(wkpresp.startedAt), "YYYY");
        let holidays: any[] = [];
        await this.holiService.GetList(activeYear).subscribe((resp: any) => {
          holidays = resp;
        })


        this.params = {
          //department: dept == null ? this.user.GetDeptCode() : dept,
          employee: this.employeeId,
          datefrom: start,//days[0],
          dateto: stop
        }

        await this.timesheetService.GetEmployeeTimeAssignment(this.employee.id)
          .subscribe(async (ttresp: any) => {
            var tt = await ttresp;

            let breakin = tt.breakIn.split(':');
            let breakout = tt.breakOut.split(':');


            await this.timesheetService.getTimesheet(this.params).pipe(this.extractData).subscribe((resp: any) => {
              this.list.length = 0
              this.list = resp

              this.timesheets.length = 0
              days.forEach(date => {
                var eeee: any = this.datePipe.transform(date, "EEEE")
                let ts = new Timesheet();
                ts.attDate = date
                ts.clockIn = "-";
                ts.clockOut = "-";
                ts.remark = eeee.includes("Sunday") ? "ວັນພັກ" : "";
                ts.lateMin = "";
                ts.earlyMin = "";

                resp.forEach((att: any) => {
                  var p1 = this.datePipe.transform(date, "dd")
                  var p2 = this.datePipe.transform(att.attDate, "dd")
                  if (p1 == p2) {
                    ts.clockIn = this.datePipe.transform(att.cIn, "HH:mm:ss")
                    ts.clockOut = this.datePipe.transform(att.cOut, "HH:mm:ss")
                    ts.lateMin = Number.parseInt(att.lateMin) <= 0 ? 0 : att.lateMin;
                    ts.earlyMin = Number.parseInt(att.earlyMin) <= 0 ? 0 : att.earlyMin;
                  }

                });

                if (ts.clockIn == "-" && ts.clockOut == "-" && !eeee.includes("Sunday"))
                  ts.remark = "ລືມປ້ຳໂມງ "

                if (ts.clockIn == ts.clockOut && (ts.clockIn != "-" && ts.clockOut != "-") && !eeee.includes("Sunday"))
                  ts.remark = "ປ້ຳໂມງເຂົ້າອອກບໍ່ຖືກ"

                let currdate = new Date(date);
                let datebreakin = new Date(currdate.getFullYear(),
                  currdate.getMonth(), currdate.getDate(), breakin[0], breakin[1], breakin[2]);

                let datebreakout = new Date(currdate.getFullYear(),
                  currdate.getMonth(), currdate.getDate(), breakout[0], breakout[1], breakout[2]);
                let holiday = holidays.filter(x => this.datePipe.transform(x.date, "yyyy-MM-dd") == this.datePipe.transform(date, "yyyy-MM-dd"));
                holiday.forEach(d => {
                  let hdate = this.datePipe.transform(d.date, "yyyy-MM-dd")
                  let attdate = this.datePipe.transform(ts.attDate, "yyyy-MM-dd")
                  if (hdate == attdate) {
                    ts.remark = d.name
                  }
                })
                this.timesheets.push(ts)

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

            }, error => {
              setTimeout(() => {
                this.spinner.hide()
              }, 1000);

            })
          });

      })




  }

  getDates(startDate: any, stopDate: any) {
    var dateArray = new Array();
    var currentDate = new Date(startDate);
    var stopdate = new Date(stopDate)
    while (currentDate <= stopdate) {
      dateArray.push(new Date(currentDate));
      currentDate.setDate(currentDate.getDate() + 1);
    }
    return dateArray;
  }



  private extractData(res: any) {
    const body = res;
    return body || {};
  }

  inquiry() {
    var month = this.datePipe.transform(this.form.value.datefrom, "yyyy-MM")
    console.log(month)

    this.ShowTable(month)

  }

  goToPrint() {
    var month = this.datePipe.transform(this.form.value.datefrom, "yyyy-MM")
    this.page.param1 = this.params;
    this.page.param2 = this.employeeName;
    this.page.param3 = month;
    this.page.param4 = this.timesheets//this.employee.id
    this.router.navigate(["timesheet/print/" + this.employee.id]);

  }


}
