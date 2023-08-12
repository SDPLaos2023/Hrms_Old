import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs';
import { EmployeeLeaveSettingService } from 'src/app/Services/employee-leave-setting.service';
import { PageDataService } from 'src/app/Services/shared/page-data.service';
import { UserInfoService } from 'src/app/Services/shared/user-info.service';

@Component({
  selector: 'app-leave-history',
  templateUrl: './leave-history.component.html',
  styleUrls: ['./leave-history.component.css']
})
export class LeaveHistoryComponent implements OnInit, AfterViewInit {
  @ViewChild(DataTableDirective, { static: false })
  dtElement: DataTableDirective;

  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<any> = new Subject();
  list: any[] = []
  condition: string | null;

  timetables: any[] = [];
  constructor(private page: PageDataService,
    private service: EmployeeLeaveSettingService,
    private user: UserInfoService,
    private router: Router,
    private route: ActivatedRoute,
    private spinner: NgxSpinnerService) { }

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
    };
    this.dtTrigger.next(this.dtOptions);
  }

  ngOnInit(): void {
    this.page.pagename = "ລາຍປະຫວັດການຂໍລາພັກ"
    this.page.breadcrumb = '<li class="breadcrumb-item"> <i class="fas fa-home"></i> Home</li><li class="breadcrumb-item"> Attendances </li> <li class="breadcrumb-item active" >' + this.page.pagename + ' </li>'
    const routeParams = this.route.snapshot.paramMap;
    this.condition = routeParams.get('condition');


    this.LoadAll(this.condition)

  }

  async LoadAll(condition: any) {
    let user = this.user.GetUserInfo()
    let params = {
      company: "C00001",
      employee: condition == "employee" ? user.Employee : ""
    }


    this.spinner.show()
    await this.service.EmployeeGetLeaveHistories(params).subscribe((resp: any) => {
      this.list.length = 0;
      this.list = resp;
      this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
        dtInstance.destroy();
        this.dtTrigger.next(this.dtOptions);
        setTimeout(() => {
          this.spinner.hide()
        }, 1500);
      });
    });

  }
  gotoform() {

    let uri = "leave-request-form/"
    uri = uri + this.condition;
    this.router.navigate([uri]);

  }

  statusDetail(status: any) {
    //ACTIVE CANCELED S-APPROVED S-REJECTED H-APPROVED H-REJECTEDbadge-danger
    if (status == 'ACTIVE') return "<span class='badge badge-warning'>ລໍຖ້າອະນຸມັດ</span>"
    else if (status == 'CANCELED') return "<span class='badge badge-success'>ຖືກຍົກເລີກ (ຜູ້ສ້າງ)</span>"
    // else if (status == 'S-APPROVED') return "<span class='badge badge-success'>ສາຍງານອະນຸມັດ</span>"
    else if (status == 'H-REJECTED') return "<span class='badge badge-danger'>ຖືກຍົກເລີກ (HR)</span>"
    // else if (status == 'H-APPROVED') return "<span class='badge badge-success'>ສາຍງານອະນຸມັດ</span>"
    else if (status == 'S-REJECTED') return "<span class='badge badge-danger'>ຖືກຍົກເລີກ (ສາຍງານ)</span>"
    else if (status == 'SUCCESS' || status == 'H-APPROVED' || status == 'S-APPROVED') return "<span class='badge badge-success'>ຖືກອະນຸມັດແລ້ວ</span>"
    else if (status == 'REJECTED') return "<span class='badge badge-danger'>ຖືກຍົກເລີກແລ້ວ</span>"
    else return "<span class='badge badge-danger'>ບໍ່ຖືກຕ້ອງ</span>"
  }
  print() {
    let user = this.user.GetFpUserId()
    this.router.navigate(["leave-print-summary/" + user.Employee])
  }

}
