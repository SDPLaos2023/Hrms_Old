import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DataTableDirective } from 'angular-datatables';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs';
import { ModalNationalityComponent } from 'src/app/components/modals/modal-nationality/modal-nationality.component';
import { ModalRaceComponent } from 'src/app/components/modals/modal-race/modal-race.component';
import { Nationality } from 'src/app/models/nationality.model';
import { Race } from 'src/app/models/race.model';
import { NationlityAndRaceService } from 'src/app/Services/nationlity-and-race.service';
import { PageDataService } from 'src/app/Services/shared/page-data.service';

@Component({
  selector: 'app-nationality-race',
  templateUrl: './nationality-race.component.html',
  styleUrls: ['./nationality-race.component.css']
})
export class NationalityRaceComponent implements OnInit, AfterViewInit {





  nationalities: Nationality[] = []

  dtOptions2: DataTables.Settings = {};
  isDtInitialized1: boolean = false;
  isDtInitialized2: boolean = false;
  constructor(private page: PageDataService, private service: NationlityAndRaceService,
    private spinner: NgxSpinnerService) {

  }
  ngAfterViewInit(): void {



  }

  ngOnInit(): void {
    // this.spinner.show();

    this.page.pagename = "ຂໍ້ມູນສັນຊາດ"
    this.page.breadcrumb = '<li class="breadcrumb-item"> <i class="fas fa-home"></i> Home</li><li class="breadcrumb-item"> ການຈັດການຂໍ້ມູນພື້ນຖານ </li> <li class="breadcrumb-item active" > ຂໍ້ມູນສັນຊາດ </li>'

    this.dtOptions2 = {
      pagingType: 'full_numbers'
    };


    setTimeout(() => {
      this.spinner.hide();
    }, 700);
  }







}
