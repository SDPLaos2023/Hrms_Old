import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DataTableDirective } from 'angular-datatables';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs';
import { Race } from 'src/app/models/race.model';
import { NationlityAndRaceService } from 'src/app/Services/nationlity-and-race.service';
import { ModalRaceComponent } from '../../modals/modal-race/modal-race.component';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-table-race',
  templateUrl: './table-race.component.html',
  styleUrls: ['./table-race.component.css']
})
export class TableRaceComponent implements OnInit, AfterViewInit {
  @ViewChild(DataTableDirective, { static: false })
  dtElement: DataTableDirective;
  dtTriggerRace: Subject<any> = new Subject();
  dtOptions: DataTables.Settings = {};

  races: Race[] = []

  constructor(private service: NationlityAndRaceService, private spinner: NgxSpinnerService,
    public dialogRace: MatDialog) { }
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
    this.dtTriggerRace.next(this.dtOptions)
  }

  ngOnInit(): void {
    this.LoadAll();
  }

  LoadAll() {
    this.service.GetList("Races").pipe(this.extractData).subscribe((resp: any) => {
      this.races.length = 0;
      if (resp != null) {
        resp.forEach((element: any) => {
          if (element.id !== 'R')
            this.races.push(element)
        });
      }
      this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
        dtInstance.destroy();
        this.dtTriggerRace.next(this.dtOptions);
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


  openRaceDialog() {
    const dialogRef = this.dialogRace.open(ModalRaceComponent, {
      width: '600px',
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed ' + result);
      if (result === "OK") {
        this.LoadAll()
      }
    });
  }

  ShowUpdateRace(item: any) {
    const dialogRef = this.dialogRace.open(ModalRaceComponent, {
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
    this.service.Delete("Races", id).subscribe((resp: any) => {
      this.spinner.hide()
      if (resp == "SUCCESS") {
        this.LoadAll();
      }
    })
  }


}
