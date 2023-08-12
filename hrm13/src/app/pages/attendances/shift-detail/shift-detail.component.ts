import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs';
import { TimetableService } from 'src/app/Services/attendances/timetable.service';
import { PageDataService } from 'src/app/Services/shared/page-data.service';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-shift-detail',
  templateUrl: './shift-detail.component.html',
  styleUrls: ['./shift-detail.component.css']
})
export class ShiftDetailComponent implements OnInit, AfterViewInit {
  @ViewChild(DataTableDirective, { static: false })
  dtElement: DataTableDirective;

  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<any> = new Subject();
  list: any[] = []
  shift: string | null;
  days: any[] = [{
    code: 0,
    weekday: "ຈັນ"
  }, {
    code: 1,
    weekday: "ອັງຄານ"
  }
    , {
    code: 2,
    weekday: "ພຸດ"
  }, {
    code: 3,
    weekday: "ພະຫັດ"
  }, {
    code: 4,
    weekday: "ສຸກ"
  }, {
    code: 5,
    weekday: "ເສົາ"
  }, {
    code: 6,
    weekday: "ອາທິດ"
  }
  ]
  timetables: any[] = [];
  constructor(private page: PageDataService,
    private route: ActivatedRoute,
    public dialog: MatDialog, private spinner: NgxSpinnerService,
    private service: TimetableService) { }

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
    this.page.pagename = "ການຈັດການຕາລາງເວລາ"
    this.page.breadcrumb = '<li class="breadcrumb-item"> <i class="fas fa-home"></i> Home</li><li class="breadcrumb-item"> Attendances </li> <li class="breadcrumb-item active" >' + this.page.pagename + ' </li>'
    const routeParams = this.route.snapshot.paramMap;
    this.shift = routeParams.get('shift')

    this.LoadAll(this.shift)

  }


  openDialog() {
    // const dialogRef = this.dialog.open(ModalShiftmanagementComponent, {
    //   width: '400px'
    // });
    // dialogRef.afterClosed().subscribe(result => {
    //   // console.log('The dialog was closed ' + result);
    //   console.log('tag', result)
    //   if (result != 'CANCEL') {
    //     console.log('tag', result)
    //     this.LoadAll()
    //   }
    // });
  }
  async LoadAll(shift: any) {

    let params = {
      company: "C00001",
      id: shift
    }
    await this.service.GetAllShiftDetail(params).subscribe((resp: any) => {
      console.log("response", resp);
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
    await this.service.GetList().subscribe((resp: any) => {
      this.timetables.length = 0
      this.timetables = resp
    })
  }
  ShowUpdate(data: any) {
    // const dialogRef = this.dialog.open(ModalShiftmanagementComponent, {
    //   width: '400px', data: data
    // });
    // dialogRef.afterClosed().subscribe(result => {
    //   if (result != 'CANCEL') {
    //     console.log('The dialog was closed ' + result);
    //     this.LoadAll();
    //   }
    // });
  }
  getday(weekday: any) {
    let day = this.days.filter(x => x.code == weekday)
    return day.length > 0 ? day[0].weekday : "-";
  }

  getTimetableName(tt: any) {
    let timetable = this.timetables.filter(x => x.id == tt.timetable);
    let result = timetable.length > 0 ? timetable[0].name + ' [' + timetable[0].startIn + ' - ' + timetable[0].startOut + ']' : "-"
    return result

  }
}
