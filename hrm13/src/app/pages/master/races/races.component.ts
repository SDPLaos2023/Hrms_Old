import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { PageDataService } from 'src/app/Services/shared/page-data.service';

@Component({
  selector: 'app-races',
  templateUrl: './races.component.html',
  styleUrls: ['./races.component.css']
})
export class RacesComponent implements OnInit {
  constructor(private page: PageDataService, private spinner: NgxSpinnerService) {

  }

  ngOnInit(): void {
    // this.spinner.show();

    this.page.pagename = "ຂໍ້ມູນເຊື້ອຊາດ"
    this.page.breadcrumb = '<li class="breadcrumb-item"> <i class="fas fa-home"></i> Home</li><li class="breadcrumb-item"> ການຈັດການຂໍ້ມູນພື້ນຖານ </li> <li class="breadcrumb-item active" > ຂໍ້ມູນເຊື້ອຊາດ </li>'



    setTimeout(() => {
      this.spinner.hide();
    }, 700);
  }

}
