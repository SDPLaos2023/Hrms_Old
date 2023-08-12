import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DataTableDirective } from 'angular-datatables';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs';
import { Nationality } from 'src/app/models/nationality.model';
import { NationlityAndRaceService } from 'src/app/Services/nationlity-and-race.service';
import { ModalNationalityComponent } from '../../modals/modal-nationality/modal-nationality.component';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-table-nationality',
  templateUrl: './table-nationality.component.html',
  styleUrls: ['./table-nationality.component.css']
})
export class TableNationalityComponent implements OnInit, AfterViewInit {

  @ViewChild(DataTableDirective, { static: false })
  dtElement: DataTableDirective;
  dtOptions: DataTables.Settings = {};
  dtTriggerNationality: Subject<any> = new Subject();
  nationalities: Nationality[] = [];
  constructor(private service: NationlityAndRaceService, private spinner: NgxSpinnerService,
    public dialogNationality: MatDialog) { }
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
    this.dtTriggerNationality.next(this.dtOptions)
  }

  ngOnInit(): void {
    this.LoadAll()
  }

  LoadAll() {
    this.service.GetList("Nationalities").pipe(this.extractData).subscribe((resp: any) => {
      this.nationalities.length = 0;
      if (resp != null) {

        resp.forEach((element: any) => {
          if (element.id !== 'N')
            this.nationalities.push(element)
        });
      }
      // this.dtTriggerNationality.next(this.nationalities)

      this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
        dtInstance.destroy();
        this.dtTriggerNationality.next(this.dtOptions)
        setTimeout(() => {
          this.spinner.hide()
        }, 1500);
      });

    });
  }
  private extractData(res: any) {
    const body = res;
    return body || {};
  }
  openNationalityDialog() {
    const dialogRef = this.dialogNationality.open(ModalNationalityComponent, {
      width: '600px',
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed ' + result);
      if (result === "OK") {
        this.LoadAll()
      }
    });
  }


  ShowUpdateNationality(item: any) {
    const dialogRef = this.dialogNationality.open(ModalNationalityComponent, {
      width: '600px', data: item
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
    this.service.Delete("Nationalities", id).subscribe((resp: any) => {
      this.spinner.hide()
      if (resp == "SUCCESS") {
        this.LoadAll();
      }
    })
  }
}
