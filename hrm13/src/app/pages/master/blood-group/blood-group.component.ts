import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DataTableDirective } from 'angular-datatables';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs';
import { ModalBloodGroupComponent } from 'src/app/components/modals/modal-blood-group/modal-blood-group.component';
import { BloodGroup } from 'src/app/models/blood-group.model';
import { BloodGroupService } from 'src/app/Services/blood-group.service';
import { PageDataService } from 'src/app/Services/shared/page-data.service';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-blood-group',
  templateUrl: './blood-group.component.html',
  styleUrls: ['./blood-group.component.css']
})
export class BloodGroupComponent implements OnInit, AfterViewInit {
  bloodGroups: BloodGroup[] = []
  dtOptions: DataTables.Settings = {};
  @ViewChild(DataTableDirective, { static: false })
  dtElement: DataTableDirective;
  dtTrigger: Subject<any> = new Subject();
  constructor(private spinner: NgxSpinnerService, private page: PageDataService,
    private service: BloodGroupService, public dialog: MatDialog) { }
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
    // this.spinner.show();

    this.page.pagename = "ຂໍ້ມູນກຣຸບເລືອດ"
    this.page.breadcrumb = '<li class="breadcrumb-item"> <i class="fas fa-home"></i> Home</li><li class="breadcrumb-item"> ການຈັດການຂໍ້ມູນພື້ນຖານ </li> <li class="breadcrumb-item active" > ຂໍ້ມູນສັນຊາດ ແລະ ເຊື້ອຊາດ </li>'
    this.LoadAll()

  }
  private extractData(res: any) {
    const body = res;
    return body || {};
  }

  openDialog() {
    const dialogRef = this.dialog.open(ModalBloodGroupComponent, {
      width: '600px',
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed ' + result);
      if (result === "OK") {
        this.LoadAll()
      }
    });
  }

  LoadAll() {

    this.service.GetList().pipe(this.extractData).subscribe((resp: any) => {
      this.bloodGroups.length = 0;
      if (resp != null) {
        resp.forEach((element: any) => {
          if (element.id !== 'BG')
            this.bloodGroups.push(element)
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

  ShowUpdate(data: any) {
    const dialogRef = this.dialog.open(ModalBloodGroupComponent, {
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
