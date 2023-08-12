import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs';
import { FpFingerprintMapping } from 'src/app/models/fp-fingerprint-mapping.model';
import { FpFingerprintMappingService } from 'src/app/Services/fp-fingerprint-mapping.service';
import { PageDataService } from 'src/app/Services/shared/page-data.service';

@Component({
  selector: 'app-fp-fingerprint-mapping',
  templateUrl: './fp-fingerprint-mapping.component.html',
  styleUrls: ['./fp-fingerprint-mapping.component.css']
})
export class FpFingerprintMappingComponent implements OnInit, AfterViewInit {
  fpUserId: any;
  list: any[] = [];
  dtOptions: DataTables.Settings = {};
  @ViewChild(DataTableDirective, { static: false })
  dtElement: DataTableDirective;
  dtTrigger: Subject<any> = new Subject();
  fpId: any;
  fpName: any;
  url
  constructor(private page: PageDataService,
    private route: ActivatedRoute, private spinner: NgxSpinnerService, private service: FpFingerprintMappingService) {

    const routeParams = this.route.snapshot.paramMap;
    this.fpUserId = routeParams.get('fpUserId')
    this.page.param3 = this.fpUserId
    this.fpId = this.page.param1
    this.fpName = this.page.param2
    this.url = "/fingerprints/users/" + this.fpId + "/" + this.fpName
    this.page.pagename = "ຂໍ້ມູນລາຍນິ້ວມື"
    this.page.breadcrumb = '<li class="breadcrumb-item"> <i class="fas fa-home"></i> Home</li><li class="breadcrumb-item"> ການຈັດການຂໍ້ມູນອຸປະກອນ </li> <li class="breadcrumb-item active" > ' + this.page.pagename + ' </li>'
    this.LoadAll(this.fpUserId)
  }

  LoadAll(fpUserId: any) {
    this.service.GetList(fpUserId).pipe(this.extractData)
      .subscribe((resp: any) => {
        this.list = resp

        this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
          dtInstance.destroy();
          this.dtTrigger.next(this.dtOptions);
          setTimeout(() => {
            this.spinner.hide()
          }, 1500);
        });
      })
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

  GoBack() {
    window.history.back()
  }

}
