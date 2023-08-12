import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DataTableDirective } from 'angular-datatables';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs';
import { ModalCurrencyComponent } from 'src/app/components/modals/modal-currency/modal-currency.component';
import { Currency } from 'src/app/models/currency.model';
import { CurrencyService } from 'src/app/Services/currency.service';
import { PageDataService } from 'src/app/Services/shared/page-data.service';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-currencies',
  templateUrl: './currencies.component.html',
  styleUrls: ['./currencies.component.css']
})
export class CurrenciesComponent implements OnInit, AfterViewInit {

  list: Currency[] = []
  dtOptions: DataTables.Settings = {};
  @ViewChild(DataTableDirective, { static: false })
  dtElement: DataTableDirective;
  dtTrigger: Subject<any> = new Subject();
  constructor(private page: PageDataService, private spinner: NgxSpinnerService, public dialog: MatDialog,
    private service: CurrencyService) { }
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
    this.page.pagename = "ຂໍ້ມູນສະກຸນເງິນ"
    this.page.breadcrumb = '<li class="breadcrumb-item"> <i class="fas fa-home"></i> Home</li><li class="breadcrumb-item"> ການຈັດການຂໍ້ມູນພື້ນຖານ </li> <li class="breadcrumb-item active" > ຂໍ້ມູນສະກຸນເງິນ </li>'
    this.LoadAll();
  }
  private extractData(res: any) {
    const body = res;
    return body || {};
  }

  LoadAll() {

    this.service.GetList().pipe(this.extractData).subscribe((resp: any) => {
      this.list.length = 0;
      if (resp != null) {
        resp.forEach((element: any) => {
          if (element.id !== 'CY')
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
    const dialogRef = this.dialog.open(ModalCurrencyComponent, {
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
    const dialogRef = this.dialog.open(ModalCurrencyComponent, {
      width: '600px', data: data
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed ' + result);
      if (result === "OK") {
        this.LoadAll()
      }
    });
  }
  Delete(item: any) {
    const dailogSwal = Swal.mixin({
      customClass: {
        title: 'laoweb',
        confirmButton: 'btn btn-success',
        cancelButton: 'btn btn-danger'
      },
      buttonsStyling: true
    });

    dailogSwal.fire({
      title: "ຕ້ອງການລຶບອອກຈາກລະບົບຫລືບໍ່",
      text: 'ກົດປຸ່ມ ດຳເນີນການຕໍ່ ເພື່ອຢືນຢັນການລຶບອອກຈາກລະບົບ',
      icon: 'question',
      showCancelButton: true,
      confirmButtonText: 'ດຳເນີນການຕໍ່',
      cancelButtonText: 'ຍົກເລີກ'
    }).then((result: any) => {
      if (result.value) {
        console.log("Confirm")
        this.spinner.show();
        this.doDelete(item.id);
      } else if (result.dismiss === Swal.DismissReason.cancel) {
        console.log("cancel");
      }
    });


  }

  doDelete(id: any) {
    this.service.Delete(id).subscribe((resp: any) => {
      this.spinner.hide()
      if (resp == "SUCCESS") {
        this.LoadAll();
      }
    })
  }

}
