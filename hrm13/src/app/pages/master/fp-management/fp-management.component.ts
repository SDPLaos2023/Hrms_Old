import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DataTableDirective } from 'angular-datatables';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs';
import { ModalFpManagerComponent } from 'src/app/components/modals/modal-fp-manager/modal-fp-manager.component';
import { Fp } from 'src/app/models/fp.model';
import { FpService } from 'src/app/Services/fp.service';
import { PageDataService } from 'src/app/Services/shared/page-data.service';

@Component({
  selector: 'app-fp-management',
  templateUrl: './fp-management.component.html',
  styleUrls: ['./fp-management.component.css']
})
export class FpManagementComponent implements OnInit, AfterViewInit {

  constructor(private page: PageDataService, private spinner: NgxSpinnerService, public dialog: MatDialog, private service: FpService) { }
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

  list: Fp[] = []
  dtOptions: DataTables.Settings = {};
  @ViewChild(DataTableDirective, { static: false })
  dtElement: DataTableDirective;
  dtTrigger: Subject<any> = new Subject();

  ngOnInit(): void {
    this.page.pagename = "ຂໍ້ມູນອຸປະກອນຈຳໂປ້"
    this.page.breadcrumb = '<li class="breadcrumb-item"> <i class="fas fa-home"></i> Home</li><li class="breadcrumb-item"> ການຈັດການຂໍ້ມູນອຸປະກອນ </li> <li class="breadcrumb-item active" > ຂໍ້ມູນອຸປະກອນຈຳໂປ້ </li>'
    // this.spinner.show();
    this.LoadAll();
  }

  private extractData(res: any) {
    const body = res;
    return body || {};
  }

  LoadAll() {

    this.service.GetList().pipe(this.extractData).subscribe((resp: any) => {

      if (resp != null) {
        this.list = []

        resp.forEach((element: any) => {
          if (element.id !== 'FM')
            this.list.push(element)
        });
      }

      this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
        dtInstance.destroy();
        this.dtTrigger.next(this.dtOptions);
        setTimeout(() => {
          this.spinner.hide()
        }, 1500);
      });

    })
  }

  openDialog() {
    const dialogRef = this.dialog.open(ModalFpManagerComponent, {
      width: '600px',
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed ' + result);
      if (result === "OK") {
        this.LoadAll()
      }
    });
  }

  ShowUpdate(data: any) {
    const dialogRef = this.dialog.open(ModalFpManagerComponent, {
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
