import { DatePipe } from '@angular/common';
import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs';
import { Department } from 'src/app/models/department.model';
import { DepartmentService } from 'src/app/Services/department.service';
import { PageDataService } from 'src/app/Services/shared/page-data.service';
import { UserInfoService } from 'src/app/Services/shared/user-info.service';
import { TimesheetService } from 'src/app/Services/timesheet.service';

@Component({
  selector: 'app-list-employee',
  templateUrl: './list-employee.component.html',
  styleUrls: ['./list-employee.component.css']
})
export class ListEmployeeComponent implements OnInit, AfterViewInit {
  form: any
  today: any
  list: any[] = []
  @ViewChild(DataTableDirective, { static: false })
  dtElement: DataTableDirective;
  dtOptions: any = {};
  dtTrigger: Subject<any> = new Subject();
  constructor(private page: PageDataService,
    private spinner: NgxSpinnerService,
    private datePipe: DatePipe,
    private departmentService: DepartmentService,
    private timesheetService: TimesheetService,
    private router: Router
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
    this.page.pagename = "ລາຍຊື່ພະນັກງານທັງຫມົດ"
    this.page.breadcrumb = '<li class="breadcrumb-item"> <i class="fas fa-home"></i> Home</li><li class="breadcrumb-item"> Attendances </li> <li class="breadcrumb-item active" > ລາຍຊື່ພະນັກງານທັງຫມົດ </li>'

    this.GetDepartments()

    this.iniform()
  }

  iniform() {
    this.today = this.datePipe.transform(new Date, 'yyyy-MM-dd');
    console.log('tag', this.today)

    this.form = new FormGroup({
      employee: new FormControl(""),
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
    this.timesheetService.GetDepartmentAttLog(this.form.value).pipe(this.extractData).subscribe((resp: any) => {
      this.list.length = 0;

      this.list = resp

      this.list.forEach(e => {
        if (e.lateMin < 0) e.lateMin = 0;
      });

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

  goToTimesheet(item: any) {

    this.timesheetService.employeeSelected = item.employee

    if (item.employee != null || item.employee != undefined) {
      this.router.navigate(["timesheet/inquiry/monthly", { employee: item.employee, month: item.attDate }])
    }

  }




}
