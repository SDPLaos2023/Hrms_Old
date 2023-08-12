import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs';
import { ModalDistrictComponent } from 'src/app/components/modals/modal-district/modal-district.component';
import { District } from 'src/app/models/district.model';
import { Province } from 'src/app/models/province.model';
import { DistrictService } from 'src/app/Services/district.service';
import { ProvinceService } from 'src/app/Services/province.service';
import { PageDataService } from 'src/app/Services/shared/page-data.service';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-districts',
  templateUrl: './districts.component.html',
  styleUrls: ['./districts.component.css']
})
export class DistrictsComponent implements OnInit, AfterViewInit {

  list: District[] = []
  dtOptions: DataTables.Settings = {};
  @ViewChild(DataTableDirective, { static: false })
  dtElement: DataTableDirective;
  dtTrigger: Subject<any> = new Subject();
  provinces: Province[] = []
  province: string | null;
  constructor(private page: PageDataService, private route: ActivatedRoute, private spinner: NgxSpinnerService, public dialog: MatDialog,
    private service: DistrictService, private provService: ProvinceService) {

    const routeParams = this.route.snapshot.paramMap;
    this.province = routeParams.get('province')

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

  ngOnInit(): void {

    this.page.pagename = "ຂໍ້ມູນເມືອງ"
    this.page.breadcrumb = '<li class="breadcrumb-item"> <i class="fas fa-home"></i> Home</li><li class="breadcrumb-item"> ການຈັດການຂໍ້ມູນພື້ນຖານ </li> <li class="breadcrumb-item active" > ຂໍ້ມູນເມືອງ </li>'
    // this.spinner.show();
    this.provService.GetList().subscribe((resp: any) => {

      resp.forEach((element: any) => {
        if (element.id !== 'PR')
          this.provinces.push(element)
      });

    })

    this.LoadAll(this.province)

  }
  private extractData(res: any) {
    const body = res;
    return body || {};
  }

  DistrictChange(province: any) {
    console.log('tag', province)
    this.list.length = 0;
    this.LoadAll(province)
  }

  LoadAll(province: any) {
    // this.spinner.show()

    this.service.GetDistricts(province).pipe(this.extractData).subscribe((resp: any) => {
      // console.log("after load all", resp)
      if (resp != undefined) {
        this.list.length = 0;
        resp.forEach((element: any) => {
          if (element.id != 'DI') {
            this.list.push(element)
          }
        });

        this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
          dtInstance.destroy();
          this.dtTrigger.next(this.dtOptions);
          setTimeout(() => {
            this.spinner.hide()
          }, 1500);
        });
      }
    })
  }

  openDialog() {
    const dialogRef = this.dialog.open(ModalDistrictComponent, {
      width: '600px', data: { province: this.province, action: "NEW", status: "ACTIVE" }
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed ' + result);
      if (result !== "NOK") {
        this.LoadAll(result)
      }
    });
  }

  ShowUpdate(data: any) {
    console.log('tag', data)
    const dialogRef = this.dialog.open(ModalDistrictComponent, {
      width: '600px', data: data
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed ' + result);
      if (result !== "OK") {
        this.LoadAll(result)
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
        this.LoadAll(this.province);
      }
    })
  }

}
