import { DatePipe } from '@angular/common';
import { AfterViewInit, Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Timesheet } from 'src/app/models/attendances/timesheet.model';
import { Employee } from 'src/app/models/employee.model';
import { EmployeeService } from 'src/app/Services/employee.service';
import { HolidaySeittingService } from 'src/app/Services/holiday-seitting.service';
import { PageDataService } from 'src/app/Services/shared/page-data.service';
import { UserInfoService } from 'src/app/Services/shared/user-info.service';
import { TimesheetService } from 'src/app/Services/timesheet.service';

@Component({
  selector: 'app-print',
  templateUrl: './print.component.html',
  styleUrls: ['./print.component.css']
})
export class PrintComponent implements OnInit, AfterViewInit {
  today: any
  employeeName: any;
  sectionName: any;
  month: any;
  data: Timesheet[] = [];
  params: any;
  summary: any = {};
  constructor(
    private route: ActivatedRoute,
    private datePipe: DatePipe,
    private page: PageDataService,
    private spinner: NgxSpinnerService,
    private timesheetService: TimesheetService,
    private employeeService: EmployeeService,
    private datepipe: DatePipe,
    private user: UserInfoService,
    private holiService: HolidaySeittingService

  ) {

  }
  ngAfterViewInit(): void {


  }

  ngOnInit(): void {

    const routeParams = this.route.snapshot.paramMap;
    let emp = routeParams.get("employee")
    this.showAtt(emp)
    console.log(emp)

    this.params = this.page.param1;
    this.employeeName = this.page.param2
    this.month = this.page.param3;
    this.data = this.page.param4
    this.today = this.datePipe.transform(new Date, 'dd/MM/yyyy');
  }


  sumlate: 0
  sumearly: 0
  totallate: 0
  totalearly: 0
  showAtt(employeeId: any) {

    this.employeeService.GetEmployee(employeeId).subscribe(async (resp: any) => {
      let employee = resp as Employee

      await this.timesheetService.GetEmployeeWorkingPeriod(employee.code)
        .subscribe(async (wkpresp: any) => {
          console.log(wkpresp)
          this.month = wkpresp.name;
          let periodname = wkpresp.name;
          let perioddatefrom = this.datePipe.transform(Date.parse(wkpresp.startedAt), "dd/MM/YYYY");
          let perioddateto = this.datePipe.transform(Date.parse(wkpresp.endedAt), "dd/MM/YYYY");
          let totalworkingdays = wkpresp.total;
          this.employeeName = employee.name;
          this.employeeName += " [ ຂໍ້ມູນການເຮັດວຽກປະຈຳເດືອນ : " + periodname + " "
          this.employeeName += "ລະຫວ່າງວັນທີ : " + perioddatefrom + " "
          this.employeeName += "ຫາວັນທີ : " + perioddateto + " "
          this.employeeName += "ລວມ : " + totalworkingdays + " ວັນ ]"

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
            employee: employee.id,
            datefrom: start,
            dateto: stop
          }

          await this.timesheetService.GetEmployeeTimeAssignment(employee.id)
            .subscribe(async (ttresp: any) => {
              var tt = await ttresp;

              let breakin = tt.breakIn.split(':');
              let breakout = tt.breakOut.split(':');

              await this.timesheetService.getTimesheet(this.params).pipe(this.extractData)
                .subscribe(async (resp: any) => {


                  this.data = []
                  days.forEach(date => {
                    var eeee: any = this.datePipe.transform(date, "EEEE")
                    let ts = new Timesheet();
                    ts.attDate = date
                    ts.clockIn = "-";
                    ts.clockOut = "-";
                    ts.remark = eeee.includes("Sunday") ? "ວັນພັກ" : "";
                    ts.lateMin = "";
                    ts.earlyMin = "";

                    let holiday = holidays.filter(x => this.datePipe.transform(x.date, "yyyy-MM-dd") == this.datePipe.transform(date, "yyyy-MM-dd"));

                    resp.forEach((att: any) => {
                      var p1 = this.datePipe.transform(date, "dd")
                      var p2 = this.datePipe.transform(att.attDate, "dd")
                      if (p1 == p2) {
                        ts.clockIn = this.datePipe.transform(att.cIn, "HH:mm:ss")
                        ts.clockOut = this.datePipe.transform(att.cOut, "HH:mm:ss")

                        // console.log("att.lateMin", Number.parseInt(att.lateMin), isNaN(att.lateMin))
                        let late = Number.parseInt(att.lateMin) <= 0 ? 0 : att.lateMin;
                        let early = Number.parseInt(att.earlyMin) <= 0 ? 0 : att.earlyMin;

                        if (late > 0) {
                          this.totallate += 1;
                          this.sumlate += late;
                        }
                        if (early > 0) {
                          this.totalearly += 1;
                          this.sumearly += early;
                        }
                        ts.lateMin = att.lateMin //late;
                        ts.earlyMin = att.earlyMin// early;
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

                    holiday.forEach(d => {
                      let hdate = this.datePipe.transform(d.date, "yyyy-MM-dd")
                      let attdate = this.datePipe.transform(ts.attDate, "yyyy-MM-dd")
                      if (hdate == attdate) {
                        ts.remark = d.name

                      }
                    })

                    this.data.push(ts)

                  })

                  let asofdate = this.datepipe.transform(new Date, 'yyyy-MM-dd');
                  let params = {
                    ids: employee.code,
                    asofdate: asofdate,
                    creator: this.user.GetUsername(),
                    company: "C00001"
                  }
                  console.log(params)
                  this.spinner.show();
                  await this.timesheetService.CalucateTimesheet(params).subscribe((resp: any) => {
                    this.spinner.hide();
                    if (resp.length > 0) {
                      this.summary = resp[0]

                      // this.summary.total_late = this.totallate
                      // this.summary.total_early_out = this.totalearly
                      // this.summary.late_in = this.sumlate
                      // this.summary.early_out = this.sumearly
                      // console.log("summary", this.summary)
                      setTimeout(() => {
                        window.print();
                      }, 2000);
                    }
                  })

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


    });

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

}
