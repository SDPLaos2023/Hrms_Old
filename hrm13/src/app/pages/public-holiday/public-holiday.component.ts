import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DataTableDirective } from 'angular-datatables';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs';
import { ModalPublicHolidayComponent } from 'src/app/modals/modal-public-holiday/modal-public-holiday.component';
import { Holiday } from 'src/app/models/holiday.model';
import { HolidaySeittingService } from 'src/app/Services/holiday-seitting.service';
import { PageDataService } from 'src/app/Services/shared/page-data.service';

@Component({
  selector: 'app-public-holiday',
  templateUrl: './public-holiday.component.html',
  styleUrls: ['./public-holiday.component.css']
})
export class PublicHolidayComponent implements OnInit, AfterViewInit {

  dtOptions: DataTables.Settings = {};
  @ViewChild(DataTableDirective, { static: false })
  dtElement: DataTableDirective;
  dtTrigger: Subject<any> = new Subject<any>();
  constructor(private page: PageDataService, private holidayService: HolidaySeittingService, public dialog: MatDialog, private spinner: NgxSpinnerService) { }
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
  list: any[] = []
  activeYear = 1999

  ngOnInit(): void {
    let date = new Date();
    this.activeYear = date.getFullYear();

    this.page.pagename = "ກຳຫນົດວັນພັກລັດຖະການ ແລະ ວັນສຳຄັນຕ່າງໆ"
    this.page.breadcrumb = '<li class="breadcrumb-item"> <i class="fas fa-home"></i> Home</li><li class="breadcrumb-item"> Attendances </li> <li class="breadcrumb-item active" >' + this.page.pagename + ' </li>'

    this.LoadAll();
  }

  LoadAll() {

    this.holidayService.GetList(this.activeYear).subscribe((resp: any) => {
      this.list = [];
      this.list = resp as Holiday[]

      this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
        dtInstance.destroy();
        this.dtTrigger.next(this.dtOptions);
        setTimeout(() => {
          this.spinner.hide()
        }, 1500);
      });
    });
  }

  openDialog() {

    let data = new Holiday()
    const dialogRef = this.dialog.open(ModalPublicHolidayComponent, {
      width: '600px', data
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed ' + result);
      if (result === "OK") {
        this.LoadAll()
      }
    });
  }

  showUpdate(data: any) {

    const dialogRef = this.dialog.open(ModalPublicHolidayComponent, {
      width: '600px', data: data
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed ' + result);
      if (result === "OK") {
        this.LoadAll()
      }
    });
  }
}
