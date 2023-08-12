import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DataTableDirective } from 'angular-datatables';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs';
import { ModalUsersComponent } from 'src/app/modals/modal-users/modal-users.component';
import { User } from 'src/app/models/user.model';
import { PageDataService } from 'src/app/Services/shared/page-data.service';
import { UserService } from 'src/app/Services/user.service';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit, AfterViewInit {
  @ViewChild(DataTableDirective, { static: false })
  dtElement: DataTableDirective;

  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<User> = new Subject();
  list: any[] = []

  constructor(private page: PageDataService, private user: UserService, public dialog: MatDialog,
    private spinner: NgxSpinnerService,) {
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

    //this.dtTrigger.next(this.list)


  }
  ngAfterViewInit(): void {

    this.dtTrigger.next(this.dtOptions);
  }

  ngOnInit(): void {

    this.page.pagename = "ລາຍຊື່ຜູ້ໃຊ້ລະບົບທັງຫມົດ"
    this.page.breadcrumb = '<li class="breadcrumb-item"> <i class="fas fa-home"></i> Home</li><li class="breadcrumb-item"> ຂໍ້ມູນຜູ້ໃຊ້ລະບົບ </li> <li class="breadcrumb-item active" > ' + this.page.pagename + ' </li>'
    // this.spinner.show();
    this.LoadAll();

  }

  LoadAll() {
    //.pipe(this.extractData)
    this.user.GetList().subscribe((resp: any) => {
      this.list.length = 0
      this.list = resp
      this.spinner.hide();

      this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
        dtInstance.destroy();
        this.dtTrigger.next(this.dtOptions);
        setTimeout(() => {
          this.spinner.hide();
        }, 1000);
      })
    });

  }

  openDialog() {
    // const dialogRef = this.dialog.open(ModalUsersComponent, {
    //   width: '800px'
    // });
    // dialogRef.afterClosed().subscribe(result => {
    //   console.log('The dialog was closed ' + result);
    //   console.log('tag', result)
    //   if (result != 'CANCEL') {
    //     console.log('tag', result)
    //     this.loadUsers()
    //   }
    // });

  }

  private extractData(res: any) {
    const body = res;
    return body || {};
  }

  ShowUpdate(data: any) {
    // const dialogRef = this.dialog.open(ModalUsersComponent, {
    //   width: '800px', data: data
    // });
    // dialogRef.afterClosed().subscribe(result => {
    //   if (result != 'CANCEL') {
    //     console.log('The dialog was closed ' + result);
    //     this.loadUsers();

    //   }
    // });

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
    this.user.Delete(id).subscribe((resp: any) => {
      this.spinner.hide()
      if (resp == "SUCCESS") {
        this.LoadAll();
      }
    })
  }


}
