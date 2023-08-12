import { DatePipe } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DataTableDirective } from 'angular-datatables';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs';
import { Department } from 'src/app/models/department.model';
import { DepartmentService } from 'src/app/Services/department.service';
import { PageDataService } from 'src/app/Services/shared/page-data.service';
import { TimesheetService } from 'src/app/Services/timesheet.service';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-update-timestamp',
  templateUrl: './update-timestamp.component.html',
  styleUrls: ['./update-timestamp.component.css']
})
export class UpdateTimestampComponent implements OnInit {

  form: any
  today: any
  list: any[] = []
  isDisabled = true;
  @ViewChild(DataTableDirective, { static: false })
  dtElement: DataTableDirective;
  dtOptions: any = {};
  dtTrigger: Subject<any> = new Subject();

  constructor(private page: PageDataService,
    private spinner: NgxSpinnerService,
    private datePipe: DatePipe,
    private departmentService: DepartmentService,
    private timesheetService: TimesheetService
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

  ngOnInit(): void {
    this.page.pagename = "ປ້ຳໂມງຄືນ"
    this.page.breadcrumb = '<li class="breadcrumb-item"> <i class="fas fa-home"></i> Home</li><li class="breadcrumb-item"> Attendances </li> <li class="breadcrumb-item active" > ລາຍຊື່ພະນັກງານທັງຫມົດ </li>'

    this.GetDepartments()

    this.iniform()
  }

  iniform() {
    this.today = this.datePipe.transform(new Date, 'yyyy-MM-dd');
    console.log('tag', this.today)

    this.form = new FormGroup({
      employee: new FormControl("", Validators.required),
      department: new FormControl("D"),
      datefrom: new FormControl(this.today, Validators.required),
      dateto: new FormControl(this.today, Validators.required)
    });
  }


  departments: Department[] = []
  GetDepartments() {
    this.departmentService.GetDepartments();
    this.departmentService._departments.subscribe(department => {
      this.departments.push(department)
    })
  }

  private extractData(res: any) {
    const body = res;
    return body || {};
  }

  inquiry() {
    this.spinner.show()
    this.timesheetService.GetUserTimesheetByDate(this.form.value).pipe(this.extractData).subscribe((resp: any) => {
      this.list.length = 0;

      resp.forEach((item: any) => {
        let row = {
          fpUserId: item.fpUserId,
          attDate: item.attDate,
          cIn: this.datePipe.transform(item.cIn, 'mediumTime'),
          cOut: this.datePipe.transform(item.cOut, 'mediumTime'),
          employee: item.employee,
          employeeName: item.employeeName,
          lateMin: item.lateMin,
          earlyMin: item.earlyMin,
          workMin: item.workMin,
          division: item.division,
          department: item.department,
          section: item.section == 'ເລືອກ' ? "ຍັງບໍ່ຖືກເລືອກຫນ່ວຍງານ" : item.section,
          newCIn: null,
          newCOut: null
        }
        console.log(row)
        this.list.push(row)
      })
      this.isDisabled = false;
      this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
        dtInstance.destroy();
        this.dtTrigger.next(this.dtOptions);
        setTimeout(() => {
          this.spinner.hide();
        }, 1500);
      });

    }, error => {
      setTimeout(() => {
        this.spinner.hide()
      }, 1000);

    })

  }

  save() {

    const dailogSwal = Swal.mixin({
      customClass: {
        title: 'laoweb',
        confirmButton: 'btn btn-success',
        cancelButton: 'btn btn-danger'
      },
      buttonsStyling: true
    });

    dailogSwal.fire({
      title: "ການເພິ່ມປ້ຳໂມງຄືນ",
      text: 'ຕ້ອງການບັນທຶກການປ່ຽນແປງນີ້ບໍ່',
      icon: 'question',
      showCancelButton: true,
      confirmButtonText: 'ບັນທຶກ',
      cancelButtonText: 'ຍົກເລີກ'
    }).then((result: any) => {
      if (result.value) {
        // console.log("Confirm")
        // console.log(this.list)
        let data: any = [];
        this.list.forEach((item: any) => {
          let newCIn = this.timeTo24Hr(this.time24to12(item.newCIn) == null ? item.cIn : this.time24to12(item.newCIn))
          let newCOut = this.timeTo24Hr(this.time24to12(item.newCOut) == null ? item.cOut : this.time24to12(item.newCOut))
          let row = {
            fpUserId: item.fpUserId,
            attDate: item.attDate,
            clockIn: newCIn,
            clockOut: newCOut,
          }

          data.push(row)

        })
        this.timesheetService.AddLog(data).subscribe((resp: any) => {
          console.log(resp)
          dailogSwal.fire({
            title: "ການບັນທຶກສຳເລັດ",
            text: '',
            icon: 'success',
            showCancelButton: false,
            confirmButtonText: 'OK',
            cancelButtonText: 'ຍົກເລີກ'
          });
          this.isDisabled = true
        })
      }
    });
  }

  time24to12(a: any) {
    let rs = (new Date("1955-11-05T" + a + "Z")).toLocaleTimeString("bestfit", {
      timeZone: "UTC",
      hour12: !0,
      hour: "numeric",
      minute: "numeric",
      second: "numeric"
    });
    if (rs.includes("Invalid Date")) return null;
    return rs;
  };

  timeTo24Hr(time: any) {
    if (time == null) return;
    let t = time.split(":");
    if (t[0] == 12) {
      t[0] = '00'
    }
    if (time.includes("PM")) {
      t[0] = parseInt(t[0]) + 12;
    }
    let time24 = t[0] + ':' + t[1] + ':00';
    return time24;
  }

}
