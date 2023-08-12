import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs';
import { ModalCopyUserComponent } from 'src/app/components/modals/modal-copy-user/modal-copy-user.component';
import { ModalFpUserComponent } from 'src/app/components/modals/modal-fp-user/modal-fp-user.component';
import { FpUser } from 'src/app/models/fp-user.model';
import { FpUserService } from 'src/app/Services/fp-user.service';
import { PageDataService } from 'src/app/Services/shared/page-data.service';

@Component({
  selector: 'app-fp-users',
  templateUrl: './fp-users.component.html',
  styleUrls: ['./fp-users.component.css']
})
export class FpUsersComponent implements OnInit, AfterViewInit {
  fpId: any = "";
  list: any[] = [];
  dtOptions: DataTables.Settings = {};
  @ViewChild(DataTableDirective, { static: false })
  dtElement: DataTableDirective;
  dtTrigger: Subject<any> = new Subject();
  fpName: any;
  constructor(private page: PageDataService,
    private route: ActivatedRoute, private spinner: NgxSpinnerService, private service: FpUserService, public dialog: MatDialog
  ) {

    const routeParams = this.route.snapshot.paramMap;
    this.fpId = routeParams.get('fpid')
    this.fpName = routeParams.get('fpName')
    this.page.param1 = this.fpId
    this.page.param2 = this.fpName

    this.page.pagename = "ຂໍ້ມູນລາຍຊື່ User ປະຈຳເຄື່ອງ " + this.fpId + '|' + this.fpName
    this.page.breadcrumb = '<li class="breadcrumb-item"> <i class="fas fa-home"></i> Home</li><li class="breadcrumb-item"> ການຈັດການຂໍ້ມູນອຸປະກອນ </li> <li class="breadcrumb-item active" > ' + this.page.pagename + ' </li>'

    this.LoadAll();

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
    };
    this.dtTrigger.next(this.dtOptions);
  }

  private extractData(res: any) {
    const body = res;
    return body || {};
  }

  ngOnInit(): void {
  }

  openDialog() {
    var data = {
      id: "0",
      fpId: this.fpId,
      fpRole: "0",
      employee: "E"
    }
    const dialogRef = this.dialog.open(ModalFpUserComponent, {
      width: '600px', data: data
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed ' + result);
      if (result === "OK") {
        this.LoadAll()
      }
    });
  }


  ShowUpdate(data: any) {
    const dialogRef = this.dialog.open(ModalFpUserComponent, {
      width: '600px', data: data
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed ' + result);
      if (result === "OK") {
        this.LoadAll()
      }
    });
  }

  LoadAll() {

    this.service.GetList(this.fpId).pipe(this.extractData).subscribe((resp: any) => {

      if (resp != null) {
        this.list = []

        resp.forEach((element: any) => {
          if (element.id !== 'FU')
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

  openDialogCopyTo(item: any) {
    const dialogRef = this.dialog.open(ModalCopyUserComponent, {
      width: '600px', data: item
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed ' + result);
      if (result === "OK") {
        this.LoadAll()
      }
    });
  }

}
